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
    opencvhelper.cpp

HEADERS  += mainwindow.h \
    sourceimagesmodel.h \
    imageprocessor.h \
    opencvhelper.h

FORMS    += mainwindow.ui

LIBS += -lopencv_core
LIBS += -lopencv_imgproc
LIBS += -lopencv_calib3d
LIBS += -lopencv_highgui

