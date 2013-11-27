#include "mainwindow.h"
#include "ui_mainwindow.h"
#include "outputdirectorydialog.h"

#include <iostream>
#include <assert.h>
#include <QtConcurrent/QtConcurrentRun>
#include <QFileSystemModel>
#include <QString>
#include <QDebug>
#include <QGraphicsPixmapItem>
#include <QFileInfo>

#include <opencv2/highgui/highgui.hpp>
#include <opencv2/imgproc/imgproc.hpp>
#include <opencv2/core/core.hpp>
#include <opencv2/calib3d/calib3d.hpp>

#include <algorithm>    // std::max

using namespace std;
bool scanningStopped = false;
bool convertStopped = false;
std::vector<QFileInfo> scanDir(const QString &path);
void resizeImages(std::vector<QFileInfo> &files, QString destinationPath, int maxWidth, int maxHeight);

bool checkFile(const QFileInfo &file){
    if (file.fileName().endsWith(".jpg") || file.fileName().endsWith(".jpeg")){
        return true;
    }
    return false;
}

std::vector<QFileInfo> scanDir(const QString &path){
    std::vector<QFileInfo> results;
    QFileInfo info(path);
    if(info.isDir()){
        QDirIterator it(path,QDirIterator::Subdirectories);
        while(it.hasNext()){
            if(scanningStopped){
               // results.clear();
                break;
            }
            QFileInfo current = it.fileInfo();
            if(current.isFile() && checkFile(current)){
                qDebug("%s",qPrintable(current.absoluteFilePath()));
                results.push_back(current);
            }
            it.next();
        }
    }
    else{
        if (checkFile(info))
            qDebug("%s",qPrintable(info.absoluteFilePath()));
            results.push_back(info);
    }

    return results;
}

void resizeImages(std::vector<QFileInfo> &files, QString destinationPath, int maxWidth, int maxHeight, int interpolation_algorithm){
    std::vector<QFileInfo>::iterator it;
    for(it = files.begin(); it!=files.end();++it){
        QFileInfo info = *it;
        cv::Mat img =  cv::imread(qPrintable(info.absoluteFilePath()));
        CvSize size = img.size();
        int max = std::max(size.width,size.height);
        int dstMax = std::max(maxWidth,maxHeight);
        float factor = dstMax/(float)max;
        cv::Mat dst;
        cv::resize(img,dst,CvSize(),factor,factor,interpolation_algorithm);
        cv::imwrite(qPrintable(destinationPath+QString("/")+info.fileName()),dst);
    }
}

MainWindow::MainWindow(QWidget *parent) :
    QMainWindow(parent),
    ui(new Ui::MainWindow),
    imagesModel(new SourceImagesModel),
    scanResults(new std::vector<QFileInfo>)
{
    ui->setupUi(this);

    // Settings
    QCoreApplication::setOrganizationName("Bauhaus University Weimar");
    QCoreApplication::setOrganizationDomain("uni-weimar.de");
    QCoreApplication::setApplicationName("Batch Image Processor");
    settings = new QSettings();

    // File tree
    model.setRootPath("");
    ui->dirSelector->setModel(&model);

    // Images list
    ui->imagesList->setModel(imagesModel);

    // Algo selction

    ui->algoSelector->addItem(QString("bilinear"));
    ui->algoSelector->addItem(QString("pixel area relation"));
    ui->algoSelector->addItem(QString("bicubic (4x4)"));
    ui->algoSelector->addItem(QString("Lanczos (8x8)"));

    // Previews
    previewScene = new QGraphicsScene(ui->imagePreview);
    previewPixmapItem = new QGraphicsPixmapItem();
    previewScene->addItem(previewPixmapItem);
    ui->imagePreview->setScene(previewScene);

    // Output dir dialog
    dialog = new OutputDirectoryDialog(this);

    // Connect signals and slots
    connect(ui->dirSelector, SIGNAL(clicked( QModelIndex )), this, SLOT(didSelectFolder(QModelIndex)));
    connect(ui->buttonConvert,SIGNAL(clicked()),this,SLOT(didPressConvertButton()));
    connect(ui->buttonCancel,SIGNAL(clicked()),this,SLOT(didPressCancelButton()));
    connect(ui->buttonOutput,SIGNAL(clicked()),this,SLOT(didPressOutputButton()));
    connect(ui->imagesList,SIGNAL(clicked(QModelIndex)),this,SLOT(didSelectImage(QModelIndex)));
    setLoadingIsActive(false);
    updateUI();
}

