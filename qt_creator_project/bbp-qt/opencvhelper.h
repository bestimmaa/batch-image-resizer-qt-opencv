#ifndef OPENCVHELPER_H
#define OPENCVHELPER_H

#include <opencv2/highgui/highgui.hpp>
#include <opencv2/imgproc/imgproc.hpp>
#include <opencv2/core/core.hpp>
#include <opencv2/calib3d/calib3d.hpp>
using namespace cv;

void find_squares(Mat& image, vector<vector<Point> >& squares, int treshold);

#endif // OPENCVHELPER_H
