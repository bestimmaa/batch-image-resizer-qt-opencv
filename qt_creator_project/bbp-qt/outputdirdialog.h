#ifndef OUTPUTDIRDIALOG_H
#define OUTPUTDIRDIALOG_H

#include <QDialog>
#include <QFileSystemModel>
#include "ui_outputdirdialog.h"

namespace Ui {
class OutputDirDialog;
}

class OutputDirDialog : public QDialog
{
    Q_OBJECT
    
public:
    explicit OutputDirDialog(QWidget *parent = 0);
    ~OutputDirDialog();
    
private:
    Ui::OutputDirDialog *ui;
    QFileSystemModel* model;

};

#endif // OUTPUTDIRDIALOG_H
