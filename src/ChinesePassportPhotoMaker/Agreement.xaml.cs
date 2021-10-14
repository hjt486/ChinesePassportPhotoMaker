using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ChinesePassportPhotoMaker
{
  /// <summary>
  /// Interaction logic for Agreement.xaml
  /// </summary>
  public partial class Agreement : Window
  {
    public Agreement()
    {
      InitializeComponent();
    }

    private void AgreeButton_Click(object sender, RoutedEventArgs e)
    {
      MainWindow mainWindow = new MainWindow();
      mainWindow.Show();
      this.Hide();
    }

    private void DisagreeButton_Click(object sender, RoutedEventArgs e)
    {
      System.Windows.Application.Current.Shutdown();
    }
  }
}
