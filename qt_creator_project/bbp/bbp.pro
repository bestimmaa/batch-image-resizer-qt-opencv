#-------------------------------------------------
#
# Project created by QtCreator 2013-11-24T01:45:48
#
#-------------------------------------------------

QT       += core gui

greaterThan(QT_MAJOR_VERSION, 4): QT += widgets

TARGET = bbp
TEMPLATE = app


SOURCES += main.cpp\
        mainwindow.cpp \
    outputdirectorydialog.cpp \
    sourceimagesmodel.cpp

HEADERS  += mainwindow.h \
    outputdirectorydialog.h \
    sourceimagesmodel.h

FORMS    += mainwindow.ui \
    outputdirectorydialog.ui

win32:CONFIG(release, debug|release): LIBS += -L$$PWD/../../../../../../../opencv/build/x64/vc11/lib/ -lopencv_core247
else:win32:CONFIG(debug, debug|release): LIBS += -L$$PWD/../../../../../../../opencv/build/x64/vc11/lib/ -lopencv_core247d

INCLUDEPATH += $$PWD/../../../../../../../opencv/build/include
DEPENDPATH += $$PWD/../../../../../../../opencv/build/include

win32:CONFIG(release, debug|release): LIBS += -L$$PWD/../../../../../../../opencv/build/x64/vc11/lib/ -lopencv_highgui247
else:win32:CONFIG(debug, debug|release): LIBS += -L$$PWD/../../../../../../../opencv/build/x64/vc11/lib/ -lopencv_highgui247d

INCLUDEPATH += $$PWD/../../../../../../../opencv/build/include
DEPENDPATH += $$PWD/../../../../../../../opencv/build/include

win32:CONFIG(release, debug|release): LIBS += -L$$PWD/../../../../../../../opencv/build/x64/vc11/lib/ -lopencv_imgproc247
else:win32:CONFIG(debug, debug|release): LIBS += -L$$PWD/../../../../../../../opencv/build/x64/vc11/lib/ -lopencv_imgproc247d

INCLUDEPATH += $$PWD/../../../../../../../opencv/build/include
DEPENDPATH += $$PWD/../../../../../../../opencv/build/include

win32:CONFIG(release, debug|release): LIBS += -L$$PWD/../../../../../../../opencv/build/x64/vc11/lib/ -lopencv_calib3d247
else:win32:CONFIG(debug, debug|release): LIBS += -L$$PWD/../../../../../../../opencv/build/x64/vc11/lib/ -lopencv_calib3d247d

INCLUDEPATH += $$PWD/../../../../../../../opencv/build/include
DEPENDPATH += $$PWD/../../../../../../../opencv/build/include
