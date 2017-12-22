using Microsoft.Toolkit.Uwp.UI.Animations;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace anyDoApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        int sideCount = 5;
        public MainPage()
        {
            this.InitializeComponent();
            
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {

           await animateInHexPattern(circleHolder);
        }


        private async Task animateInHexPattern(FrameworkElement circle)
        {
            double radius = circleHolder.ActualWidth;
            PointCollection pointsToAnimateTo = getHexagonPoints(radius);
            
            double pointAnimDuration = 7 / 6;
            int i = 2;
            
            while (true)
            {
                
                //bool firstTime = false;
                //if (firstTime == false)
                //{
                //    i = 1;
                //    firstTime = true;
                //}
                foreach (var point in pointsToAnimateTo)
                {
                    var offSetX = (float)point.X;
                    var offsetY = (float)point.Y;

                    var scaleSize = (float)i % 8;
                    if (scaleSize ==0)
                    {
                        scaleSize = 1;
                    }

                   //await circleHolder.Offset(offSetX, offsetY, pointAnimDuration)
                   //     .Rotate((float)getAngleInDegrees(i), duration:pointAnimDuration/ (500/300))
                   //     .Scale(scaleSize, 1,(float)circleHolder.ActualWidth/2, (float)circleHolder.ActualHeight/2, duration:pointAnimDuration).StartAsync();

                    await circleHolder.Offset(offSetX, offsetY, pointAnimDuration)
                       .Rotate((float)getAngleInDegrees(i), duration: pointAnimDuration / (500 / 300))
                       .StartAsync();
                    i += 1;
                    
                    
                    
                    
                    
                    
                    
                    
                    //foreach (var child in circleHolder.Children)
                    //{
                    //    if (child is Ellipse)
                    //    {
                    //        await child.Offset(offSetX, offsetY, pointAnimDuration).StartAsync();
                    //    }
                    //}
                    //await myCircle.Offset(offSetX, offsetY, pointAnimDuration).StartAsync();
                    //  await ourCirlce.Offset(offSetX, offsetY, pointAnimDuration).StartAsync();
                    //  await yourCircle.Offset(offSetX, offsetY, pointAnimDuration).StartAsync();
                }
                

            }
                    

                  
        }


        private async Task smoothHexAnimation(FrameworkElement element)
        {
            double radius = element.ActualWidth / 4;
            PointCollection pointsToAnimateTo = getAllPointsSmoothly(radius);

            
            double pointAnimDuration = 1/60/60;
            int i = 20;

            while (true)
            {

               
                foreach (var point in pointsToAnimateTo)
                {
                    var offSetX = (float)point.X;
                    var offsetY = (float)point.Y;

                    
                    var scaleSize = (float)i % 10;
                    if (scaleSize == 0)
                    {
                        scaleSize = 1;
                    }

                    //await circleHolder.Offset(offSetX, offsetY, pointAnimDuration)
                    //     .Rotate((float)getIntervalAngleInDegrees(i%10), duration: pointAnimDuration / (500 / 300))
                    //     .Scale(scaleSize, 1, (float)circleHolder.ActualWidth / 2, (float)circleHolder.ActualHeight / 2, duration: pointAnimDuration).StartAsync();

                    if (false)
                    {
                        await circleHolder.Offset(offSetX, offsetY, pointAnimDuration)
                             .Rotate((float)getIntervalAngleInDegrees(i), duration: pointAnimDuration / (500 / 300))
                              .Scale(scaleSize, 1, (float)circleHolder.ActualWidth / 2, (float)circleHolder.ActualHeight / 2, duration: pointAnimDuration).StartAsync();

                    }
                    else if (true)
                    {
                        await circleHolder.Offset(offSetX, offsetY, pointAnimDuration)
                             .Rotate((float)getIntervalAngleInDegrees(i,60),(float)circleHolder.ActualWidth/2,(float)circleHolder.ActualWidth/2, duration: pointAnimDuration).StartAsync();
                    }

                    else if (false)
                    {
                        await circleHolder.Rotate((float)getIntervalAngleInDegrees(i), duration: pointAnimDuration).StartAsync();
                    }

                    else if (false)
                    {
                        await circleHolder.Rotate((float)getIntervalAngleInDegrees(i,10), duration: pointAnimDuration)
                            .Scale(scaleSize, 1, (float)circleHolder.ActualWidth / 2, (float)circleHolder.ActualHeight / 2, duration: pointAnimDuration)
                            .StartAsync();
                    }
                    else
                    {
                        await circleHolder.Offset(offSetX, offsetY, pointAnimDuration).StartAsync();

                    }


                    i += 1;
                }


            }


        }

        private PointCollection getAllPointsSmoothly(double radius)
        {
            
            List<double> listOfNumbersToUse = new List<double>();
            for (int i = 0; i < 6; i++)
            {
                double[] intervalsToUse = getIntervals(i, i + 1);
                foreach (var item in intervalsToUse)
                {
                    listOfNumbersToUse.Add(item);
                }
                //if (i == 5)
                //{
                //    listOfNumbersToUse.Add(5);
                //}
            }

            List<double> intervalAngles = new List<double>();
            foreach (var item in listOfNumbersToUse)
            {
                double angleToAdd = getIntervalAngleInRadians(item);
                intervalAngles.Add(angleToAdd);

            }

            PointCollection pointsToReturn = getPoints(radius, intervalAngles.ToArray());
            Debug.WriteLine(pointsToReturn.Count);
            return pointsToReturn;
           
        }

        private double[] getIntervals(int a, int b)
        {
            double range = b - a;
            double interval = range / 9;
            List<double> intervalList = new List<double>();
            for (int i = 0; i < 10; i++)
            {
                if (i!=0 && i < 9)
                {
                    double intervalToAdd = a + (i * interval);
                    intervalList.Add(intervalToAdd);
                }

                else if (i == 0)
                {
                    intervalList.Add(a);
                }

                else
                {
                    intervalList.Add(b);
                }

                
                    
            }

            return intervalList.ToArray();

        }

        private PointCollection getHexagonPoints(double radius)
        {
            double[] listOfAngles = getAnglesFromHex();
            PointCollection hexPoints = getPoints(radius, listOfAngles);
            return hexPoints;

        }

        private PointCollection getPoints(double radius, double[] listOfAngles)
        {
            PointCollection pointsToReturn = new PointCollection();
            foreach (var angle in listOfAngles)
            { 
                Point PointToAdd = toCartesian(radius, angle);
                pointsToReturn.Add(PointToAdd);
            }

            return pointsToReturn;
        }

        private Point toCartesian(double r, double theta)
        {
            var x = r * Math.Cos(theta);
            var y = r * Math.Sin(theta);
            return new Point(x, y);
        }

        private double[] getAnglesFromHex()
        {
            
            double[] listOfAngles = new double[6];
            for (int i = 0; i < 6; i++)
            {
                double angleInRadians = getAngleInRadians(i);
                listOfAngles[i] = angleInRadians;
            }

            return listOfAngles;
        }

        private double getAngleInDegrees(int index, int numOfSides = 6)
        {
            return 360 * index / numOfSides;
        }
        
        private double getAngleInRadians(int i)
        {
            double angleInDegrees = getAngleInDegrees(i);
            return (Math.PI * angleInDegrees) / 180;
        }

        private double getIntervalAngleInRadians(double interval)
        {
            double intervalAngleinDegrees = getIntervalAngleInDegrees(interval);
            return (Math.PI * intervalAngleinDegrees) / 180;
        }

        private double getIntervalAngleInDegrees(double interval, int numOfSides = 6)
        {
            return 360 * interval / numOfSides;
        }

        

        private async void smoothButton_Click(object sender, RoutedEventArgs e)
        {
            await smoothHexAnimation(circleHolder);
        }
    }
}
