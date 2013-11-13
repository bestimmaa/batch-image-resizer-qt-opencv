TEMPLATE = app
CONFIG += console
CONFIG -= qt

SOURCES += \
    ../../src/opencv_prototype.cpp

 INCLUDEPATH += /usr/local/include

 LIBS += \
        -L/usr/local/lib \
        -lopencv_core \
        -lopencv_imgproc \
        -lopencv_calib3d \
        -lopencv_highgui
