#ifndef SOURCEIMAGESMODEL_H
#define SOURCEIMAGESMODEL_H

#include <QAbstractItemModel>
#include <vector>
#include <QFileSystemModel>


class SourceImagesModel : public QAbstractListModel
{
    Q_OBJECT
public:
    explicit SourceImagesModel(QObject *parent = 0);
    int rowCount(const QModelIndex &parent) const;
    QVariant data(const QModelIndex &index, int role) const;
    void addPath(QString);
    void addPath(QFileInfo);
    void clear();
signals:
private:
    std::vector<QString> imagePaths;

public slots:
    
};

#endif // SOURCEIMAGESMODEL_H
