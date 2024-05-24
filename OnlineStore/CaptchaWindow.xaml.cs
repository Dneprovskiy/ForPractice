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

namespace OnlineStore
{
    /// <summary>
    /// Логика взаимодействия для CaptchaWindow.xaml
    /// </summary>
    public partial class CaptchaWindow : Window
    {
        int invalidAttemptionCount = 0;
        public CaptchaWindow()
        {
            InitializeComponent();
            string password;
            Captcha.Text = GenerateCaptcha(out password);
        }

        public string GenerateCaptcha(out string captcha)
        {
            CaptchaCanvas.Children.Clear();
            Random random = new Random();
            for (int j = 0; j < 1200; j++)
            {
                Ellipse ellipse = new Ellipse();
                int rnd = random.Next(1, 4);
                ellipse.Height = rnd; ellipse.Width = rnd;
                Brush brus = new SolidColorBrush(Color.FromRgb((byte)random.Next(1, 255), (byte)random.Next(1, 255), (byte)random.Next(1, 233)));
                ellipse.Fill = brus;
                Canvas.SetLeft(ellipse, random.Next(250));
                Canvas.SetTop(ellipse, random.Next(65));
                CaptchaCanvas.Children.Add(ellipse);
            }

            String allowchar = "";
            allowchar = "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z";
            allowchar += "a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,y,z";
            allowchar += "1,2,3,4,5,6,7,8,9,0";
            char[] symbols = { ',' };
            String[] arraySymbols = allowchar.Split(symbols);
            captcha = "";
            string temp = "";
            Random r = new Random();

            for (int i = 0; i < 4; i++)
            {

                temp = arraySymbols[r.Next(0, arraySymbols.Length)];
                captcha += temp;
            }
            return captcha;
        }
    

        private void GenerateCapcha_Click(object sender, RoutedEventArgs e)
        {
            string captcha;
            Captcha.Text = GenerateCaptcha(out captcha);
        }

        private async void Continue_Click(object sender, RoutedEventArgs e)
        {
            if (Captcha.Text == EnterCaptcha.Text)
            {
                Autorization main = new Autorization();
                main.Show();
                this.Close();
            }
            else
            {
                invalidAttemptionCount++;
                MessageBox.Show("Капча введена не верно", "Внимание!");
                if (invalidAttemptionCount >= 3)
                {

                    GenerateCapcha.IsEnabled = false;
                    Continue.IsEnabled = false;

                    int remainingSeconds = 10;

                    while (remainingSeconds > 0)
                    {
                        block.Text = $"До окончания блокировки осталось: {remainingSeconds}";
                        await Task.Delay(1000);
                        remainingSeconds--;
                    }

                    GenerateCapcha.IsEnabled = true;
                    Continue.IsEnabled = true;

                    block.Text = string.Empty;
                }
            }
        }

        private void Captcha_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
        }

        private void Captcha_PreviewDragOver(object sender, DragEventArgs e)
        {
            e.Handled = true;
        }
    }
}

