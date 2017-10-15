using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Wpf.inital
{
    class MakeButton
    {
        public Button loadImageButton { get; }
        public Button HelloButton { get; }
        public Button grayConvertButton { get; }
        public Button oooo { get; }
        public Button cccc { get; }
        public Button tm { get; }

        public MakeButton()
        {
            loadImageButton = new Button();
            loadImageButton.Content = " 파일 오픈";
            loadImageButton.Height = 30;

            HelloButton = new Button();
            HelloButton.Content = "검사 이미지";
            HelloButton.Height = 30;

            grayConvertButton = new Button();
            grayConvertButton.Content = " Gray Convert Button ";
            grayConvertButton.Height = 30;

            oooo = new Button();
            oooo.Content = "Otsu";
            oooo.Height = 30;

            cccc = new Button();
            cccc.Content = "Edge Detect";
            cccc.Height = 30;

            tm = new Button();
            tm.Content = "Template Matching";
            tm.Height = 30;
        }

    }
}
