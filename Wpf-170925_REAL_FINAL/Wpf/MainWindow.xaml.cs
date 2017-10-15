using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Diagnostics;
using Microsoft.Win32;
using System.IO;
using OpenCvSharp;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Newtonsoft.Json;
using System.IO.Ports;

namespace Wpf
{
    //public class nComboBxItem : ComboBoxItem
    //{
    //    private List<Button> buttonList = new List<Button>();

    //    public void AddButton(Button button)
    //    {
    //        buttonList.Add(button);
    //    }

    //    public void AddButtonToStack(StackPanel stackPanel)
    //    {
    //        Debug.WriteLine("DEBUG _ Add Button To Stack ");

    //        foreach (var button in buttonList)
    //        {
    //            stackPanel.Children.Add(button);
    //            stackPanel.Children.Add(new Rectangle() { Height = 10 });
    //        }
    //    }
    //}

    struct HvtImage
    {
        public int Width;
        public int Height;

        public byte[] Data;
        
    }

    public struct Setting
    {
        public string set_resolution;
        public double set_brightness;
        public double set_sharpness;
        public double set_contrast;
        public double set_saturation;
        public double set_iso;
        public double set_exposureCompensation;
    }

    public class serverHandler
    {
        public Socket serverSocket;
        public MainWindow mainWindow;
        public int CamNum;
        //nComboBxItem item;
        public Mat img;

        //private void UpdateComboBox()
        //{

        //    if (mainWindow.Dispatcher.CheckAccess())
        //    {
        //        //item = new nComboBxItem();
        //        //item.Name = "Cam" + CamNum;
        //        //item.Content = " Cam " + CamNum + " LIVE ";

        //        //mainWindow.WindowMainCombo.Items.Add(item);
        //        //mainWindow.WindowMainCombo.SelectedIndex = CamNum;
        //    }
        //    else
        //        mainWindow.Dispatcher.BeginInvoke(new System.Action(UpdateComboBox));
        //}

        //private void RemoveComboBox()
        //{
        //    if (mainWindow.Dispatcher.CheckAccess())
        //    {
        //        //mainWindow.WindowMainCombo.SelectedIndex = 0;
        //        //mainWindow.WindowMainCombo.Items.Remove(item);
        //        //mainWindow.WindowMainCombo.Items.Refresh();
        //    }
        //    else
        //        mainWindow.Dispatcher.BeginInvoke(new System.Action(RemoveComboBox));
        //}

