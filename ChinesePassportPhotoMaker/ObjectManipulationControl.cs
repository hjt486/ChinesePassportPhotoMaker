using System;
using System.Collections.Generic;
using System.Text;

namespace ChinesePassportPhotoMaker
{
  class ObjectManipulationControl
  {
    private double _canvasX = 0;
    private double _canvasY = 0;
    private double _defaultCanvasX = 0;
    private double _defaultCanvasY = 0;
    private double _coordMouseDownX = 0;
    private double _coordMouseDownY = 0;
    private double _coordMouseInMovingX = 0;
    private double _coordMouseInMovingY = 0;
    private double _imageWidth = 600;
    private double _imageHeight = 800;
    private double _imageWidthByHeightRatio = 0.75;
    private bool _isSelected = false;
    public ObjectManipulationControl(double x, double y)
    {
      _defaultCanvasX = x;
      _defaultCanvasY = y;
      ResetToDefaultXY();
    }
    public void SetImageWHR(double width, double height, double ratio)
    {
      _imageWidth = width;
      _imageHeight = height;
      _imageWidthByHeightRatio = ratio;
    }
    public double CanvasX
    {
      get { return _canvasX; }
      set { _canvasX = value; }
    }
    public double CanvasY
    {
      get { return _canvasY; }
      set { _canvasY = value; }
    }
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
    public double CoordMouseDownX
    {
      get { return _coordMouseDownX; }
      set { _coordMouseDownX = value; }
    }
    public double CoordMouseDownY
    {
      get { return _coordMouseDownY; }
      set { _coordMouseDownY = value; }
    }
    public double CoordMouseInMovingX
    {
      get { return _coordMouseInMovingX; }
      set { _coordMouseInMovingX = value; }
    }
    public double CoordMouseInMovingY
    {
      get { return _coordMouseInMovingY; }
      set { _coordMouseInMovingY = value; }
    }
    public bool IsSelected
    {
      get { return _isSelected; }
      set { _isSelected = value; }
    }

    public void ResetToDefaultXY()
    {
      _canvasX = _defaultCanvasX;
      _canvasY = _defaultCanvasY;
      _coordMouseDownX = 0;
      _coordMouseDownY = 0;
      _coordMouseInMovingX = 0;
      _coordMouseInMovingY = 0;
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
    public void SetCoordsMouseUp()
    {
      _canvasX += _coordMouseInMovingX - _coordMouseDownX;
      _canvasY += _coordMouseInMovingY - _coordMouseDownY;
    }
    public void SetCoordsMouseUpY()
    {
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
      _imageHeight = _imageWidth / _imageWidthByHeightRatio;
    }


  }
}
