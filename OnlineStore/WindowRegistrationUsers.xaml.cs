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
    /// Логика взаимодействия для WindowRegistrationUsers.xaml
    /// </summary>
    public partial class WindowRegistrationUsers : Window
    {
        Entity.EntitiesOnlineStore db;
        Entity.Registration reg;

        private PasswordBox passwordBox;
        private TextBox textBoxPassword;

        int selectedUserGroup = 0;
        public WindowRegistrationUsers()
        {
            InitializeComponent();
            passwordBox = PasswordPB;
            textBoxPassword = PasswordTB;
        }

        private void ready_Click(object sender, RoutedEventArgs e)
        {
            db = new Entity.EntitiesOnlineStore();
            reg = new Entity.Registration();

            string password;
            string loginUser;

            Autorization autorizationWindow = new Autorization();
            if ((PasswordTB.Text != string.Empty || PasswordPB.Password != string.Empty) && Login.Text != string.Empty
                && FirstName.Text != string.Empty && LastName.Text != string.Empty && SurName.Text != string.Empty
                && ((PasswordTB.Text != "" && PasswordTB.Text != " ") || (PasswordPB.Password != "" && PasswordPB.Password != " "))
                && Login.Text != "" && Login.Text != " "
                && FirstName.Text != "" && FirstName.Text != " " && LastName.Text != "" && LastName.Text != " "
                && SurName.Text != "" && SurName.Text != " " || selectGroupUserCB.SelectedItem != null)
            {
                PasswordTB.Text = PasswordPB.Password;

                loginUser = Login.Text;

                var currentLogin = db.Registrations.FirstOrDefault(x => x.Logins == loginUser);
                if (currentLogin == null)
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

                        if (workerCBI.IsSelected)
                        {
                            selectedUserGroup = 2;
                        }

                        if (sellerCBI.IsSelected)
                        {
                            selectedUserGroup = 3;
                        }

                        if (buyersCBI.IsSelected)
                        {
                            selectedUserGroup = 4;
                        }

                        Entity.Registration autorization = new Entity.Registration
                        {
                            FirstName = FirstName.Text,
                            LastName = LastName.Text,
                            SurName = SurName.Text,
                            Logins = Login.Text,
                            Passwords = password,
                            BlockedUtil = null,
                            JobTitle_id = selectedUserGroup,
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
                    MessageBox.Show("Пользователь с таким логином уже существует", "Внимание!");
                }
            }
            else
            {
                MessageBox.Show("Заполните все данные", "Внимание!");
            }
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void visiblePasswod_Click(object sender, RoutedEventArgs e)
        {
            PasswordVisability.TogglePasswordVisibility(passwordBox, textBoxPassword, Eye);
        }

        private void chekPassword_MouseEnter(object sender, MouseEventArgs e)
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
