#include "outputdirdialog.h"
#include "ui_outputdirdialog.h"

OutputDirDialog::OutputDirDialog(QWidget *parent) :
    QDialog(parent),
    ui(new Ui::OutputDirDialog)
{
    ui->setupUi(this);
}

OutputDirDialog::~OutputDirDialog()
{
    delete ui;
}
