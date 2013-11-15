#include "sourceimagesmodel.h"
#include <QFileSystemModel>
#include <QFileInfo>

SourceImagesModel::SourceImagesModel(QObject *parent) :
    QAbstractListModel(parent)
{
    imagePaths.push_back(QString("Test"));
}

int SourceImagesModel::rowCount(const QModelIndex &parent) const{
    return imagePaths.size();
}

QVariant SourceImagesModel::data(const QModelIndex &index, int role) const{

    if(role == Qt::DisplayRole){
        QFileInfo file = imagePaths[index.row()];
        return QVariant(file.absoluteFilePath());
    }
    return QVariant();
}

void SourceImagesModel::addPath(QString path){
    imagePaths.push_back(path);
}

void SourceImagesModel::addFile(QFileInfo file){
    imagePaths.push_back(file.absoluteFilePath());
}

void SourceImagesModel::addFiles(std::vector<QFileInfo> files){
    imagePaths.clear();
    imagePaths.insert(imagePaths.begin(),files.begin(),files.end());
}
void SourceImagesModel::clear(){
    imagePaths.clear();
}

