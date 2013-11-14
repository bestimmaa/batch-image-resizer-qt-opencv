#include "mainwindow.h"
#include "ui_mainwindow.h"
#include <QFileSystemModel>
#include <iostream>
#include <assert.h>
#include <QString>
#include <QDebug>

#define MAX_DEPTH 3

using namespace std;

extern void scanDir(QString path);

extern void scanDir(QString path, int depth){
    QFileInfo info(path);
    if(info.isDir()){
        QDirIterator it(path);
        while(it.hasNext()){
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
    ui->dirSelector->show();
    connect(ui->dirSelector, SIGNAL(clicked( QModelIndex )), this, SLOT(didSelectFolder(QModelIndex)));
    connect(ui->buttonConvert,SIGNAL(clicked()),this,SLOT(didPressConvertButton()));
}

MainWindow::~MainWindow()
{
    delete ui;
}

void MainWindow::didSelectFolder(QModelIndex index){
    QFileSystemModel *fileModel = (QFileSystemModel*) ui->dirSelector->model();
    QString path = fileModel->filePath(index);
    if(!this->fileLoadingFuture.isRunning()){
        qDebug()<<"starting scan for path"<<path;
        this->ui->dirSelector->hide();
        this->fileLoadingFuture = QtConcurrent::run(scanDir,path,0);
        this->fileLoadingWatcher.setFuture(this->fileLoadingFuture);
        connect(&this->fileLoadingWatcher,SIGNAL(finished()),this,SLOT(loadingFilesDidFinish()));
    }
}

void MainWindow::didPressConvertButton(){
    qDebug()<<"button convert pressed";
}

void MainWindow::loadingFilesDidFinish(){
    qDebug("Loading did finish!");
    this->ui->dirSelector->show();

}



