#include "mainwindow.h"
#include "ui_mainwindow.h"
#include <QFileSystemModel>
#include <iostream>
#include <assert.h>

MainWindow::MainWindow(QWidget *parent) :
    QMainWindow(parent),
    ui(new Ui::MainWindow)
{
    ui->setupUi(this);
    model.setRootPath("");
    ui->dirSelector->setModel(&model);
    ui->dirSelector->show();
}

MainWindow::~MainWindow()
{
    delete ui;
}
