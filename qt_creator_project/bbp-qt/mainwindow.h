#ifndef MAINWINDOW_H
#define MAINWINDOW_H

#include <QMainWindow>
#include <QGraphicsScene>
#include <QFileSystemModel>
#include <QFuture>
#include <QtCore>
#include "sourceimagesmodel.h"
#include <outputdirdialog.h>

namespace Ui {
class MainWindow;
}

class MainWindow : public QMainWindow
{
    Q_OBJECT
    
public:
    explicit MainWindow(QWidget *parent = 0);
    ~MainWindow();
    QSettings* settings;
public slots:
    void updateUI();
    
private:
    Ui::MainWindow *ui;
    OutputDirDialog* dialog;
    QFileSystemModel model;
    SourceImagesModel *imagesModel;
    QFuture<std::vector<QFileInfo> > fileLoadingFuture;
    QFutureWatcher<std::vector<QFileInfo> > fileLoadingWatcher;
    std::vector<QFileInfo> *scanResults;
    QGraphicsScene* previewScene;
    QGraphicsPixmapItem* previewPixmapItem;
    QPixmap* previewPixmap;
    bool loadingActive;
    void setLoadingIsActive(bool);
    void configurePreview(QString path);

private slots:
    void didSelectFolder(QModelIndex index);
    void didSelectImage(QModelIndex index);
    void didPressConvertButton();
    void didPressCancelButton();
    void loadingFilesDidFinish();
    void didPressOutputButton();

};

#endif // MAINWINDOW_H
