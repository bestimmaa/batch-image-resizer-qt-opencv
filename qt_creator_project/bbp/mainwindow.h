#ifndef MAINWINDOW_H
#define MAINWINDOW_H

#include <QMainWindow>
#include <QGraphicsScene>
#include <QFileSystemModel>
#include <QFuture>
#include <QtCore>
#include "sourceimagesmodel.h"
#include "outputdirectorydialog.h"

namespace Ui{
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
    OutputDirectoryDialog* dialog;
    QFileSystemModel model;
    SourceImagesModel *imagesModel;
    QFuture<std::vector<QFileInfo> > fileLoadingFuture;
    QFutureWatcher<std::vector<QFileInfo> > fileLoadingWatcher;
    QFuture<void> fileResizeFuture;
    QFutureWatcher<void> fileResizeWatcher;
    std::vector<QFileInfo> *scanResults;
    QString* imagesParentDirectory;
    QGraphicsScene* previewScene;
    QGraphicsPixmapItem* previewPixmapItem;
    QPixmap* previewPixmap;
    bool loadingActive;
    bool convertActive;
    void setLoadingIsActive(bool);
    void setConvertIsActive(bool);
    void configurePreview(QString path);
private slots:
    void didSelectFolder(QModelIndex index);
    void didSelectImage(QModelIndex index);
    void didPressConvertButton();
    void didPressCancelButton();
    void loadingFilesDidFinish();
    void convertingFilesDidFinish();
    void didPressCancelConvertButton();
    void didPressOutputButton();
};

#endif // MAINWINDOW_H
