#include "sourceimagesmodel.h"

SourceImagesModel::SourceImagesModel(QObject *parent) :
    QAbstractListModel(parent)
{
}

int SourceImagesModel::rowCount(const QModelIndex &parent) const{
    return 5;
}

QVariant SourceImagesModel::data(const QModelIndex &index, int role) const{

    if(role == Qt::DisplayRole) return QString("Item");
    return QVariant();
}


