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
    qtopencvhelper.cpp

HEADERS  += mainwindow.h \
    qtopencvhelper.h

FORMS    += mainwindow.ui

LIBS += -lboost_filesystem
LIBS += -lboost_system

