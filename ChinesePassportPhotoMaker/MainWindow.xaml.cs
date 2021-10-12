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

namespace ChinesePassportPhotoMaker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ImageViewerControl _imageViewerControl = new ImageViewerControl();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ImageViewer_MouseDown(object sender, MouseButtonEventArgs e)
        {
            _imageViewerControl.SetCoordsMouseDown(
                Mouse.GetPosition(Application.Current.MainWindow).X,
                Mouse.GetPosition(Application.Current.MainWindow).Y);
            DebugLabel1.Content = Mouse.GetPosition(Application.Current.MainWindow).X.ToString();
            DebugLabel2.Content = Mouse.GetPosition(Application.Current.MainWindow).Y.ToString();
        }

        private void ImageViewer_MouseUp(object sender, MouseButtonEventArgs e)
        {
            _imageViewerControl.SetCoordsMouseUp(
                Mouse.GetPosition(Application.Current.MainWindow).X,
                Mouse.GetPosition(Application.Current.MainWindow).Y);
            DebugLabel1.Content = Mouse.GetPosition(Application.Current.MainWindow).X.ToString();
            DebugLabel2.Content = Mouse.GetPosition(Application.Current.MainWindow).Y.ToString();
        }

        private void ImageViewer_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                _imageViewerControl.SetCoordsMouseInMoving(
                Mouse.GetPosition(Application.Current.MainWindow).X,
                Mouse.GetPosition(Application.Current.MainWindow).Y);
                Canvas.SetLeft(ImageViewer, _imageViewerControl.GetCoordsX());
                Canvas.SetTop(ImageViewer, _imageViewerControl.GetCoordsY());
                DebugLabel1.Content = Mouse.GetPosition(Application.Current.MainWindow).X.ToString();
                DebugLabel2.Content = Mouse.GetPosition(Application.Current.MainWindow).Y.ToString();
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
    }
}