        public void runServer()
        {
            NetworkStream stream = null;
            StreamReader reader = null;
            StreamWriter sender = null;

            try
            {
                //UpdateComboBox();
                stream = new NetworkStream(serverSocket);
                sender = new StreamWriter(stream);
                reader = new StreamReader(stream);

                while (true)
                {
                    Thread t0 = new Thread(new ThreadStart(getSettings));
                    t0.IsBackground = true;
                    t0.Start();

                    if (mainWindow.setting.set_resolution == "1")
                    {
                        sender.Write("1152"); sender.Flush();
                        //sender.Write("0864"); sender.Flush();
                        sender.Write("0648"); sender.Flush();
                    }
                    else if (mainWindow.setting.set_resolution == "2")
                    {
                        sender.Write("1600"); sender.Flush();
                        //sender.Write("1200"); sender.Flush();
                        sender.Write("0900"); sender.Flush();
                    }
                    else if (mainWindow.setting.set_resolution == "3")
                    {
                        sender.Write("2016"); sender.Flush();
                        //sender.Write("1512"); sender.Flush();
                        sender.Write("1134"); sender.Flush();
                    }
                    else if (mainWindow.setting.set_resolution == "4")
                    {
                        sender.Write("2304"); sender.Flush();
                        //sender.Write("1728"); sender.Flush();
                        sender.Write("1296"); sender.Flush();
                    }
                    else if (mainWindow.setting.set_resolution == "5")
                    {
                        //sender.Write("2592"); sender.Flush();
                        //sender.Write("1944"); sender.Flush();
                        //sender.Write("1920"); sender.Flush();
                        //sender.Write("1080"); sender.Flush();
                        sender.Write("2592"); sender.Flush();
                        sender.Write("1458"); sender.Flush();
                    }
                    else
                    {
                        //sender.Write("1920"); sender.Flush();
                        //sender.Write("1080"); sender.Flush();
                        sender.Write("2592"); sender.Flush();
                        sender.Write("1458"); sender.Flush();
                    }

                    string temp = "";

                    if (mainWindow.setting.set_brightness < 10)
                    {
                        temp += "000";
                        temp += Convert.ToString(mainWindow.setting.set_brightness);
                        sender.Write(temp); sender.Flush();
                    }
                    else if (mainWindow.setting.set_brightness < 100)
                    {
                        temp += "00";
                        temp += Convert.ToString(mainWindow.setting.set_brightness);
                        sender.Write(temp); sender.Flush();
                    }
                    else
                    {
                        temp += "0";
                        temp += Convert.ToString(mainWindow.setting.set_brightness);
                        sender.Write(temp); sender.Flush();
                    }

                    temp = "";

                    if (mainWindow.setting.set_sharpness == -100)
                    {
                        temp += Convert.ToString(mainWindow.setting.set_sharpness);
                        sender.Write(temp); sender.Flush();
                    }
                    else if (mainWindow.setting.set_sharpness < -10)
                    {
                        temp += " ";
                        temp += Convert.ToString(mainWindow.setting.set_sharpness);
                        sender.Write(temp); sender.Flush();
                    }
                    else if (mainWindow.setting.set_sharpness < 0)
                    {
                        temp += "  ";
                        temp += Convert.ToString(mainWindow.setting.set_sharpness);
                        sender.Write(temp); sender.Flush();
                    }
                    else if (mainWindow.setting.set_sharpness < 10)
                    {
                        temp += "000";
                        temp += Convert.ToString(mainWindow.setting.set_sharpness);
                        sender.Write(temp); sender.Flush();
                    }
                    else if (mainWindow.setting.set_sharpness < 100)
                    {
                        temp += "00";
                        temp += Convert.ToString(mainWindow.setting.set_sharpness);
                        sender.Write(temp); sender.Flush();
                    }
                    else
                    {
                        temp += "0";
                        temp += Convert.ToString(mainWindow.setting.set_sharpness);
                        sender.Write(temp); sender.Flush();
                    }

                    temp = "";

                    if (mainWindow.setting.set_contrast == -100)
                    {
                        temp += Convert.ToString(mainWindow.setting.set_contrast);
                        sender.Write(temp); sender.Flush();
                    }
                    else if (mainWindow.setting.set_contrast < -10)
                    {
                        temp += " ";
                        temp += Convert.ToString(mainWindow.setting.set_contrast);
                        sender.Write(temp); sender.Flush();
                    }
                    else if (mainWindow.setting.set_contrast < 0)
                    {
                        temp += "  ";
                        temp += Convert.ToString(mainWindow.setting.set_contrast);
                        sender.Write(temp); sender.Flush();
                    }
                    else if (mainWindow.setting.set_contrast < 10)
                    {
                        temp += "000";
                        temp += Convert.ToString(mainWindow.setting.set_contrast);
                        sender.Write(temp); sender.Flush();
                    }
                    else if (mainWindow.setting.set_contrast < 100)
                    {
                        temp += "00";
                        temp += Convert.ToString(mainWindow.setting.set_contrast);
                        sender.Write(temp); sender.Flush();
                    }
                    else
                    {
                        temp += "0";
                        temp += Convert.ToString(mainWindow.setting.set_contrast);
                        sender.Write(temp); sender.Flush();
                    }

                    temp = "";

                    if (mainWindow.setting.set_saturation == -100)
                    {
                        temp += Convert.ToString(mainWindow.setting.set_saturation);
                        sender.Write(temp); sender.Flush();
                    }
                    else if (mainWindow.setting.set_saturation < -10)
                    {
                        temp += " ";
                        temp += Convert.ToString(mainWindow.setting.set_saturation);
                        sender.Write(temp); sender.Flush();
                    }
                    else if (mainWindow.setting.set_saturation < 0)
                    {
                        temp += "  ";
                        temp += Convert.ToString(mainWindow.setting.set_saturation);
                        sender.Write(temp); sender.Flush();
                    }
                    else if (mainWindow.setting.set_saturation < 10)
                    {
                        temp += "000";
                        temp += Convert.ToString(mainWindow.setting.set_saturation);
                        sender.Write(temp); sender.Flush();
                    }
                    else if (mainWindow.setting.set_saturation < 100)
                    {
                        temp += "00";
                        temp += Convert.ToString(mainWindow.setting.set_saturation);
                        sender.Write(temp); sender.Flush();
                    }
                    else
                    {
                        temp += "0";
                        temp += Convert.ToString(mainWindow.setting.set_saturation);
                        sender.Write(temp); sender.Flush();
                    }

                    temp = "";

                    temp += "0";
                    temp += Convert.ToString(mainWindow.setting.set_iso);
                    sender.Write(temp); sender.Flush();

                    temp = "";

                    if (mainWindow.setting.set_exposureCompensation == -10)
                    {
                        temp += " ";
                        temp += Convert.ToString(mainWindow.setting.set_exposureCompensation);
                        sender.Write(temp); sender.Flush();
                    }
                    else if (mainWindow.setting.set_exposureCompensation < 0)
                    {
                        temp += "  ";
                        temp += Convert.ToString(mainWindow.setting.set_exposureCompensation);
                        sender.Write(temp); sender.Flush();
                    }
                    else if (mainWindow.setting.set_exposureCompensation < 10)
                    {
                        temp += "000";
                        temp += Convert.ToString(mainWindow.setting.set_exposureCompensation);
                        sender.Write(temp); sender.Flush();
                    }
                    else
                    {
                        temp += "00";
                        temp += Convert.ToString(mainWindow.setting.set_exposureCompensation);
                        sender.Write(temp); sender.Flush();
                    }

                    string jsonStr = "";

                    while (true)
                    {
                        string str = reader.ReadLine();
                        if (str.IndexOf("<EOF>") > -1)
                        {
                            Debug.WriteLine("End Of File");
                            break;
                        }
                        jsonStr += str;
                    }

                    HvtImage Himage = JsonConvert.DeserializeObject<HvtImage>(jsonStr);

                    img = new Mat(Himage.Height, Himage.Width, MatType.CV_8UC3, Himage.Data);
                    
                    //img.InRange(Scalar())
                    //img 받아온 옵션값
                    Debug.WriteLine("img option : " + img.Height + " " + img.Width);
                    //Cv2.ImShow("Cam" + CamNum, img);
                    //Cv2.WaitKey(3000);
                    MainWindow.NowMatImage = img.Clone();
                    MainWindow.ResetImage = img.Clone();

                    //파이에서 넘어오는 이미지 바로 이미지 띄우기
                    Thread t1 = new Thread(new ThreadStart(Run));
                    t1.IsBackground = true;
                    t1.Start();
                    
                    //if (MainWindow.NowMatImage == img) {
                    //    Cv2.ImShow("Cam" + CamNum, img);
                    //} Cv2.WaitKey(3000);

                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
            }
            finally
            {
                serverSocket.Close();
            }
        }

        //thread delegate? 
        delegate void WWORK(Mat img);
        void W(Mat img)
        {
            mainWindow.WindowMainImage.Source = OpenCvSharp.Extensions.WriteableBitmapConverter.ToWriteableBitmap(img);
            if (mainWindow.getRecent_history().Count >= 20)
            {
                Debug.WriteLine("delete");
                mainWindow.delete_last_thumbnail();
                mainWindow.add_thumbnail(img);
            }
            else
                mainWindow.add_thumbnail(img);

            mainWindow.Client.Text = "Raspberry Pi Camera 1";
            mainWindow.MAC.Text = "b8:27:eb:27:80:6c";
            mainWindow.IP.Text = "192.168.0.47";

            //이미지 가져올때마다 이미지 저장
            Cv2.ImWrite(System.DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss") + ".bmp", img);
        }

        private void Run()
        {
            mainWindow.WindowMainImage.Dispatcher.BeginInvoke(new WWORK(W), MainWindow.NowMatImage);
        }



        delegate void GS();
        void G()
        {
            mainWindow.setting = mainWindow.c.getSettings();

            Debug.WriteLine(mainWindow.setting.set_resolution);

            Debug.WriteLine(mainWindow.setting.set_brightness);
            Debug.WriteLine(mainWindow.setting.set_sharpness);
            Debug.WriteLine(mainWindow.setting.set_contrast);
            Debug.WriteLine(mainWindow.setting.set_saturation);
            Debug.WriteLine(mainWindow.setting.set_iso);
            Debug.WriteLine(mainWindow.setting.set_exposureCompensation);

            //mainWindow.setting.set_resolution = Convert.ToString(mainWindow.c.BrightnessSliderBar.Value);
        }

        private void getSettings()
        {
            mainWindow.c.Dispatcher.Invoke(new GS(G));
        }
    }

    public class SocketListener
    {
        MainWindow mainWindow;
        int CamNum;
        public serverHandler cHandler;

        public SocketListener(MainWindow Window)
        {
            mainWindow = Window;
            CamNum = 0;
        }

        public void runListen()
        {
            TcpListener tcpListener = null;

            try
            {
                IPAddress ipAd = IPAddress.Parse("192.168.0.37");
                tcpListener = new TcpListener(ipAd, 9999);
                tcpListener.Start();

                while (true)
                {
                    Debug.WriteLine("LISTENING");
                    Socket server = tcpListener.AcceptSocket();

                    cHandler = new serverHandler();
                    cHandler.serverSocket = server;
                    cHandler.mainWindow = mainWindow;
                    cHandler.CamNum = ++CamNum;
                    Thread clientThread = new Thread(new ThreadStart(cHandler.runServer));
                    clientThread.Start();

                }
            }
            catch (Exception exp)
            {
                Debug.WriteLine("LISTEN DEBUG __ " + exp);
            }
            finally
            {
                Debug.WriteLine("LISTEN DEBUG __ STOP LISTENER");
                tcpListener.Stop();
            }
        }
    }

    public partial class MainWindow : System.Windows.Window
    {
        public IntPtr Handle { get; }
        //private bool m_bEStop = false;
        //private bool m_bTestActiveX = false;
        //private bool m_bTestActiveY = false;
        //// thread - "repeat"
        //private Thread m_XRepeatThread = null;
        //private Thread m_YRepeatThread = null;
        //private bool m_bRepeatFlag = false;
        //// thread - "Search"
        //private Thread m_XSearchThread = null;
        //private Thread m_YSearchThread = null;
        //// thread - "continues"
        //private Thread m_ContiThread = null;
        //private bool m_bContiFlag = false;
        
        public struct stDeviceInfo
       {
            public int nAxisCount;
            public short nFirstAxisNo;
            public short nAxtBoardNo;
            public short nModulePos;
            public byte uModuleID;
            public short nAxisPos;
        }

        //		public struct	

        private stDeviceInfo m_stDeviceInfo;
        private short m_nAxis = 0; // 현재 축번호
        private short m_nModuleAxis = 0;

        public static Mat NowMatImage = new Mat();
        public static Mat ResetImage = new Mat();
        SocketListener sl;
        //history 위한 변수
        Queue<history> recent_history = new Queue<history>();

        public Setting setting = new Setting();
        public control_window c = new control_window();

        //현재 thumbnail중에서 지정하고 있는 history
        public history attended_history;
        //zoom 위한 image
        public Mat zoomImage = new Mat();
        public Mat saveImage = new Mat();

        public MainWindow()
        {
            InitializeComponent();
            sl = new SocketListener(this);
            Thread listener = new Thread(new ThreadStart(sl.runListen));
            listener.Start();
            ResizeMode = ResizeMode.CanMinimize;
            InitAxt();

            setting.set_resolution = Convert.ToString(3);
            setting.set_brightness = 50;
            setting.set_contrast = 0;
            setting.set_sharpness = 0;
            setting.set_saturation = 0;
            setting.set_iso = 400;
            setting.set_exposureCompensation = 0;

            //SerialPort sp = new SerialPort("COM5");
            //sp.Open();
            //sp.Write("1");
            //sp.Close();
        }

        private void WindowMainImage_Loaded(object sender, RoutedEventArgs e)
        {
            //Mat initImage = new Mat("D:/noimages.jpg");
            Mat initImage = new Mat(AppDomain.CurrentDomain.BaseDirectory+"no-image-available.png");
            WindowMainImage.Source = OpenCvSharp.Extensions.BitmapSourceConverter.ToBitmapSource(initImage);
        }

        private void WindowMainCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Debug.WriteLine("DEBUG _ Selected Index Info : " + WindowMainCombo.SelectedIndex);
            //Debug.WriteLine("DEBUG _ Name : " + ((nComboBxItem)WindowMainCombo.Items[WindowMainCombo.SelectedIndex]).Name);
        }

        private void BrightnessScrollBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void file_open_button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Title = "Select a Image File";
            openFileDialog1.Filter = "Images Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg;*.jpeg;*.gif;*.bmp;*.png";
            openFileDialog1.ShowDialog();

            if (openFileDialog1.FileNames.Length > 0)
            {
                Debug.WriteLine("Debug _ Selected File: " + openFileDialog1.FileName);

                NowMatImage = new Mat(openFileDialog1.FileName);
                ResetImage = NowMatImage.Clone();
                WindowMainImage.Source = OpenCvSharp.Extensions.BitmapSourceConverter.ToBitmapSource(NowMatImage);
                zoomImage = NowMatImage.Clone();
                saveImage = NowMatImage.Clone();
                if (getRecent_history().Count >= 20)
                {
                    delete_last_thumbnail();
                    add_thumbnail(NowMatImage);
                }
                else
                    add_thumbnail(NowMatImage);

                attended_history.border.BorderBrush = System.Windows.Media.Brushes.Red;
            }
        }

