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
void resizeImages(std::vector<QFileInfo> &files,QString parentPath, QString destinationPath, QSize dstSize, int interpolation_algorithm);
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
                //qDebug("%s",qPrintable(current.absoluteFilePath()));
                results.push_back(current);
            }
            it.next();
        }
    }
    else{
        if (checkFile(info))
            //qDebug("%s",qPrintable(info.absoluteFilePath()));
            results.push_back(info);
    }

    return results;
}

void resizeImages(std::vector<QFileInfo> &files,QString parentPath, QString destinationPath, QSize dstSize, int interpolation_algorithm){
    std::vector<QFileInfo>::iterator it;
    qDebug()<<"Starting resizing for "<<files.size()<< "files";
    for(it = files.begin(); it!=files.end();++it){
        if(convertStopped){
            qDebug()<<"Resizing stopped!";
            break;
        }
        QFileInfo info = *it;
        qDebug()<<"Reading file "<< qPrintable(info.fileName());

        // this is the path we want to write to (without the filename)
        QString p = info.absolutePath();
        p.replace(parentPath,destinationPath);
        qDebug()<<"Target path  "<< qPrintable(p);

        // read the image
        cv::Mat img =  cv::imread(qPrintable(info.absoluteFilePath()));
        CvSize size = img.size();
        qDebug()<<"Dimension: "<<size.width << " "<< size.height;

        int srcMax = std::max(size.width,size.height);
        int dstMax = std::max(dstSize.width(),dstSize.height());
        float factor = dstMax/(float)srcMax;
        if (factor*size.width > 1.0 && factor*size.height > 1.0 ){

            // create the subfolders if nessesarcy
            QDir dir(p);
            if (!dir.exists()){
              qDebug()<<"Creating subfolder...";
              dir.mkpath(".");
            }

            cv::Mat dst;
            cv::resize(img,dst,CvSize(),factor,factor,interpolation_algorithm);
            cv::imwrite(qPrintable(p+"/"+info.fileName()),dst);
        }
        else{
            qDebug()<<"Can't fit file "<< qPrintable(info.fileName())<<"with dimension "<<size.width<<"x"<<size.height <<"into constraining rect with dimension"<<dstSize.width()<<"x"<<dstSize.height()<<" factor = "<<factor;
        }

    }
}

MainWindow::MainWindow(QWidget *parent) :
    QMainWindow(parent),
    ui(new Ui::MainWindow),
    imagesModel(new SourceImagesModel),
    scanResults(new std::vector<QFileInfo>),
    convertActive(false),
    loadingActive(false),
    imagesParentDirectory(new QString())
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
    connect(ui->buttonCancelConvert,SIGNAL(clicked()),this,SLOT(didPressCancelConvertButton()));
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

//############### GETTER / SETTER ###############


void MainWindow::setLoadingIsActive(bool loading){
    loadingActive = loading;
    updateUI();
}

void MainWindow::setConvertIsActive(bool convert){
    convertActive = convert;
    updateUI();
}

//############### CONFIGURE UI ###############
void MainWindow::updateUI(){

    //configure the dir selection and image loading
    if(loadingActive){
        ui->dirSelector->setEnabled(false);
        ui->progressBarLoadingFiles->show();
        ui->buttonCancel->show();
        ui->imagesList->setEnabled(false);
        ui->labelSelectFiles->setText("Loading files...");
        ui->buttonConvert->hide();
    }

    else{
        ui->dirSelector->setEnabled(true);
        ui->imagesList->setEnabled(true);
        ui->progressBarLoadingFiles->hide();
        ui->buttonCancel->hide();
        ui->labelSelectFiles->setText("Select directory or file:");
        ui->buttonConvert->show();
    }

    //configure the output field
    QString oDir = settings->value("output_dir").value<QString>();
    if(QFileInfo(oDir).isDir()){
        ui->labelOutputDir->setText(oDir);
        ui->buttonConvert->setEnabled(true);
    }
    else{
        ui->labelOutputDir->setText(QString("No valid output dir set"));
        ui->buttonConvert->setEnabled(false);
    }

    //configure the convert progress bar
    if(convertActive){
        ui->progressBarConvert->show();
        ui->buttonCancelConvert->show();
        ui->dirSelector->setEnabled(false);
        ui->imagesList->setEnabled(false);
        ui->buttonOutput->setEnabled(false);
        ui->algoSelector->setEnabled(false);
        ui->spinBoxH->setEnabled(false);
        ui->spinBoxW->setEnabled(false);
        ui->buttonConvert->hide();


    }

    else{
        ui->progressBarConvert->hide();
        ui->buttonCancelConvert->hide();
        ui->buttonOutput->setEnabled(true);
        ui->algoSelector->setEnabled(true);
        ui->spinBoxH->setEnabled(true);
        ui->spinBoxW->setEnabled(true);
        ui->buttonConvert->show();

    }

}


void MainWindow::configurePreview(QString path){
    previewPixmap = new QPixmap(path);
    previewPixmapItem->setPixmap(*previewPixmap);
    ui->imagePreview->show();
}

//############### FUTURE CALLBACKS ###############

void MainWindow::convertingFilesDidFinish(){
    qDebug()<<"Converting did finish!";
    setConvertIsActive(false);
}

void MainWindow::loadingFilesDidFinish(){
    std::vector<QFileInfo> result = fileLoadingFuture.result();
    qDebug()<<"Loading did finish with "<<result.size();
    setLoadingIsActive(false);
    imagesModel->clear();
    imagesModel->addFiles(result);
}

//############### BUTTON CALLBACKS ###############
void MainWindow::didPressOutputButton(){
    dialog->show();
}

void MainWindow::didPressCancelButton(){
    scanningStopped = true;
    this->setLoadingIsActive(false);
}

void MainWindow::didPressCancelConvertButton(){
    convertStopped = true;
    this->setConvertIsActive(false);
}

void MainWindow::didSelectFolder(QModelIndex index){
    QFileSystemModel *fileModel = (QFileSystemModel*) ui->dirSelector->model();
    QString path = fileModel->filePath(index);
    delete imagesParentDirectory;
    imagesParentDirectory = new QString(path);
    if(!fileLoadingFuture.isRunning()){
        qDebug()<<"starting scan for path"<<path;
        scanningStopped = false;
        setLoadingIsActive(true);
        fileLoadingFuture = QtConcurrent::run(scanDir,path);
        connect(&this->fileLoadingWatcher,SIGNAL(finished()),this,SLOT(loadingFilesDidFinish()));
        fileLoadingWatcher.setFuture(this->fileLoadingFuture);
    }
}

void MainWindow::didSelectImage(QModelIndex index){
    QFileInfo file = imagesModel->getFile(index.row());
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
    // get all files to convert
    std::vector<QFileInfo>files = imagesModel->allFiles();
    // get the directory containing all images to recreate subfolder structure

    if(!fileResizeFuture.isRunning()){
        convertStopped = false;
        setConvertIsActive(true);
        fileResizeFuture = QtConcurrent::run(resizeImages,files,*imagesParentDirectory,settings->value("output_dir").value<QString>(),QSize(ui->spinBoxW->value(),ui->spinBoxH->value()),selectedAlgo);
        connect(&this->fileResizeWatcher,SIGNAL(finished()),this,SLOT(convertingFilesDidFinish()));
        fileResizeWatcher.setFuture(this->fileResizeFuture);
    }
    updateUI();
}