MainWindow::~MainWindow()
{
    delete ui;
    delete scanResults;
    delete dialog;
    delete settings;
}

void MainWindow::setLoadingIsActive(bool loading){
    loadingActive = loading;
    updateUI();
}


void MainWindow::didSelectFolder(QModelIndex index){
    QFileSystemModel *fileModel = (QFileSystemModel*) ui->dirSelector->model();
    QString path = fileModel->filePath(index);
    if(!fileLoadingFuture.isRunning()){
        qDebug()<<"starting scan for path"<<path;
        scanningStopped = false;
        setLoadingIsActive(true);
        fileLoadingFuture = QtConcurrent::run(scanDir,path);
        fileLoadingWatcher.setFuture(this->fileLoadingFuture);
        connect(&this->fileLoadingWatcher,SIGNAL(finished()),this,SLOT(loadingFilesDidFinish()));
    }
}

void MainWindow::didSelectImage(QModelIndex index){
    QFileInfo file = imagesModel->getFile(index.row());
    qDebug()<<file.absoluteFilePath();
    configurePreview(file.absoluteFilePath());
}
void MainWindow::didPressConvertButton(){
    qDebug()<<"button convert pressed";
    int selectedAlgo = ui->algoSelector->currentIndex();
    switch (selectedAlgo){
    case 0:
        selectedAlgo = CV_INTER_LINEAR;
        break;
    case 1:
        selectedAlgo = CV_INTER_AREA;
        break;
    case 2:
        selectedAlgo = CV_INTER_CUBIC;
        break;
    case 3:
        selectedAlgo = CV_INTER_LANCZOS4;
        break;
    default:
        break;
    };
    std::vector<QFileInfo>files = imagesModel->allFiles();
    if(!fileResizeFuture.isRunning()){
        convertStopped = false;
        fileResizeFuture = QtConcurrent::run(resizeImages,files,settings->value("output_dir").value<QString>(),300,300,selectedAlgo);
    }
    updateUI();
}

void MainWindow::didPressCancelButton(){
    scanningStopped = true;
    this->setLoadingIsActive(false);
}

void MainWindow::loadingFilesDidFinish(){
    std::vector<QFileInfo> result = fileLoadingFuture.result();
    qDebug()<<"Loading did finish with "<<result.size();
    setLoadingIsActive(false);
    imagesModel->clear();
    imagesModel->addFiles(result);
}

void MainWindow::updateUI(){
    if(loadingActive){
        ui->dirSelector->setEnabled(false);
        ui->progressBarLoadingFiles->show();
        ui->buttonCancel->show();
        ui->imagesList->setEnabled(false);
        ui->labelSelectFiles->setText("Loading files...");
    }
    else{
        ui->dirSelector->setEnabled(true);
        ui->imagesList->setEnabled(true);
        ui->progressBarLoadingFiles->hide();
        ui->buttonCancel->hide();
        ui->labelSelectFiles->setText("Select directory or file:");
    }

    QString oDir = settings->value("output_dir").value<QString>();
    if(QFileInfo(oDir).isDir()){
        ui->labelOutputDir->setText(oDir);
        ui->buttonConvert->setEnabled(true);
    }
    else{
        ui->labelOutputDir->setText(QString("No valid output dir set"));
        ui->buttonConvert->setEnabled(false);
    }

}

void MainWindow::didPressOutputButton(){
    dialog->show();
}
void MainWindow::configurePreview(QString path){
    previewPixmap = new QPixmap(path);
    previewPixmapItem->setPixmap(*previewPixmap);
    ui->imagePreview->show();
}

