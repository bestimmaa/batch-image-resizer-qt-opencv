#ifndef MAINWINDOW_H
#define MAINWINDOW_H

#include <QMainWindow>
#include <QGraphicsScene>
#include <QFileSystemModel>

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
    void scanDir(const QString &path);

private slots:
    void didSelectFolder(QModelIndex index);
    void didPressConvertButton();

};

#endif // MAINWINDOW_H
