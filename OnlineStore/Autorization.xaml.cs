using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.Entity;

namespace OnlineStore
{
    /// <summary>
    /// Логика взаимодействия для Autorization.xaml
    /// </summary>
    public partial class Autorization : Window
    {
        Entity.EntitiesOnlineStore db;
        int invalidAttemptionCount = 0;

        private PasswordBox passwordBox;
        private TextBox textBoxPassword;
        public Autorization()
        {
            InitializeComponent();
            db = new Entity.EntitiesOnlineStore();
            passwordBox = PasswordPB;
            textBoxPassword = PasswordTB;
        }

        private void Authorization_Click(object sender, RoutedEventArgs e)
        {
            db = new Entity.EntitiesOnlineStore();

            if (Login.Text != "" && Login.Text != " " && ((PasswordTB.Text != "" && PasswordTB.Text != " ")
                || PasswordPB.Password != "" && PasswordPB.Password != " ")
                    && Login.Text != string.Empty && (PasswordTB.Text != string.Empty || PasswordPB.Password != string.Empty))
            {
                var curentUser = db.Registrations.Where(x => x.Logins == Login.Text).FirstOrDefault();
                if (db.Registrations.Any(x => x.Logins == Login.Text && (x.Passwords == PasswordTB.Text
                    || x.Passwords == PasswordPB.Password)))
                {
                    if (curentUser.BlockedUtil == null || curentUser.BlockedUtil.Value < DateTime.Now)
                    {
                        curentUser.BlockedUtil = null;
                        db.SaveChanges();
                        var autorization = db.Registrations.FirstOrDefault(x => x.Logins == Login.Text
                        && (x.Passwords == PasswordTB.Text || x.Passwords == PasswordPB.Password));
                        switch (autorization.JobTitle_id)
                        {
                            case 1: AdministratorWindow administrator = new AdministratorWindow(curentUser.Registartion_id);
                                administrator.User.Text = curentUser.FirstName + " " + curentUser.SurName + " " + curentUser.LastName; ;
                                administrator.Show();
                                this.Close();
                                break;
                            case 2: SalesmanWindow salesman = new SalesmanWindow(curentUser.Registartion_id);
                                salesman.User.Text = curentUser.FirstName + " " + curentUser.SurName + " " + curentUser.LastName; ;
                                salesman.Show();
                                this.Close();
                                break;
                            case 3: WorkerWindow worker = new WorkerWindow(curentUser.Registartion_id);
                                worker.User.Text = curentUser.FirstName + " " + curentUser.SurName + " " + curentUser.LastName;
                                worker.Show();
                                this.Close();
                                break;
                            case 4: CustomerWindow customer = new CustomerWindow(curentUser.Registartion_id);
                                customer.User.Text = curentUser.FirstName + " " + curentUser.SurName + " " + curentUser.LastName;
                                customer.Show();
                                this.Close();
                                break;
                        }
                    }
                    else
                    {
                        MessageBox.Show("В данный момент вход невозможен, подождите и попробуйте позже", "Внимание!");
                    }
                }
                else
                {
                    MessageBox.Show("Такого пользоватлея не сущетсвет", "Внимание!");
                    Exeption();
                }
            }
            else
            {
                MessageBox.Show("Строки не должны быть пустыми", "Внимание!");
                Exeption();
            }
        }

        private void Exeption()
        {
            invalidAttemptionCount++;
            if (invalidAttemptionCount >= 3)
            {
                CaptchaWindow captcha = new CaptchaWindow();
                captcha.Show();
                this.Close();
            }
        }

        private void Registrations_Click(object sender, RoutedEventArgs e)
        {
            RegistrationWindow registrationsWindow = new RegistrationWindow();
            registrationsWindow.Show();
            this.Close();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void VisiblePasswod_Click(object sender, RoutedEventArgs e)
        {
            PasswordVisability.TogglePasswordVisibility(passwordBox, textBoxPassword, Eye);
        }
    }
}
