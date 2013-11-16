#ifndef SOURCEIMAGESMODEL_H
#define SOURCEIMAGESMODEL_H

#include <QAbstractItemModel>
#include <QFileSystemModel>
#include <QFileInfo>
#include <vector>


class SourceImagesModel : public QAbstractListModel
{
    Q_OBJECT
public:
    explicit SourceImagesModel(QObject *parent = 0);
    ~SourceImagesModel();
    int rowCount(const QModelIndex &parent) const;
    QVariant data(const QModelIndex &index, int role) const;
    QFileInfo getFile(int row);
    void addPath(QString);
    void addFile(QFileInfo);
    void addFiles(const std::vector<QFileInfo>&files);
    void clear();
signals:
private:
    std::vector<QFileInfo> *imagePaths;

public slots:
    
};

#endif // SOURCEIMAGESMODEL_H
