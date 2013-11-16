#include "mainwindow.h"
#include "ui_mainwindow.h"
#include <QFileSystemModel>
#include <iostream>
#include <assert.h>
#include <QString>
#include <QDebug>
#include <outputdirdialog.h>

using namespace std;
bool scanningStopped = false;
std::vector<QFileInfo> scanDir(const QString &path);

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

MainWindow::MainWindow(QWidget *parent) :
    QMainWindow(parent),
    ui(new Ui::MainWindow),
    sourceImages(new SourceImagesModel),
    scanResults(new std::vector<QFileInfo>)
{
    QCoreApplication::setOrganizationName("Bauhaus University Weimar");
    QCoreApplication::setOrganizationDomain("uni-weimar.de");
    QCoreApplication::setApplicationName("Batch Image Processor");

    ui->setupUi(this);
    ui->dirSelector->setModel(&model);
    ui->imagesList->setModel(sourceImages);
    dialog = new OutputDirDialog(this);

    connect(ui->dirSelector, SIGNAL(clicked( QModelIndex )), this, SLOT(didSelectFolder(QModelIndex)));
    connect(ui->buttonConvert,SIGNAL(clicked()),this,SLOT(didPressConvertButton()));
    connect(ui->buttonCancel,SIGNAL(clicked()),this,SLOT(didPressCancelButton()));
    connect(ui->buttonOutput,SIGNAL(clicked()),this,SLOT(didPressOutputButton()));

    model.setRootPath("");
    settings = new QSettings();
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

void MainWindow::didPressConvertButton(){
    qDebug()<<"button convert pressed";
}

void MainWindow::didPressCancelButton(){
    scanningStopped = true;
    this->setLoadingIsActive(false);
}

void MainWindow::loadingFilesDidFinish(){
    std::vector<QFileInfo> result = fileLoadingFuture.result();
    qDebug()<<"Loading did finish with "<<result.size();
    setLoadingIsActive(false);
    sourceImages->clear();
    sourceImages->addFiles(result);
}

void MainWindow::updateUI(){
    if(loadingActive){
        ui->dirSelector->setEnabled(false);
        ui->progressBarLoadingFiles->show();
        ui->buttonCancel->show();
        ui->labelSelectFiles->setText("Loading files...");
    }
    else{
        ui->dirSelector->setEnabled(true);
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
