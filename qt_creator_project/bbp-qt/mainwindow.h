#ifndef MAINWINDOW_H
#define MAINWINDOW_H

#include <QMainWindow>
#include <QGraphicsScene>
#include <QFileSystemModel>
#include <QFuture>
#include <QtCore>

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
    QFuture<void> fileLoadingFuture;
    QFutureWatcher<void> fileLoadingWatcher;

private slots:
    void didSelectFolder(QModelIndex index);
    void didPressConvertButton();
    void loadingFilesDidFinish();

};

#endif // MAINWINDOW_H
