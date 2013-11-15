#ifndef MAINWINDOW_H
#define MAINWINDOW_H

#include <QMainWindow>
#include <QGraphicsScene>
#include <QFileSystemModel>
#include <QFuture>
#include <QtCore>
#include "sourceimagesmodel.h"

namespace Ui {
class MainWindow;
}

class MainWindow : public QMainWindow
{
    Q_OBJECT
    
public:
    explicit MainWindow(QWidget *parent = 0);
    ~MainWindow();
    
private:
    Ui::MainWindow *ui;
    QFileSystemModel model;
    SourceImagesModel *sourceImages;
    QFuture<std::vector<QFileInfo> > fileLoadingFuture;
    QFutureWatcher<std::vector<QFileInfo> > fileLoadingWatcher;
    std::vector<QFileInfo> *scanResults;
    bool loadingActive;
    void updateUI();
    void setLoadingIsActive(bool);

private slots:
    void didSelectFolder(QModelIndex index);
    void didPressConvertButton();
    void didPressCancelButton();
    void loadingFilesDidFinish();

};

#endif // MAINWINDOW_H
