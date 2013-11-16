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
    dialog(new OutputDirDialog),
    sourceImages(new SourceImagesModel),
    scanResults(new std::vector<QFileInfo>)

{
    ui->setupUi(this);
    model.setRootPath("");
    ui->dirSelector->setModel(&model);
    ui->imagesList->setModel(sourceImages);
    connect(ui->dirSelector, SIGNAL(clicked( QModelIndex )), this, SLOT(didSelectFolder(QModelIndex)));
    connect(ui->buttonConvert,SIGNAL(clicked()),this,SLOT(didPressConvertButton()));
    connect(ui->buttonCancel,SIGNAL(clicked()),this,SLOT(didPressCancelButton()));
    connect(ui->buttonOutput,SIGNAL(clicked()),this,SLOT(didPressOutputButton()));
    this->setLoadingIsActive(false);
    this->updateUI();

}

MainWindow::~MainWindow()
{
    delete ui;
    delete scanResults;
    delete dialog;
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
    ui->imagesList->show();
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
}

void MainWindow::didPressOutputButton(){
    dialog->show();
}
