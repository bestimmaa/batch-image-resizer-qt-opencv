#include "sourceimagesmodel.h"
#include <QFileSystemModel>
#include <QFileInfo>
#include <QDebug>

SourceImagesModel::SourceImagesModel(QObject *parent) :
    QAbstractListModel(parent),
    imagePaths(new std::vector<QFileInfo>)
{
    imagePaths->push_back(QFileInfo("/"));
}
SourceImagesModel::~SourceImagesModel()
{
    delete imagePaths;
}

int SourceImagesModel::rowCount(const QModelIndex &parent) const{
    return imagePaths->size();
}

QVariant SourceImagesModel::data(const QModelIndex &index, int role) const{

    if(role == Qt::DisplayRole){
        QFileInfo file = imagePaths->operator [](index.row());
        return QVariant(file.fileName());
    }
    return QVariant();
}

void SourceImagesModel::addPath(QString path){
    beginInsertRows(QModelIndex(),imagePaths->size(),imagePaths->size());
    imagePaths->push_back(path);
    endInsertRows();
}

void SourceImagesModel::addFile(QFileInfo file){
    beginInsertRows(QModelIndex(),imagePaths->size(),imagePaths->size());
    imagePaths->push_back(file.absoluteFilePath());
    endInsertRows();
}

void SourceImagesModel::addFiles(const std::vector<QFileInfo>& files){
    beginInsertRows(QModelIndex(), imagePaths->size(), imagePaths->size()+files.size()-1);
    std::vector<QFileInfo>::iterator it = imagePaths->end();
    imagePaths->insert(it,files.begin(),files.end());
    endInsertRows();
    qDebug()<<"New model size "<<imagePaths->size();
}
void SourceImagesModel::clear(){
    beginResetModel();
    imagePaths->clear();
    endResetModel();
}

QFileInfo SourceImagesModel::getFile(int row){
    return imagePaths->operator [](row);
}

std::vector<QFileInfo> SourceImagesModel::allFiles(){
    return *imagePaths;
}


