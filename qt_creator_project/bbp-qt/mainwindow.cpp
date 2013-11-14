#include "mainwindow.h"
#include "ui_mainwindow.h"
#include <QFileSystemModel>
#include <iostream>
#include <assert.h>
#include <QString>
#include <QDebug>

#define MAX_DEPTH 5

using namespace std;
extern bool scanningStopped = false;
extern void scanDir(QString path);

extern void scanDir(QString path, int depth){
    QFileInfo info(path);
    if(info.isDir()){
        QDirIterator it(path);
        while(it.hasNext()){
            if(scanningStopped) break;
            if(depth < MAX_DEPTH)scanDir(it.filePath(),depth+1);
            it.next();
        }
    }
    else{
        qDebug("%s",qPrintable(info.absoluteFilePath()));
    }
}

MainWindow::MainWindow(QWidget *parent) :
    QMainWindow(parent),
    ui(new Ui::MainWindow)
{
    ui->setupUi(this);
    model.setRootPath("");
    ui->dirSelector->setModel(&model);
    connect(ui->dirSelector, SIGNAL(clicked( QModelIndex )), this, SLOT(didSelectFolder(QModelIndex)));
    connect(ui->buttonConvert,SIGNAL(clicked()),this,SLOT(didPressConvertButton()));
    connect(ui->buttonCancel,SIGNAL(clicked()),this,SLOT(didPressCancelButton()));
    this->setLoadingIsActive(false);
    this->updateUI();
}

MainWindow::~MainWindow()
{
    delete ui;
}

void MainWindow::setLoadingIsActive(bool loading){
    this->loadingActive = loading;
    this->updateUI();
}


void MainWindow::didSelectFolder(QModelIndex index){
    QFileSystemModel *fileModel = (QFileSystemModel*) ui->dirSelector->model();
    QString path = fileModel->filePath(index);
    if(!this->fileLoadingFuture.isRunning()){
        qDebug()<<"starting scan for path"<<path;
        scanningStopped = false;
        this->setLoadingIsActive(true);
        this->fileLoadingFuture = QtConcurrent::run(scanDir,path,0);
        this->fileLoadingWatcher.setFuture(this->fileLoadingFuture);
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
    qDebug("Loading did finish!");
    this->setLoadingIsActive(false);
}

void MainWindow::updateUI(){
    if(this->loadingActive){
        this->ui->dirSelector->setEnabled(false);
        this->ui->progressBarLoadingFiles->show();
        this->ui->buttonCancel->show();
        this->ui->labelSelectFiles->setText("Loading files...");
    }
    else{
        this->ui->dirSelector->setEnabled(true);
        this->ui->progressBarLoadingFiles->hide();
        this->ui->buttonCancel->hide();
        this->ui->labelSelectFiles->setText("Select directory or file:");

    }
}