        //public void check_image_button_Click(object sender, RoutedEventArgs e)
        //{
        //    Debug.WriteLine("Debug _ Hello ");

        //    if (!sl.cHandler.img.Empty())
        //    {
        //        NowMatImage = sl.cHandler.img.Clone();
        //        zoomImage = NowMatImage.Clone();
        //        WindowMainImage.Source = OpenCvSharp.Extensions.BitmapSourceConverter.ToBitmapSource(NowMatImage);
        //    }
        //}

        private void gray_convert_button_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Debug _ grayConvert ");

            if (!NowMatImage.Empty())
            {
                Mat temp = NowMatImage.CvtColor(ColorConversionCodes.BGR2GRAY);
                ResetImage = NowMatImage.Clone();
                WindowMainImage.Source = OpenCvSharp.Extensions.BitmapSourceConverter.ToBitmapSource(temp);
                zoomImage = temp.Clone();
                saveImage = temp.Clone();
            }
        }

        private void otsu_button_Click(object sender, RoutedEventArgs e)
        {

            Debug.WriteLine("Debug _ oooo ");
            if (!NowMatImage.Empty())
            {
                Mat temp = NowMatImage.CvtColor(ColorConversionCodes.BGR2GRAY);
                ResetImage = NowMatImage.Clone();
                Cv2.Threshold(temp, temp, 127, 255, ThresholdTypes.Otsu);
                WindowMainImage.Source = OpenCvSharp.Extensions.BitmapSourceConverter.ToBitmapSource(temp);
                zoomImage = temp.Clone();
                saveImage = temp.Clone();
            }
        }

