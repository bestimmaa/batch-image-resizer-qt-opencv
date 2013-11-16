#include "outputdirdialog.h"
#include "ui_outputdirdialog.h"

OutputDirDialog::OutputDirDialog(QWidget *parent) :
    QDialog(parent),
    model(new QFileSystemModel),
    ui(new Ui::OutputDirDialog)
{
    ui->setupUi(this);
    model->setRootPath("");
    ui->dirSelector->setModel(model);
}

OutputDirDialog::~OutputDirDialog()
{
    delete ui;
    delete model;
}
