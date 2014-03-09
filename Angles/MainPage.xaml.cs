using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.Diagnostics;

namespace Angles
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            Touch.FrameReported += new TouchFrameEventHandler(Touch_FrameReported);
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            int inp = random.Next(1, 360);
            inpTextBlock.Text = "Tap: " + inp.ToString() + " degrees";
        }

        
        void Touch_FrameReported(object sender, TouchFrameEventArgs e)
        {

            double x = e.GetTouchPoints(this)[0].Position.X;
            double y = e.GetTouchPoints(this)[0].Position.Y;
            if (y > 570)
                return;
            //Debug.WriteLine(x.ToString() + " " + y.ToString());
            string msg = "";
            if (x == 230 && y == 370)
                msg = "Incoorect co-ordinates, indeterminant angle.";
            double numerator = -230.0 + x;
            double denominator = Math.Sqrt(((230.0 - x) * (230.0 - x)) + ((370.0 - y) * (370.0 - y)));
            //Debug.WriteLine(numerator.ToString() + " " + denominator.ToString());
            double theta = Math.Acos(numerator/denominator);
            theta = (theta * 180) / Math.PI;
            if (y > 370)
                theta = 360 - theta;
            theta = Math.Round(theta,0);
            msg = theta.ToString();
            opTextBlock.Text = "You taped: " + msg + " degrees";
            //Debug.WriteLine(msg);
        }

        private void goButton_Click(object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            int inp = random.Next(0, 360);
            inpTextBlock.Text = "Tap: " + inp.ToString() + " degrees";
            opTextBlock.Text = "";
        }
    }
}