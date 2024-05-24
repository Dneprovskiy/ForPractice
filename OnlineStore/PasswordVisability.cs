using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace OnlineStore
{
    public class PasswordVisability
    {
        public static void TogglePasswordVisibility(PasswordBox passwordBox, TextBox textBox, Image eye)
        {
            if (passwordBox.Visibility == Visibility.Visible)
            {
                ShowPassword(passwordBox, textBox, eye);
            }
            else
            {
                HidePassword(passwordBox, textBox, eye);
            }
        }

        private static void ShowPassword(PasswordBox passwordBox, TextBox textBox, Image eye)
        {
            textBox.Visibility = Visibility.Visible;
            passwordBox.Visibility = Visibility.Hidden;
            eye.Source = new BitmapImage(new Uri("Image\\Eye.png", UriKind.Relative));
            textBox.Text = passwordBox.Password;
        }

        private static void HidePassword(PasswordBox passwordBox, TextBox textBox, Image eye)
        {
            textBox.Visibility = Visibility.Hidden;
            passwordBox.Visibility = Visibility.Visible;
            eye.Source = new BitmapImage(new Uri("Image\\CrossedEye.png", UriKind.Relative));
            passwordBox.Password = textBox.Text;
        }
    }
}
