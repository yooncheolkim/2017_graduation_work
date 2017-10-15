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
using System.Windows.Shapes;
using OpenCvSharp;
using System.Diagnostics;

namespace Wpf
{
    /// <summary>
    /// zoom_window.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class zoom_window : System.Windows.Window
    {
        public Mat origin_Mat_Image;
        public Mat temp_Image;
        public zoom_window(Mat input)
        {
            InitializeComponent();
            Debug.WriteLine(input.Size().Width + " " + input.Size().Height);
            this.origin_Mat_Image = input.Clone();
            this.temp_Image = origin_Mat_Image.Clone();
            zoom_image.Source = OpenCvSharp.Extensions.BitmapSourceConverter.ToBitmapSource(origin_Mat_Image);
            Debug.WriteLine(origin_Mat_Image.Size().Width + " " + origin_Mat_Image.Size().Height);
        }

        private void zoom_out_Click(object sender, RoutedEventArgs e)
        {
            double recent_slider_bar_value = zoom_slider.Value;
            zoom_slider.Value = recent_slider_bar_value - 1;
        }

        private void zoom_in_Click(object sender, RoutedEventArgs e)
        {
            double recent_slider_bar_value = zoom_slider.Value;
            zoom_slider.Value = recent_slider_bar_value + 1;
        }

        private void zoom_slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Cv2.Resize(origin_Mat_Image, temp_Image, new OpenCvSharp.Size(origin_Mat_Image.Size().Width * (100 + zoom_slider.Value * 20) / 100, origin_Mat_Image.Size().Height * (100 + zoom_slider.Value * 20) / 100), 0, 0, InterpolationFlags.Cubic);
            Debug.WriteLine(zoom_slider.Value);
            Debug.WriteLine("temp size : " + temp_Image.Size().Width + " " + temp_Image.Size().Height);
            zoom_image.Source = OpenCvSharp.Extensions.BitmapSourceConverter.ToBitmapSource(temp_Image);
        }
    }
}
