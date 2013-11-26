#ifndef OUTPUTDIRECTORYDIALOG_H
#define OUTPUTDIRECTORYDIALOG_H

#include <QDialog>
#include <QFileSystemModel>
#include "ui_outputdirectorydialog.h"

class OutputDirectoryDialog : public QDialog, private Ui::OutputDirectoryDialog
{
    Q_OBJECT

public:
    explicit OutputDirectoryDialog(QWidget *parent = 0);
    ~OutputDirectoryDialog();

private:
    Ui::OutputDirectoryDialog *ui;
    QFileSystemModel* model;
    QString selectedPath;
    void updateUI();
private slots:
    void didSelectFolder(QModelIndex index);
    void buttonApplyPressed();
};

#endif // OUTPUTDIRECTORYDIALOG_H
