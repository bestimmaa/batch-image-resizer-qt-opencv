#include "mainwindow.h"
#include "ui_mainwindow.h"
#include <QFileSystemModel>
#include <iostream>
#include <assert.h>
#include <QString>
#include <QDebug>

using namespace std;

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
    bool selectionIsDir = fileModel->isDir(index);
    qDebug()<<"path selected in file browser: "<<path;
    if(isDir){

    }
    // handle file / directory selection
}

void MainWindow::didPressConvertButton(){
    qDebug()<<"button convert pressed";
}
