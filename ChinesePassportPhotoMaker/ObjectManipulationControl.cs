using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media.Imaging;

namespace ChinesePassportPhotoMaker
{
  /*
   * Class Name: ObjectManipulationControl
   * Description:
   * This is the class to hold Canvas top/left coordinates info
   * Image width height ratio info (may create new class)
   * To do image/shape manipulation, including, paning, zooming etc.
   */
  class ObjectManipulationControl
  {
    private double _canvasX = 0;  // To track Canvas.SetLeft value
    private double _canvasY = 0;  // To track Canvas.SetTop value
    private double _defaultCanvasX = 0; // Hold init values for reset
    private double _defaultCanvasY = 0; // ...
    private double _coordMouseDownX = 0; // Hold X coordinate when mouse is pressed
    private double _coordMouseDownY = 0; // ... Y ...
    private double _coordMouseInMovingX = 0; // Hold X coordinate of each point when mouse is in moving
    private double _coordMouseInMovingY = 0; // ... Y ...
    private double _imageWidth = 600; // To track image width for zooming
    private double _imageHeight = 800; // ... height ...
    private BitmapImage _image;
    private bool _isSelected = false; // WPF can't differentiate which object is on focus when moving, use this as fix
    
    /*
     * Constructor
     * Needs default Canvas X and Y as paramters
     */
    public ObjectManipulationControl(double x, double y)
    {
      _defaultCanvasX = x;
      _defaultCanvasY = y;
      ResetToDefaultXY();
    }
    /*
     * Setters/Getters
     */
    public BitmapImage Image
    {
      get { return _image; }
      set { 
        _image = value; 
      }
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
    /*
     * Reset Canvas coordinates to default
     * And, clear mouse tracking info
     */
    public void ResetToDefaultXY()
    {
      _canvasX = _defaultCanvasX;
      _canvasY = _defaultCanvasY;
      _coordMouseDownX = 0;
      _coordMouseDownY = 0;
      _coordMouseInMovingX = 0;
      _coordMouseInMovingY = 0;
    }
    /*
     * Tracking coordinates when mouse is pressed
     */
    public void SetCoordsMouseDown(double xCoord, double yCoord)
    {
      _coordMouseDownX = xCoord;
      _coordMouseDownY = yCoord;
    }
    /*
     * Tracking coordinates when mouse is moving (each point)
     */
    public void SetCoordsMouseInMoving(double xCoord, double yCoord)
    {
      _coordMouseInMovingX = xCoord;
      _coordMouseInMovingY = yCoord;
    }
    /*
     * Calculate the moving distance of mouse,
     * and set the Canvas coordinates accordingly
     * This is for tracking,
     * save the last position for next mouse down/moving/up
     */
    public void SetCoordsMouseUp()
    {
      _canvasX += _coordMouseInMovingX - _coordMouseDownX;
      _canvasY += _coordMouseInMovingY - _coordMouseDownY;
    }
    /*
     * Same to above, but this only calculates Y,
     * To ignore the moving on X axis
     * This is for object that only move in Y direction
     */
    public void SetCoordsMouseUpY()
    {
      _canvasY += _coordMouseInMovingY - _coordMouseDownY;
    }
    /*
     * The differnce between this and SetCoordsMouseUp() is that
     * When Mouse Up, the moving action is done, 
     * save the Canvas coordinates for tracking and next moving action
     * 
     * This two is to get REAL TIME canvas X and Y,
     * for updating the image on the canvas in real time
     */
    public double GetCoordsX()
    {
      return _canvasX + _coordMouseInMovingX - _coordMouseDownX;
    }
    public double GetCoordsY()
    {
      return _canvasY + _coordMouseInMovingY - _coordMouseDownY;
    }
    /*
     * This is for zooming action
     * By giving a number in percent (e.g. 5, as 5%)
     * It calculates the new image width and height
     * (Increased to 105%)
     */
    public void SetImageByPoint(int pointDeltaPercent)
    {
      _imageWidth = _imageWidth * (100 + pointDeltaPercent) / 100;
      _imageHeight = _imageWidth / ((double)_image.PixelWidth / (double)_image.PixelHeight);
    }

    public void SetImageWidthHeight(double givingWidth, double givingHeight)
    {
      double wRatio = givingWidth / (double)_image.PixelWidth;
      double hRatio = givingHeight / (double)_image.PixelHeight;
      if (wRatio > hRatio)
      {
        _imageWidth = _image.PixelWidth * wRatio;
        _imageHeight = _imageWidth / ((double)_image.PixelWidth / (double)_image.PixelHeight);
      }
      else
      {
        _imageHeight = _image.PixelHeight * hRatio;
        _imageWidth = givingHeight * ((double)_image.PixelWidth / (double)_image.PixelHeight);
      }

    }

  }
}
