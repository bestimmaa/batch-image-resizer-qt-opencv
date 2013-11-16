#ifndef OUTPUTDIRDIALOG_H
#define OUTPUTDIRDIALOG_H

#include <QDialog>
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
};

#endif // OUTPUTDIRDIALOG_H
