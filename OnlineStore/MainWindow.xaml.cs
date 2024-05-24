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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace OnlineStore
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        public MainWindow()
        {
            InitializeComponent();
            timer.Interval = TimeSpan.FromSeconds(3);
            timer.Tick += timer_tick;
            timer.Start();

            canvas.Width = 1;
            canvas.Height = 1;
            CreateDots();
            StartAnimation();
        }

        public void timer_tick (object sender, EventArgs e)
        {
            Autorization autorization = new Autorization();
            autorization.Show();
            this.Close();
            timer.Stop();
        }

        private void CreateDots()
        {
            double centerX = canvas.Width / 2;
            double centerY = canvas.Height / 2;
            double radius = 25;

            for (int i = 0; i < 8; i++)
            {
                Ellipse dot = new Ellipse()
                {
                    Width = 10,
                    Height = 10,
                    Fill = Brushes.Black
                };

                canvas.Children.Add(dot);

                double angle = i * Math.PI / 4;
                double x = centerX + radius * 1.5 * Math.Cos(angle);
                double y = centerY + radius * 1.5* Math.Sin(angle);

                Canvas.SetLeft(dot, x - dot.Width / 2);
                Canvas.SetTop(dot, y - dot.Height / 2);
            }
        }

        private void StartAnimation()
        {
            DoubleAnimation animation = new DoubleAnimation()
            {
                From = 0,
                To = 360,
                Duration = TimeSpan.FromSeconds(3),
                RepeatBehavior = RepeatBehavior.Forever
            };
            RotateTransform rotateTransform = new RotateTransform();
            canvas.RenderTransform = rotateTransform;
            rotateTransform.BeginAnimation(RotateTransform.AngleProperty, animation);
        }
    
    }
}
