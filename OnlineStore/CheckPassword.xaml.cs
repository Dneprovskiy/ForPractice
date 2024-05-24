using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для CheckPassword.xaml
    /// </summary>
    public partial class CheckPassword : Window
    {
        RegistrationWindow registration;
        public CheckPassword(RegistrationWindow registration)
        {
            InitializeComponent();

            string passwordPB = registration.PasswordPB.Password;
            string passwordTB = registration.PasswordTB.Text;

            if (Regex.IsMatch(passwordPB, "[A-Z]") || Regex.IsMatch(passwordTB, "[A-Z]"))
            {
                ImageCheck1.Source = new BitmapImage(new Uri("Image\\Chek.png", UriKind.Relative));
            }

            if (Regex.IsMatch(passwordPB, "[^a-zA-Z0-9]") || Regex.IsMatch(passwordTB, "[^a-zA-Z0-9]"))
            {
                ImageCheck2.Source = new BitmapImage(new Uri("Image\\Chek.png", UriKind.Relative));
            }

            if (Regex.IsMatch(passwordPB, @"\d") || Regex.IsMatch(passwordTB, @"\d"))
            {
                ImageCheck3.Source = new BitmapImage(new Uri("Image\\Chek.png", UriKind.Relative));
            }

            this.registration = registration;
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
