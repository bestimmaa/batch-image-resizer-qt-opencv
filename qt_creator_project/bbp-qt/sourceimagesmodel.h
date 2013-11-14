#ifndef SOURCEIMAGESMODEL_H
#define SOURCEIMAGESMODEL_H

#include <QAbstractItemModel>

class SourceImagesModel : public QAbstractListModel
{
    Q_OBJECT
public:
    explicit SourceImagesModel(QObject *parent = 0);
    int rowCount(const QModelIndex &parent) const;
    QVariant data(const QModelIndex &index, int role) const;
signals:
    
public slots:
    
};

#endif // SOURCEIMAGESMODEL_H