        private void edge_detect_button_Click(object sender, RoutedEventArgs e)
        {

            Debug.WriteLine("Debug _ oooo ");
            if (!NowMatImage.Empty())
            {
                Mat temp = NowMatImage.Clone().CvtColor(ColorConversionCodes.BGR2GRAY);
                ResetImage = NowMatImage.Clone();
                //Mat temp1 = NowMatImage.Clone();

                Mat binary_image = new Mat();
                Cv2.Threshold(temp, binary_image, 127, 255, ThresholdTypes.BinaryInv | ThresholdTypes.Otsu);

                Mat canny_image = new Mat();

                Cv2.Blur(temp, canny_image, new OpenCvSharp.Size(3, 3));
                Cv2.Canny(canny_image, canny_image, 50, 50 * 3, 3);
                WindowMainImage.Source = OpenCvSharp.Extensions.BitmapSourceConverter.ToBitmapSource(canny_image);
                zoomImage = canny_image.Clone();
                saveImage = canny_image.Clone();
            }

            /* * Circle Detection 
            Mat train = NowMatImage.Clone().CvtColor(ColorConversionCodes.BGR2GRAY);
            CircleSegment[] circles;
            Mat dst = new Mat();

            Cv2.GaussianBlur(train, dst, new OpenCvSharp.Size(5, 5), 1.5, 1.5);

            // Note, the minimum distance between concentric circles is 25. Otherwise
            // false circles are detected as a result of the circle's thickness.
            //circles = Cv2.HoughCircles(dst, HoughMethods.Gradient, 1, 25, 50, 25, 5, 200);
            circles = Cv2.HoughCircles(dst, HoughMethods.Gradient, 1, 50, 100, 100, 5, 200);

            for (int i = 0; i < circles.Length; i++)
            {
                Cv2.Circle(dst, circles[i].Center, (int)circles[i].Radius, new Scalar(0), 3);
            }

            WindowMainImage.Source = OpenCvSharp.Extensions.BitmapSourceConverter.ToBitmapSource(dst);
            zoomImage = dst.Clone();
            saveImage = dst.Clone();*/
            //using (new OpenCvSharp.Window("Circles", dst))
            //{
            //    Cv2.WaitKey();
            //}


            /*
             * 로테이션
            Point2f pt = new Point2f(temp1.Rows / 2, temp1.Cols / 2);
            //Mat rotate = Cv2.GetRotationMatrix2D(pt, 45, 1.0);

            Mat rotateImgMat = new Mat();
            Cv2.WarpAffine(temp1, rotateImgMat, rotate, temp1.Size());

            Mat rotateTempMat = new Mat();

            rotateImgMat.ConvertTo(rotateTempMat, MatType.CV_8UC1);


            WindowMainImage.Source = OpenCvSharp.Extensions.BitmapSourceConverter.ToBitmapSource(canny_image);

            NowMatImage = rotateImgMat;
            */
        }

        //private void template_matching_button_Click(object sender, RoutedEventArgs e)
        //{
        //    OpenFileDialog openFileDialog1 = new OpenFileDialog();
        //    openFileDialog1.Title = "Select a Template Image File";
        //    openFileDialog1.Filter = "Images Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg;*.jpeg;*.gif;*.bmp;*.png";
        //    openFileDialog1.ShowDialog();

        //    Mat source = new Mat(); //기존 이미지
        //    Mat templ = new Mat(); //찾고자하는 이미지

        //    if (openFileDialog1.FileNames.Length > 0)
        //    {
        //        Debug.WriteLine("Debug _ Selected File: " + openFileDialog1.FileName);
        //        templ = new Mat(openFileDialog1.FileName);
        //    }
        //    if (!templ.Empty() && !NowMatImage.Empty())
        //    {

        //        source = NowMatImage.CvtColor(ColorConversionCodes.BGR2GRAY);
        //        ResetImage = NowMatImage.Clone();

        //        source = NowMatImage.Clone(); //현재 nowmatimage 가져오기
        //        Mat res = new Mat(NowMatImage.Rows - templ.Rows + 1, NowMatImage.Cols - templ.Cols + 1, type: MatType.CV_32F);//상관계수가 그려진 결과 이미지

        //        //그레이 컨버트
        //        //templ = templ.CvtColor(ColorConversionCodes.BGR2GRAY);

        //        int MAX_COUNT = 10;
        //        while (MAX_COUNT != 0)
        //        {
        //            MAX_COUNT--;
        //            double min, max; // 상관계수가 그려진 이미지에서 가장 작은 값과 가장 큰값 저장할 변수
        //            OpenCvSharp.Point left_Top, right_bottom, matchLoc; // 상관계수가 그려진 이미지에서 찾을 이미지 위치 저장할 변수
        //            double threshold = 0.99;

        //            //템플릿 매칭 실행
        //            Cv2.MatchTemplate(source, templ, res, TemplateMatchModes.CCoeffNormed);
        //            Cv2.Normalize(res, res, 0, 1, NormTypes.MinMax, -1, new Mat());

        //            //템플릿 매칭 결과에서 위치 가져오기
        //            Cv2.MinMaxLoc(res, out min, out max, out right_bottom, out left_Top, new Mat());

        //            if (max > threshold)
        //            {
        //                //만약에 TemplateMatchModes가 CV_TM_SQDIFF 거나 CV_TM_SQDIF_NORMED 면 matchLoc 은 minLoc;
        //                matchLoc = left_Top;

