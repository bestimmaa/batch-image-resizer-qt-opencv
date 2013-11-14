#include "mainwindow.h"
#include "ui_mainwindow.h"
#include <QGraphicsPixmapItem>
#include <QPixmap>
#include <iostream>
#include <assert.h>

MainWindow::MainWindow(QWidget *parent) :
    QMainWindow(parent),
    ui(new Ui::MainWindow)
{
    ui->setupUi(this);
    scene = new QGraphicsScene(ui->graphicsView1);
    QPixmap pixmap("../../img/book1.jpg");
    assert(!pixmap.isNull());
    QGraphicsPixmapItem item(pixmap);
    scene->addPixmap(pixmap);
    ui->graphicsView1->setScene(scene);
    ui->graphicsView1->show();
}

MainWindow::~MainWindow()
{
    delete ui;
}
