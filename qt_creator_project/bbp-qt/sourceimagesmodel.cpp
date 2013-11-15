#include "sourceimagesmodel.h"
#include <QFileSystemModel>

SourceImagesModel::SourceImagesModel(QObject *parent) :
    QAbstractListModel(parent)
{
    imagePaths.push_back(QString("Test"));
}

int SourceImagesModel::rowCount(const QModelIndex &parent) const{
    return imagePaths.size();
}

QVariant SourceImagesModel::data(const QModelIndex &index, int role) const{

    if(role == Qt::DisplayRole) return imagePaths[index.row()];
    return QVariant();
}

void SourceImagesModel::addPath(QString path){
    imagePaths.push_back(path);
}

void SourceImagesModel::addPath(QFileInfo file){
    imagePaths.push_back(file.absoluteFilePath());
}
void SourceImagesModel::clear(){
    imagePaths.clear();
}

