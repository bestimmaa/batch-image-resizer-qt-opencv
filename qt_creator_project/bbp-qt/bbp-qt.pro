#-------------------------------------------------
#
# Project created by QtCreator 2013-11-13T21:03:21
#
#-------------------------------------------------

QT       += core gui

TARGET = bbp-qt
TEMPLATE = app


SOURCES += main.cpp\
        mainwindow.cpp \
    sourceimagesmodel.cpp \
    imageprocessor.cpp \
    opencvhelper.cpp \
    outputdirdialog.cpp

HEADERS  += mainwindow.h \
    sourceimagesmodel.h \
    imageprocessor.h \
    opencvhelper.h \
    outputdirdialog.h

FORMS    += mainwindow.ui \
    outputdirdialog.ui

LIBS += -lopencv_core
LIBS += -lopencv_imgproc
LIBS += -lopencv_calib3d
LIBS += -lopencv_highgui

