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
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        Entity.EntitiesOnlineStore db;
        Entity.Registration reg;

        private PasswordBox passwordBox;
        private TextBox textBoxPassword;
        public RegistrationWindow()
        {
            InitializeComponent();
            passwordBox = PasswordPB;
            textBoxPassword = PasswordTB;
        }

        private void Ready_Click(object sender, RoutedEventArgs e)
        {
            db = new Entity.EntitiesOnlineStore();
            reg = new Entity.Registration();

            string password;
            string loginUser;

            string passwordMain;
            string confirmPasswordMain;

            Autorization autorizationWindow = new Autorization();
            if ((PasswordTB.Text != string.Empty || PasswordPB.Password != string.Empty) && Login.Text != string.Empty 
                && (ConfirmPasswordTB.Text != string.Empty || ConfirmgPasswordPB.Password != string.Empty)
                && FirstName.Text != string.Empty && LastName.Text != string.Empty && SurName.Text != string.Empty
                && ((PasswordTB.Text != "" && PasswordTB.Text != " ") || (PasswordPB.Password != "" && PasswordPB.Password != " ")) 
                && Login.Text != "" && Login.Text != " "
                && FirstName.Text != "" && FirstName.Text != " " && LastName.Text != "" && LastName.Text != " "
                && SurName.Text != "" && SurName.Text != " " 
                && ((ConfirmPasswordTB.Text != "" && ConfirmPasswordTB.Text != " ") || (ConfirmgPasswordPB.Password != "" 
                && ConfirmgPasswordPB.Password != " ")))
            {
                PasswordTB.Text = PasswordPB.Password;
                ConfirmPasswordTB.Text = ConfirmgPasswordPB.Password;

                loginUser = Login.Text;

                var currentLogin = db.Registrations.FirstOrDefault(x => x.Logins == loginUser);
                if (currentLogin == null)
                {
                    if (PasswordPB.Visibility == Visibility.Visible)
                    {
                        passwordMain = PasswordPB.Password;
                        confirmPasswordMain = ConfirmgPasswordPB.Password;
                    }
                    else
                    {
                        passwordMain = PasswordTB.Text;
                        confirmPasswordMain = ConfirmPasswordTB.Text;
                    }

                    if (passwordMain == confirmPasswordMain)
                    {

                        if (Regex.IsMatch(PasswordTB.Text, "^(?=.*[!@#$%^&*<>?])[A-Za-zА-Яа-я0-9!@#$%^&*<>?]{8,}$") 
                            || Regex.IsMatch(PasswordPB.Password, "^(?=.*[!@#$%^&*<>?])[A-Za-zА-Яа-я0-9!@#$%^&*<>?]{8,}$"))
                        {
                            if (PasswordPB.Visibility == Visibility.Visible)
                            {
                                password = PasswordPB.Password;
                            }
                            else
                            {
                                password = PasswordTB.Text;
                            }
                            Entity.Registration autorization = new Entity.Registration
                            {
                                FirstName = FirstName.Text,
                                LastName = LastName.Text,
                                SurName = SurName.Text,
                                Logins = Login.Text,
                                Passwords = password,
                                BlockedUtil = null,
                                JobTitle_id = 4,
                            };
                            db.Registrations.Add(autorization);
                            db.SaveChanges();
                            MessageBox.Show("Регистрация прошла успешно", "Внимание!");
                            autorizationWindow.Show();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Пароль имеет не верный формат", "Внимание!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Пароли не совпадают", "Внимание!");
                    }
                    
                }
                else
                {
                    MessageBox.Show("Пользователь с таким логином уже существует", "Внимание!");
                }
               
            }
            else
            {
                MessageBox.Show("Заполните все данные", "Внимание!");
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Autorization autorization = new Autorization();
            autorization.Show();
            this.Close();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void VisiblePasswod_Click(object sender, RoutedEventArgs e)
        {
            PasswordVisability.TogglePasswordVisibility(passwordBox, textBoxPassword, Eye);
            if (PasswordPB.Visibility == Visibility.Visible)
            {
                ConfirmPasswordTB.Visibility = Visibility.Visible;
                ConfirmgPasswordPB.Visibility = Visibility.Hidden;
                ConfirmPasswordTB.Text = ConfirmgPasswordPB.Password;
            }
            else
            {
                ConfirmgPasswordPB.Visibility = Visibility.Visible;
                ConfirmPasswordTB.Visibility = Visibility.Hidden;
                ConfirmgPasswordPB.Password = ConfirmPasswordTB.Text;
            }
        }

        private void ChekPassword_MouseEnter(object sender, MouseEventArgs e)
        {
            string passwordPB = PasswordPB.Password;
            string passwordTB = PasswordTB.Text;

            if (Regex.IsMatch(passwordPB, "[А-ЯA-Z]") || Regex.IsMatch(passwordTB, "[А-ЯA-Z]"))
            {
                ImageCheck1.Source = new BitmapImage(new Uri("Image\\Chek.png", UriKind.Relative));
            }
            else
            {
                ImageCheck1.Source = new BitmapImage(new Uri("Image\\Cross.png", UriKind.Relative));
            }

            if (Regex.IsMatch(passwordPB, "[^a-zA-Z0-9а-яА-Я]") || Regex.IsMatch(passwordTB, "[^a-zA-Z0-9а-яА-Я]"))
            {
                ImageCheck2.Source = new BitmapImage(new Uri("Image\\Chek.png", UriKind.Relative));
            }
            else
            {
                ImageCheck2.Source = new BitmapImage(new Uri("Image\\Cross.png", UriKind.Relative));
            }

            if (Regex.IsMatch(passwordPB, @"\d") || Regex.IsMatch(passwordTB, @"\d"))
            {
                ImageCheck3.Source = new BitmapImage(new Uri("Image\\Chek.png", UriKind.Relative));
            }
            else
            {
                ImageCheck3.Source = new BitmapImage(new Uri("Image\\Cross.png", UriKind.Relative));
            }

            if (passwordPB.Length >= 8 || passwordTB.Length >= 8)
            {
                ImageCheck4.Source = new BitmapImage(new Uri("Image\\Chek.png", UriKind.Relative));
            }
            else
            {
                ImageCheck4.Source = new BitmapImage(new Uri("Image\\Cross.png", UriKind.Relative));
            }
        }
    }
}
