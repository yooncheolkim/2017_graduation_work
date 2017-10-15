using System;
using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
//using System.Windows.Data;
//using System.Windows.Documents;
//using System.Windows.Input;
//using System.Windows.Media;
//using System.Windows.Media.Imaging;
//using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using Microsoft.Win32;
using System.IO;
using OpenCvSharp;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Newtonsoft.Json;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Wpf
{
    public partial class control_window : System.Windows.Window
    {
        //double Resolution = 5;
        //double Brightness = 50;
        //double Sharpness = 0;
        //double Contrast = 0;
        //double Saturation = 0;
        //double ISO = 400;
        //double ExposureCompensation = 0;

        public control_window()
        {
            InitializeComponent();

            Format_Grid.Visibility = System.Windows.Visibility.Hidden;
            FControl_Grid.Visibility = System.Windows.Visibility.Hidden;
            //Capture_Grid.Visibility = System.Windows.Visibility.Hidden;
        }

        //public control_window(double a, double b, double c, double d, double e, double f, double g)
        //{
        //    InitializeComponent();

        //    Format_Grid.Visibility = System.Windows.Visibility.Hidden;
        //    FControl_Grid.Visibility = System.Windows.Visibility.Hidden;
        //    //Capture_Grid.Visibility = System.Windows.Visibility.Hidden;

        //    Resolution = a;
        //    Brightness = b;
        //    Sharpness = c;
        //    Contrast = d;
        //    Saturation = e;
        //    ISO = f;
        //    ExposureCompensation = g;

        //    this.ResolutionSliderBar.Value = a;
        //    this.BrightnessSliderBar.Value = b;
        //    this.SharpnessSliderBar.Value = c;
        //    this.ContrastSliderBar.Value = d;
        //    this.SaturationSliderBar.Value = e;
        //    this.ISOSliderBar.Value = f;
        //    this.ExposureCompensationSliderBar.Value = g;
        //}

        private void FormatButton_Click(object sender, RoutedEventArgs e)
        {
            Format_Grid.Visibility = System.Windows.Visibility.Visible;
            FControl_Grid.Visibility = System.Windows.Visibility.Hidden;
            //Capture_Grid.Visibility = System.Windows.Visibility.Hidden;
        }
        private void FControlButton_Click(object sender, RoutedEventArgs e)
        {
            Format_Grid.Visibility = System.Windows.Visibility.Hidden;
            FControl_Grid.Visibility = System.Windows.Visibility.Visible;
            //Capture_Grid.Visibility = System.Windows.Visibility.Hidden;
        }
        //private void CaptureButton_Click(object sender, RoutedEventArgs e)
        //{
        //    Format_Grid.Visibility = System.Windows.Visibility.Hidden;
        //    FControl_Grid.Visibility = System.Windows.Visibility.Hidden;
        //    Capture_Grid.Visibility = System.Windows.Visibility.Visible;
        //}
        private void StorageButton_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "PNG|*.png|JPG|*.jpg|BMP|*.bmp";
            dlg.AddExtension = true;
            if (dlg.ShowDialog() == true)
            {
                Cv2.ImWrite(dlg.FileName, MainWindow.NowMatImage);

            }
        }

        public Setting getSettings()
        {
            Setting s = new Setting();

            s.set_resolution = Convert.ToString(ResolutionSliderBar.Value);
            s.set_brightness = BrightnessSliderBar.Value;
            s.set_sharpness = SharpnessSliderBar.Value;
            s.set_contrast = ContrastSliderBar.Value;
            s.set_saturation = SaturationSliderBar.Value;
            s.set_iso = ISOSliderBar.Value;
            s.set_exposureCompensation = ExposureCompensationSliderBar.Value;

            return s;
        }
    }
}