        //                //사각형 그리기.
        //                Cv2.Rectangle(source, matchLoc, new OpenCvSharp.Point(left_Top.X + templ.Width, left_Top.Y + templ.Height), new Scalar(0, 255, 0), 2);
        //                Debug.WriteLine(matchLoc);
        //            }
        //            else { break; }
        //        }
        //        //보여주기.
        //        WindowMainImage.Source = OpenCvSharp.Extensions.BitmapSourceConverter.ToBitmapSource(source);
        //    }
        //}

        public void Reset(object sender, RoutedEventArgs e)
        {
            if (!ResetImage.Empty())
            {
                NowMatImage = ResetImage.Clone();
                zoomImage = ResetImage.Clone();
                WindowMainImage.Source = OpenCvSharp.Extensions.BitmapSourceConverter.ToBitmapSource(NowMatImage);
            }

        }

        private void zoom_button_Click(object sender, RoutedEventArgs e)
        {
            if (!NowMatImage.Empty())
            {
                zoom_window window2 = new zoom_window(zoomImage);
                window2.Show();
            }
        }

        public void Camera_Control_Click(object sender, RoutedEventArgs e)
        {
            control_window window3 = new control_window();

            if (setting.set_resolution              != null)    window3.ResolutionSliderBar.Value               = Convert.ToDouble(setting.set_resolution);
            if (setting.set_brightness              != 0)       window3.BrightnessSliderBar.Value               = Convert.ToDouble(setting.set_brightness);            
            if (setting.set_sharpness               != 0)       window3.SharpnessSliderBar.Value                = Convert.ToDouble(setting.set_sharpness);             
            if (setting.set_contrast                != 0)       window3.ContrastSliderBar.Value                 = Convert.ToDouble(setting.set_contrast);               
            if (setting.set_saturation              != 0)       window3.SaturationSliderBar.Value               = Convert.ToDouble(setting.set_saturation);            
            if (setting.set_iso                     != 0)       window3.ISOSliderBar.Value                      = Convert.ToDouble(setting.set_iso);    
            if (setting.set_exposureCompensation    != 0)       window3.ExposureCompensationSliderBar.Value     = Convert.ToDouble(setting.set_exposureCompensation);

            window3.Show();

            c.ResolutionSliderBar = window3.ResolutionSliderBar;
            c.BrightnessSliderBar = window3.BrightnessSliderBar;
            c.ContrastSliderBar = window3.ContrastSliderBar;
            c.SharpnessSliderBar = window3.SharpnessSliderBar;
            c.SaturationSliderBar = window3.SaturationSliderBar;
            c.ISOSliderBar = window3.ISOSliderBar;
            c.ExposureCompensationSliderBar = window3.ExposureCompensationSliderBar;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            CAxtCAMCFS20.CFS20start_move(0, 0.000000, 30000.000000, 60000.000000);
            CAxtCAMCFS20.CFS20start_move(1, 0.000000, 30000.000000, 60000.000000);

            //SerialPort sp = new SerialPort("COM5");
            //sp.Open();
            //sp.Write("0");
            //sp.Close();

            Environment.Exit(0);
            System.Diagnostics.Process.GetCurrentProcess().Kill();
            this.Close();
        }

