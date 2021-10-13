using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
/*
 * Todos
 * 让绿色方框无法移动过红色区域
 */

namespace ChinesePassportPhotoMaker
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    private ObjectManipulationControl _imageViewerControl = new ObjectManipulationControl(0, 0);
    private ObjectManipulationControl _exampleImageViewerControl = new ObjectManipulationControl(0,0);
    private ObjectManipulationControl _overlayFloatingViewerControl = new ObjectManipulationControl(0, 0);

    public MainWindow()
    {
      InitializeComponent();
      ShowGuidesCheckBox.IsChecked = true;
      ShowHelpersCheckBox.IsChecked = true;
      ShowExampleCheckBox.IsChecked = true;
      UseExamplePhoto();
    }

    private void ImageViewer_MouseDown(object sender, MouseButtonEventArgs e)
    {
      _imageViewerControl.IsSelected = true;
      _imageViewerControl.SetCoordsMouseDown(
          Mouse.GetPosition(Application.Current.MainWindow).X,
          Mouse.GetPosition(Application.Current.MainWindow).Y);
      //DebugLabel1.Content = Mouse.GetPosition(Application.Current.MainWindow).X.ToString();
      //DebugLabel2.Content = Mouse.GetPosition(Application.Current.MainWindow).Y.ToString();
    }

    private void ImageViewer_MouseUp(object sender, MouseButtonEventArgs e)
    {
      _imageViewerControl.SetCoordsMouseUp();
      //DebugLabel1.Content = Mouse.GetPosition(Application.Current.MainWindow).X.ToString();
      //DebugLabel2.Content = Mouse.GetPosition(Application.Current.MainWindow).Y.ToString();
      _imageViewerControl.IsSelected = false;
    }

    private void ImageOrOverlay_MouseMove(object sender, MouseEventArgs e)
    {
      if (_imageViewerControl.IsSelected && e.LeftButton == MouseButtonState.Pressed)
      {
        _imageViewerControl.SetCoordsMouseInMoving(
        Mouse.GetPosition(Application.Current.MainWindow).X,
        Mouse.GetPosition(Application.Current.MainWindow).Y);
        Canvas.SetLeft(ImageViewer, _imageViewerControl.GetCoordsX());
        Canvas.SetTop(ImageViewer, _imageViewerControl.GetCoordsY());
        //DebugLabel1.Content = Mouse.GetPosition(Application.Current.MainWindow).X.ToString();
        //DebugLabel2.Content = Mouse.GetPosition(Application.Current.MainWindow).Y.ToString();
      }
      else if (_overlayFloatingViewerControl.IsSelected && e.LeftButton == MouseButtonState.Pressed)
      {
        _overlayFloatingViewerControl.CoordMouseInMovingY = Mouse.GetPosition(Application.Current.MainWindow).Y;
        Canvas.SetTop(OverlayFloating, _overlayFloatingViewerControl.GetCoordsY());
      }
    }

    private void ImageViewer_MouseWheel(object sender, MouseWheelEventArgs e)
    {
      if (e.Delta > 0)
      {
        _imageViewerControl.SetImageByPoint(2);
      }
      else if (e.Delta < 0)
      {
        _imageViewerControl.SetImageByPoint(-3);
      }
      ImageViewer.Width = _imageViewerControl.ImageWidth;
      ImageViewer.Height = _imageViewerControl.ImageHeight;
    }

    private void OverlayFloating_MouseDown(object sender, MouseButtonEventArgs e)
    {
      _overlayFloatingViewerControl.IsSelected = true;
      _overlayFloatingViewerControl.CoordMouseDownY = Mouse.GetPosition(Application.Current.MainWindow).Y;
    }

    private void OverlayFloating_MouseUp(object sender, MouseButtonEventArgs e)
    {
      _overlayFloatingViewerControl.SetCoordsMouseUpY();
      _overlayFloatingViewerControl.IsSelected = false;
    }

    private void ShowGuidesCheckBox_Checked(object sender, RoutedEventArgs e)
    {
      if (OverlayFloating != null)
      {
        OverlayFloating.Visibility = Visibility.Visible;
      }
      if (OverlayFixed != null)
      {
        OverlayFixed.Visibility = Visibility.Visible;
      }
    }

    private void ShowGuidesCheckBox_Unchecked(object sender, RoutedEventArgs e)
    {
      if (OverlayFloating != null)
      {
        OverlayFloating.Visibility = Visibility.Collapsed;
      }
      if (OverlayFixed != null)
      {
        OverlayFixed.Visibility = Visibility.Collapsed;
      }
    }

    private void ShowHelpersCheckBox_Checked(object sender, RoutedEventArgs e)
    {
      if (Helpers != null)
      {
        Helpers.Visibility = Visibility.Visible;
      }
    }

    private void ShowHelpersCheckBox_Unchecked(object sender, RoutedEventArgs e)
    {
      if(Helpers != null)
      {
        Helpers.Visibility = Visibility.Collapsed;
      }
    }

    private void ShowExampleCheckBox_Checked(object sender, RoutedEventArgs e)
    {
      UseExamplePhoto();
    }

    private void ShowExampleCheckBox_Unchecked(object sender, RoutedEventArgs e)
    {

    }

    private void UseExamplePhoto()
    {
      if (ImageViewer != null)
      {
        _exampleImageViewerControl = new ObjectManipulationControl(-115, -53);
        _exampleImageViewerControl.SetImageWHR(623.25, 831, 0.75);
        ImageViewer.Source = new BitmapImage(new Uri(@"/ChinesePassportPhotoMaker;component/Resources/Example.png", UriKind.Relative));
        ImageViewer.Width = _exampleImageViewerControl.ImageWidth;
        ImageViewer.Height = _exampleImageViewerControl.ImageHeight;
        _imageViewerControl = _exampleImageViewerControl;
        _imageViewerControl.ResetToDefaultXY();
        Canvas.SetLeft(ImageViewer, _imageViewerControl.GetCoordsX());
        Canvas.SetTop(ImageViewer, _imageViewerControl.GetCoordsY());
      }
      if (OverlayFloating != null)
      {
        _overlayFloatingViewerControl = new ObjectManipulationControl(66, 45);
        _overlayFloatingViewerControl.ResetToDefaultXY();
        Canvas.SetLeft(OverlayFloating, _overlayFloatingViewerControl.GetCoordsX());
        Canvas.SetTop(OverlayFloating, _overlayFloatingViewerControl.GetCoordsY());
      }
    }
  }
}
