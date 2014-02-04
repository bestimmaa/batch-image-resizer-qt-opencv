A simple batch image resizer written with C++, Qt and OpenCV

![Screenshot](https://github.com/bestimmaa/batch-image-resizer-qt-opencv/blob/master/bbp_screenshot.png?raw=true)

## Dependencies

* Qt 5
* OpenCV

## Running on Windows

In order to run the app from Qt Creator you have to copy the following files and folders to your build directory where your bbp.exe file is located. Use the versions ending in 'd' for the debug configuration. You may need to add additional libraries used. 

### Qt 5 

From *C:\Qt\Qt5.2.0\5.2.0\msvc2012_64_opengl\bin*

* Qt5Widgets(d).dll
* Qt5Core(d).dll
* Qt5Gui(d).dll
* icudt51.dll
* icuin51.dll
* icuuc51.dll

### OpenCV 

From *C:\opencv*

* opencv_core247(d).dll
* opencv_highgui247(d).dll
* opencv_imgproc247(d).dll
* *libEGL(d).dll*
* *libGLESv2(d).dll*


## Deployment on Windows

In addtion to the DLL files listed above add the following folders from *C:\Qt\Qt5.2.0\5.2.0\msvc2012_64_opengl\plugins* to your *\batch-image-resizer\qt_creator_project\build-bbp-Desktop_Qt_5_2_0_MSVC2012_OpenGL_64bit-Release\release* folder:

* platforms/
* imageformats/

You should be able to distribute the *release* folder. Make sure to install the [Visual C++ Redistributable for Visual Studio 2012](http://www.microsoft.com/en-us/download/confirmation.aspx?id=30679) on any computer that runs the application.
