using System;
using System.Collections.Generic;
using System.Text;

namespace ChinesePassportPhotoMaker
{
    class ImageViewerControl
    {
        private double _canvasX = 0;
        private double _canvasY = 0;
        private double _coordMouseDownX = 0;
        private double _coordMouseDownY = 0;
        private double _coordMouseInMovingX = 0;
        private double _coordMouseInMovingY = 0;
        private double _imageWidth = 600;
        private double _imageHeight = 800;
        private double _imageWidthByHeightRatio = 0.75;
        public double ImageWidth
        {
            get { return _imageWidth; }
            set { _imageWidth = value; }
        }
        public double ImageHeight
        {
            get { return _imageHeight; }
            set { _imageHeight = value; }
        }
        public double ImageWidthByHeightRatio
        {
            get { return _imageWidthByHeightRatio; }
            set { _imageWidthByHeightRatio = value; }
        }
        public void SetCoordsMouseDown(double xCoord, double yCoord)
        {
            _coordMouseDownX = xCoord;
            _coordMouseDownY = yCoord;
        }
        public void SetCoordsMouseInMoving(double xCoord, double yCoord)
        {
            _coordMouseInMovingX = xCoord;
            _coordMouseInMovingY = yCoord;
        }
        public void SetCoordsMouseUp(double xCoord, double yCoord)
        {
            _canvasX += _coordMouseInMovingX - _coordMouseDownX;
            _canvasY += _coordMouseInMovingY - _coordMouseDownY;
        }
        public double GetCoordsX()
        {
            return _canvasX + _coordMouseInMovingX - _coordMouseDownX;
        }
        public double GetCoordsY()
        {
            return _canvasY + _coordMouseInMovingY - _coordMouseDownY;
        }
        public void SetImageByPoint(int pointDeltaPercent)
        {
            _imageWidth = _imageWidth * (100 + pointDeltaPercent) / 100;
            _imageHeight = _imageWidth /_imageWidthByHeightRatio;
        }


    }
}
