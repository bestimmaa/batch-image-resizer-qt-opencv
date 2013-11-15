#include "opencvhelper.h"
#include <opencv2/highgui/highgui.hpp>
#include <opencv2/imgproc/imgproc.hpp>
#include <opencv2/core/core.hpp>
#include <opencv2/calib3d/calib3d.hpp>
#include <iostream>
#include <stdio.h>
#include <math.h>
#include <stdlib.h>
#include <string.h>

#define areaUpperLimit 0
#define areaLowerLimit 0

using namespace cv;
using namespace std;
double angle( cv::Point pt1, cv::Point pt2, cv::Point pt0 );

double angle( cv::Point pt1, cv::Point pt2, cv::Point pt0 ) {
    double dx1 = pt1.x - pt0.x;
    double dy1 = pt1.y - pt0.y;
    double dx2 = pt2.x - pt0.x;
    double dy2 = pt2.y - pt0.y;
    return (dx1*dx2 + dy1*dy2)/sqrt((dx1*dx1 + dy1*dy1)*(dx2*dx2 + dy2*dy2) + 1e-10);
}

void find_squares(Mat& image, vector<vector<Point> >& squares, int treshold)
{
    squares.clear();

    // blur will enhance edge detection
    Mat blurred(image);
    medianBlur(image, blurred, 9);
    Mat gray0(blurred.size(), CV_8U), gray;
    vector<vector<Point> > contours;

    // find squares in every color plane of the image
    for (int c = 0; c < 3; c++)
    {
        int ch[] = {c, 0};
        mixChannels(&blurred, 1, &gray0, 1, ch, 1);

        // try several threshold levels
        const int threshold_level = treshold;
        for (int l = 0; l < threshold_level; l++)
        {
            //std::cout<<">>Treshold at "<<l<<"\n";

            // Use Canny instead of zero threshold level!
            // Canny helps to catch squares with gradient shading
            if (l == 0)
            {
                Canny(gray0, gray, 10, 20, 3); //
                // Dilate helps to remove potential holes between edge segments
                dilate(gray, gray, Mat(), Point(-1,-1));
            }
            else
            {
                gray = gray0 >= (l+1) * 255 / threshold_level;
            }

            // Find contours and store them in a list
            findContours(gray, contours, CV_RETR_LIST, CV_CHAIN_APPROX_SIMPLE);

            //std::cout<<contours.size() << " contours found \n";
            // Test contours
            vector<Point> approx;
            for (size_t i = 0; i < contours.size(); i++)
            {
                // approximate contour with accuracy proportional
                // to the contour perimeter
                approxPolyDP(Mat(contours[i]), approx, arcLength(Mat(contours[i]), true)*0.02, true);

                // Note: absolute value of an area is used because
                // area may be positive or negative - in accordance with the
                // contour orientation
                int area = fabs(contourArea(Mat(approx)));
                if (approx.size() == 4 &&
                    area > 1000 &&
                    isContourConvex(Mat(approx)))
                {
                    double maxCosine = 0;

                    for (int j = 2; j < 5; j++)
                    {
                        double cosine = fabs(angle(approx[j%4], approx[j-2], approx[j-1]));
                        maxCosine = MAX(maxCosine, cosine);
                    }

                    if (maxCosine < 0.3){
                        float ratio = ((float)area/image.size[1] *image.size[0]);
                        std::cout<<"square with area of "<< area << "px (" <<  ratio  << " %)"<<" found! ";
                        if (ratio < areaUpperLimit && ratio > areaLowerLimit) {
                            squares.push_back(approx);
                            std::cout<<" -> added.\n";
                        }
                        else{
                            std::cout<<" -> discarded.\n";
                        }
                    }
                }
            }
        }
    }
    std::cout<< squares.size() << " squares found!\n";
}

