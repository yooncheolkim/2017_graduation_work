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
using OpenCvSharp;
using System.Diagnostics;

namespace Wpf
{
    /// <summary>
    /// history.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class history : UserControl
    {
        public string ng_res;
        public string time;
        public Mat img;
        public history(string ng_res, string time, Mat img)
        {
            InitializeComponent();
            this.ng_res = ng_res;
            this.time = time;
            this.img = img;
            display();
        }

        void display()
        {
            Debug.WriteLine("display");
            textBox_ng_res.Text = ng_res;
            textBox_time.Text = time;
            image.Source = OpenCvSharp.Extensions.BitmapSourceConverter.ToBitmapSource(img);
        }

        private void Grid_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Debug.WriteLine("clicked");
            OnChildSendMatEvent(img, this);
        }
        public delegate void OnChildSendHandler(Mat img, history hi);
        public event OnChildSendHandler OnChildSendMatEvent;

        public void set_ng_res(string ng)
        {
            this.ng_res = ng;
            textBox_ng_res.Text = ng;
        }
        public void set_img(Mat img)
        {
            this.img = img;
            image.Source = OpenCvSharp.Extensions.BitmapSourceConverter.ToBitmapSource(img);
        }

    }
}
