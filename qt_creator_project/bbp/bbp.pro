#-------------------------------------------------
#
# Project created by QtCreator 2013-11-24T01:45:48
#
#-------------------------------------------------

QT       += core gui

greaterThan(QT_MAJOR_VERSION, 4): QT += widgets

TARGET = bbp
TEMPLATE = app

# set compiler flags, we don't need any here

#QMAKE_CXXFLAGS += -stdlib=libstdc++

# set the deployment target on for mac os x (TODO: this might hide a linking error related to OpenCV)

QMAKE_MACOSX_DEPLOYMENT_TARGET = 10.9

SOURCES += main.cpp\
        mainwindow.cpp \
    outputdirectorydialog.cpp \
    sourceimagesmodel.cpp

HEADERS  += mainwindow.h \
    outputdirectorydialog.h \
    sourceimagesmodel.h

FORMS    += mainwindow.ui \
    outputdirectorydialog.ui

# this should fit most opencv installations on OS X including homebrew

macx: LIBS += -L/usr/local/lib/ \
    -lopencv_core \
    -lopencv_imgproc \
    -lopencv_calib3d \
    -lopencv_highgui


INCLUDEPATH += /usr/local/include
DEPENDPATH += /usr/local/include