        public void add_thumbnail(Mat img)
        {
            if (attended_history != null)
            {
                attended_history.border.BorderBrush = System.Windows.Media.Brushes.White;
            }
            history hi = new Wpf.history("Not inspected yet", System.DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss"), img);
            hi.OnChildSendMatEvent += new history.OnChildSendHandler(hi_OnChildSendMatEvent); // 이벤트 연결
            thumbnail.Children.Add(hi);
            recent_history.Enqueue(hi);
            thumbnail.Children.Add(new Rectangle() { Width = 10 });
            attended_history = hi;
            attended_history.border.BorderBrush = System.Windows.Media.Brushes.Red;
            ScrollViewer.ScrollToRightEnd();
        }
        public void delete_last_thumbnail()
        {
            Debug.WriteLine("delete thumbnail");
            thumbnail.Children.RemoveAt(0);
            thumbnail.Children.RemoveAt(0);
            recent_history.Dequeue();
        }

        //자식 이벤트랑 연결
        public void hi_OnChildSendMatEvent(Mat img, history hi)
        {
            Debug.WriteLine("Clicked event");
            WindowMainImage.Source = OpenCvSharp.Extensions.BitmapSourceConverter.ToBitmapSource(img);
            NowMatImage = img;
            saveImage = NowMatImage.Clone();
            zoomImage = NowMatImage.Clone();
            if (attended_history == hi)
            {

            }
            else
            {
                attended_history.border.BorderBrush = System.Windows.Media.Brushes.White;
                attended_history = hi;
                Debug.WriteLine("red");
                attended_history.border.BorderBrush = System.Windows.Media.Brushes.Red;
            }
        }

        public Queue<history> getRecent_history()
        {
            return recent_history;
        }

        public void setRecent_history(Queue<history> hi)
        {
            recent_history = hi;
        }


        /*여기서부터 모터 제어*/
        public void downButtonUp(object sender, RoutedEventArgs e)
        {
            CAxtCAMCFS20.CFS20set_stop((short)(m_nModuleAxis + 1));
        }

        public void downButtonDown(object sender, RoutedEventArgs e)
        {
            if (m_nAxis < 0)
                return;

            double dVelocity = Math.Abs(Convert.ToDouble(20000));
            double dAccel = Math.Abs(Convert.ToDouble(40000));
            double dDecel = Math.Abs(Convert.ToDouble(20000));


            // 조그 구동 최대 속도 설정
            CAxtCAMCFS20.CFS20set_max_speed(m_nAxis, dVelocity);

            CAxtCAMCFS20.CFS20v_s_move((short)(m_nModuleAxis + 1), dVelocity, dAccel);// 대칭 S Curve
            //CAxtCAMCFS20.CFS20v_move((short)(m_nModuleAxis + 1), dVelocity, dAccel);       // 대칭 Trapezode
        }

        public void upButtonUp(object sender, RoutedEventArgs e)
        {
            CAxtCAMCFS20.CFS20set_stop((short)(m_nModuleAxis + 1));
        }

        public void upButtonDown(object sender, RoutedEventArgs e)
        {
            if (m_nAxis < 0)
                return;

            double dVelocity = Math.Abs(Convert.ToDouble(20000));
            double dAccel = Math.Abs(Convert.ToDouble(40000));
            double dDecel = Math.Abs(Convert.ToDouble(20000));

            // 조그 구동 최대 속도 설정
            CAxtCAMCFS20.CFS20set_max_speed(m_nAxis, dVelocity);

            CAxtCAMCFS20.CFS20v_s_move((short)(m_nModuleAxis + 1), -dVelocity, dAccel);    // 대칭 S Curve
            //CAxtCAMCFS20.CFS20v_move((short)(m_nModuleAxis + 1), -dVelocity, dAccel);      // 대칭 Trapezode
        }

        public void leftButtonUp(object sender, RoutedEventArgs e)
        {
            CAxtCAMCFS20.CFS20set_stop(m_nModuleAxis);
        }

        public void leftButtonDown(object sender, RoutedEventArgs e)
        {
            if (m_nAxis < 0)
                return;

            double dVelocity = Math.Abs(Convert.ToDouble(20000));
            double dAccel = Math.Abs(Convert.ToDouble(40000));
            double dDecel = Math.Abs(Convert.ToDouble(20000));
            // 조그 구동 최대 속도 설정
            CAxtCAMCFS20.CFS20set_max_speed(m_nAxis, dVelocity);

            CAxtCAMCFS20.CFS20v_s_move(m_nModuleAxis, -dVelocity, dAccel); // 대칭 S Curve
            //CAxtCAMCFS20.CFS20v_move(m_nModuleAxis, -dVelocity, dAccel);       // 대칭 Trapezode
        }

        public void rightButtonUp(object sender, RoutedEventArgs e)
        {
            CAxtCAMCFS20.CFS20set_stop(m_nModuleAxis);
        }

        public void rightButtonDown(object sender, RoutedEventArgs e)
        {
            if (m_nAxis < 0)
                return;

            double dVelocity = Math.Abs(Convert.ToDouble(20000));
            double dAccel = Math.Abs(Convert.ToDouble(40000));
            double dDecel = Math.Abs(Convert.ToDouble(20000));

            // 조그 구동 최대 속도 설정
            CAxtCAMCFS20.CFS20set_max_speed(m_nAxis, dVelocity);

            CAxtCAMCFS20.CFS20v_s_move(m_nModuleAxis, dVelocity, dAccel);  // 대칭 S Curve
            //CAxtCAMCFS20.CFS20v_move(m_nModuleAxis, dVelocity, dAccel);        // 대칭 Trapezode
        }

        public void stopButtonClicked(object sender, RoutedEventArgs e)
        {
            //if (m_bRepeatFlag == true)
            //    m_bRepeatFlag = false;
            //else
            //{
            //    if (m_bContiFlag)
            //    {
            //        m_bContiFlag = false;
            //        m_ContiThread = null;

            //        m_bTestActiveX = false;
            //        m_bTestActiveY = false;
            //    }
            //}

            CAxtCAMCFS20.CFS20set_stop(m_nModuleAxis);
            CAxtCAMCFS20.CFS20set_stop((short)(m_nModuleAxis + 1));
        }

        public void StorageButton_Click(object sender, RoutedEventArgs e)
        {
            if (!NowMatImage.Empty())
            {
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.FileName = System.DateTime.Now.ToString("yyyyMMdd_HHmmss");
                dlg.Filter = "bmp|*.bmp|png|*.png|jpg|*.jpg";
                dlg.AddExtension = true;
                if (dlg.ShowDialog() == true)
                {
                    Cv2.ImWrite(dlg.FileName, saveImage);

                }
            }
        }

        public void inspectionButtonClicked(object sender, RoutedEventArgs e)
        {

            ////원 검출
            //if (!NowMatImage.Empty())
            //{
            //    Mat temp = NowMatImage.Clone().CvtColor(ColorConversionCodes.BGR2GRAY);
            //    ResetImage = NowMatImage.Clone();

            //    CircleSegment[] circles;
            //    Mat dst = new Mat();

            //    Cv2.GaussianBlur(temp, dst, new OpenCvSharp.Size(5, 5), 1.5, 1.5);
            //    circles = Cv2.HoughCircles(dst, HoughMethods.Gradient, 1, 25, 75, 60, 5, 200);

            //    for(int i=0; i < circles.Length; i++)
            //    {
            //        Cv2.Circle(dst, circles[i].Center, (int)circles[i].Radius, new Scalar(0), 2);
            //    }

            //    WindowMainImage.Source = OpenCvSharp.Extensions.BitmapSourceConverter.ToBitmapSource(dst);
            //}

            //    OpenFileDialog openFileDialog1 = new OpenFileDialog();
            //    openFileDialog1.Title = "Select a Template Image File";
            //    openFileDialog1.Filter = "Images Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg;*.jpeg;*.gif;*.bmp;*.png";
            //    openFileDialog1.ShowDialog();

            //    Mat source = new Mat(); //기존 이미지
            //    Mat templ = new Mat(); //찾고자하는 이미지

            //OpenFileDialog openFileDialog1 = new OpenFileDialog();
            //openFileDialog1.Title = "Select a Template Image File";
            //openFileDialog1.Filter = "Images Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg;*.jpeg;*.gif;*.bmp;*.png";
            //openFileDialog1.ShowDialog();

            //Mat source = new Mat(); //기존 이미지
            //Mat templ = new Mat(); //찾고자하는 이미지

            //if (openFileDialog1.FileNames.Length > 0)
            //{
            //    Debug.WriteLine("Debug _ Selected File: " + openFileDialog1.FileName);
            //    templ = new Mat(openFileDialog1.FileName);
            //}

            //templ = new Mat(AppDomain.CurrentDomain.BaseDirectory + "\\templ.bmp");


            //if (!templ.Empty() && !NowMatImage.Empty())
            //{

            //    source = NowMatImage.CvtColor(ColorConversionCodes.BGR2GRAY);
            //    ResetImage = NowMatImage.Clone();

            //    source = NowMatImage.Clone(); //현재 nowmatimage 가져오기
            //    Mat res = new Mat(NowMatImage.Rows - templ.Rows + 1, NowMatImage.Cols - templ.Cols + 1, type: MatType.CV_32F);//상관계수가 그려진 결과 이미지

            //    //그레이 컨버트
            //    //templ = templ.CvtColor(ColorConversionCodes.BGR2GRAY);

            //    int MAX_COUNT = 1;
            //    while (MAX_COUNT != 0)
            //    {
            //        MAX_COUNT--;
            //        double min, max; // 상관계수가 그려진 이미지에서 가장 작은 값과 가장 큰값 저장할 변수
            //        OpenCvSharp.Point left_Top, right_bottom, matchLoc; // 상관계수가 그려진 이미지에서 찾을 이미지 위치 저장할 변수
            //        double threshold = 10;

            //        //템플릿 매칭 실행
            //        Cv2.MatchTemplate(source, templ, res, TemplateMatchModes.CCorrNormed);
            //        Cv2.Normalize(res, res, 0, 10, NormTypes.MinMax, -1, new Mat());

            //        //템플릿 매칭 결과에서 위치 가져오기
            //        Cv2.MinMaxLoc(res, out min, out max, out right_bottom, out left_Top, new Mat());

            //        if (max >= threshold)
            //        {
            //            //만약에 TemplateMatchModes가 CV_TM_SQDIFF 거나 CV_TM_SQDIF_NORMED 면 matchLoc 은 minLoc;
            //            matchLoc = left_Top;

            //            //사각형 그리기.
            //            Cv2.Rectangle(source, matchLoc, new OpenCvSharp.Point(left_Top.X + templ.Width, left_Top.Y + templ.Height), new Scalar(0, 255, 0), 2);
            //            Debug.WriteLine(matchLoc);

            //            attended_history.set_ng_res("OK");
            //            attended_history.set_img(source);
            //            //디렉토리 없으면 생성, 있으면 그대로.
            //            string sDirPath = AppDomain.CurrentDomain.BaseDirectory + "\\euro06";
            //            DirectoryInfo di = new DirectoryInfo(sDirPath);
            //            if (di.Exists == false)
            //                di.Create();

            //            Cv2.ImWrite(sDirPath + "\\" + System.DateTime.Now.ToString("yyyyMMdd_HHmmss") + "_OK.bmp",source);

            //        }
            //        else
            //        {
            //            attended_history.set_ng_res("NG");

            //            //디렉토리 없으면 생성, 있으면 그대로.
            //            string sDirPath = AppDomain.CurrentDomain.BaseDirectory + "\\euro06";
            //            DirectoryInfo di = new DirectoryInfo(sDirPath);
            //            if (di.Exists == false)
            //                di.Create();

            //            Cv2.ImWrite(sDirPath + "\\" + System.DateTime.Now.ToString("yyyyMMdd_HHmmss") + "_NG.bmp", source);

            //            break;
            //        }

            //    }
            //    //보여주기.
            //    WindowMainImage.Source = OpenCvSharp.Extensions.BitmapSourceConverter.ToBitmapSource(source);
            //}

            if (!NowMatImage.Empty())
            {
                Mat img_input = NowMatImage.Clone();
                Mat img_hsv = new Mat(img_input.Height, img_input.Width, MatType.CV_8UC3);
                img_binary = new Mat(img_input.Height, img_input.Width, MatType.CV_8UC3);
                //HSV로 변환
                Cv2.CvtColor(img_input, img_hsv, ColorConversionCodes.BGR2HSV);

                //색 범위 지정 -> 이진화
                Cv2.InRange(img_hsv,new Scalar(40,50,0), new Scalar(75,255,255), img_binary);

                for (int i = 0; i < 15; i++)
                {
                    //morphological opening 작은 점들을 제거
                    Cv2.Erode(img_binary, img_binary, Cv2.GetStructuringElement(MorphShapes.Ellipse, new OpenCvSharp.Size(5, 5)));
                    Cv2.Dilate(img_binary, img_binary, Cv2.GetStructuringElement(MorphShapes.Ellipse, new OpenCvSharp.Size(5, 5)));
                }

                int cnt = 0;

                for (int i=0; i < img_binary.Rows; i++)
                {
                    for(int j=0; j < img_binary.Cols; j++)
                    {
                        if(img_binary.At<OpenCvSharp.Vec3b>(i,j)[0] == 255)
                        {
                            cnt++;
                            BFS(i, j);

                            if (cnt >= 30000) break;
                        }
                    }
                }

                Cv2.ImShow("yooncheol",img_binary);

                if (cnt >= 30000)
                {
                    attended_history.set_ng_res("OK");
                    attended_history.set_img(img_input);
                    //디렉토리 없으면 생성, 있으면 그대로.
                    string sDirPath = AppDomain.CurrentDomain.BaseDirectory + "\\euro06";
                    DirectoryInfo di = new DirectoryInfo(sDirPath);
                    if (di.Exists == false)
                        di.Create();

                    Cv2.ImWrite(sDirPath + "\\" + System.DateTime.Now.ToString("yyyyMMdd_HHmmss") + "_OK.bmp", img_input);
                }
                else
                {
                    attended_history.set_ng_res("NG");

                    //디렉토리 없으면 생성, 있으면 그대로.
                    string sDirPath = AppDomain.CurrentDomain.BaseDirectory + "\\euro06";
                    DirectoryInfo di = new DirectoryInfo(sDirPath);
                    if (di.Exists == false)
                        di.Create();

                    Cv2.ImWrite(sDirPath + "\\" + System.DateTime.Now.ToString("yyyyMMdd_HHmmss") + "_NG.bmp", img_input);
                }

                //Debug.WriteLine("result : " +cnt);
                //Cv2.ImShow("hi scg",img_binary);
            }
        }
        public Mat img_binary = new Mat();
        int white_area_cnt = 0;
        List<Tuple<int,int>> idx_i = new List<Tuple<int, int>>();
        public void BFS(int i, int j)
        {
            if (white_area_cnt >= 2000)
            {
                for (int k = 0; k < idx_i.Count; i++)
                {
                    var indexer = img_binary.GetGenericIndexer<Vec3b>();
                    Vec3b vec = img_binary.At<Vec3b>(idx_i[k].Item1, idx_i[k].Item2);
                    vec[0] = 0;
                    vec[1] = 0;
                    vec[2] = 0;
                    indexer[idx_i[k].Item1, idx_i[k].Item2] = vec;
                    
                }
                white_area_cnt = 0;
                idx_i.Clear();
                return;
                
            }

            white_area_cnt++;
            idx_i.Add(new Tuple<int, int>(i, j));

            if (i == 0 && j == 0)
            {
                BFS(i + 1, j);
                BFS(i, j + 1);
            }
            else if (i == img_binary.Rows - 1 && j == img_binary.Cols - 1)
            {
                BFS(i - 1, j);
                BFS(i, j - 1);
            }
            else if (i == 0)
            {
                BFS(i + 1, j);
                BFS(i, j + 1);
                BFS(i, j - 1);
            }
            else if (j == 0)
            {
                BFS(i + 1, j);
                BFS(i, j + 1);
                BFS(i - 1, j);
            }
            else
            {
                BFS(i + 1, j);
                BFS(i, j + 1);
                BFS(i - 1, j);
                BFS(i, j - 1);
            }
        }

        public void pushButtonClicked(object sender, RoutedEventArgs e)
        {
            CAxtCAMCFS20.CFS20start_move(1, -96927.000000, 30000.000000, 60000.000000);
        }

        public void button1_Clicked(object sender, RoutedEventArgs e)
        {
            CAxtCAMCFS20.CFS20start_move(0, 67180.000000, 30000.000000, 60000.000000);
            CAxtCAMCFS20.CFS20start_move(1, -83564.000000, 30000.000000, 60000.000000);
        }

        public void button2_Clicked(object sender, RoutedEventArgs e)
        {
            CAxtCAMCFS20.CFS20start_move(0, 67180.000000, 30000.000000, 60000.000000);
            CAxtCAMCFS20.CFS20start_move(1, -112845.000000, 30000.000000, 60000.000000);
        }

        public void button3_Clicked(object sender, RoutedEventArgs e)
        {
            CAxtCAMCFS20.CFS20start_move(0, 108510.000000, 30000.000000, 60000.000000);
            CAxtCAMCFS20.CFS20start_move(1, -104268.000000, 30000.000000, 60000.000000);
        }

        public void button4_Clicked(object sender, RoutedEventArgs e)
        {
            CAxtCAMCFS20.CFS20start_move(0, 79321.000000, 30000.000000, 60000.000000);
            CAxtCAMCFS20.CFS20start_move(1, -96927.000000, 30000.000000, 60000.000000);
        }

        public void pullButtonClicked(object sender, RoutedEventArgs e)
        {
            CAxtCAMCFS20.CFS20start_move(1, 0.000000, 30000.000000, 60000.000000);
        }

        // 통합 라이브러리 및 모듈 초기화 부분
        private bool InitAxt()
        {
            //++
            // 라이브러리 초기화
            if (CAxtLib.AxtIsInitialized() == 0)                // 통합 라이브러리가 사용 가능하지 (초기화가 되었는지)를 확인한다
            {
                if (CAxtLib.AxtInitialize(this.Handle, 0) == 0)     // 통합 라이브러리를 초기화 한다
                {
                    MessageBox.Show("라이브러리 초기화 실패 입니다. 프로그램을 다시 실행 시켜 주세요");

                    return false;
                }
            }

            // 사용하시는 베이스보드에 맞추어 Device를 Open하면 됩니다.
            // BUSTYPE_ISA					:	0
            // BUSTYPE_PCI					:	1
            // BUSTYPE_VME					:	2
            // BUSTYPE_CPCI(Compact PCI)	:	3

            if (CAxtLib.AxtIsInitializedBus(1) == 0)            // 지정한 버스(PCI)가 초기화 되었는지를 확인한다
            {
                if (CAxtLib.AxtOpenDeviceAuto(1) == 0)          // 새로운 베이스보드를 자동으로 통합라이브러리에 추가한다
                {
                    MessageBox.Show("보드 초기화 실패 입니다. 확인 후 다시 실행 시켜 주세요");

                    return false;
                }
            }

            if (CAxtCAMCFS20.CFS20IsInitialized() == 0)             // 모듈을 사용할 수 있도록 라이브러리가 초기화되었는지 확인한다
            {
                if (CAxtCAMCFS20.InitializeCAMCFS20(1) == 0)        // 모듈을 초기화한다. 열려있는 모든베이스보드에서 모듈을 검색하여 초기화한다
                {
                    MessageBox.Show("모듈 초기화 실패 입니다. 확인 후 다시 실행 시켜 주세요");

                    return false;
                }
            }

            m_stDeviceInfo.nFirstAxisNo = 0;
            m_nModuleAxis = 0;


            CAxtCAMCFS20.CFS20get_axis_info(m_stDeviceInfo.nFirstAxisNo,
                ref m_stDeviceInfo.nAxtBoardNo,
                ref m_stDeviceInfo.nModulePos,
                ref m_stDeviceInfo.uModuleID,
                ref m_stDeviceInfo.nAxisPos);

            //CAxtCAMCFS20.CFS20get_boardno(0xfebe0000);
            //CAxtKeLib.AxtModuleReadByte(0, 0, 0);
            //CAxtKeLib.AxtModuleReadByte(0, 0, 2);
            //CAxtKeLib.AxtModuleReadByte(0, 0, 4);
            //CAxtCAMCFS20.CFS20get_axisno(0, 0);

            //CAxtCAMCFS20.CFS20get_moveunit_perpulse(0);
            //CAxtCAMCFS20.CFS20get_startstop_speed(0);

            //CAxtCAMCFS20.CFS20get_enc_input_method(0);
            //CAxtCAMCFS20.CFS20get_pulse_out_method(0);

            CAxtCAMCFS20.CFS20set_output_bit(0, 0);
            CAxtCAMCFS20.CFS20set_output_bit(1, 0);

            CAxtCAMCFS20.CFS20set_pulse_out_method(0, 0x06);
            CAxtCAMCFS20.CFS20set_pend_limit_level(1, 0x00);
            CAxtCAMCFS20.CFS20set_nend_limit_level(1, 0x00);

            CAxtCAMCFS20.CFS20set_alarm_level(1, 0x00);

            CAxtCAMCFS20.CFS20start_move(0, 79321.000000, 30000.000000, 60000.000000);
            //CAxtCAMCFS20.CFS20start_move(1, -96927.000000, 30000.000000, 60000.000000);

            return true;
        }
    }
}
