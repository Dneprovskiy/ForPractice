using OnlineStore.Entity;
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
using System.Windows.Threading;

namespace OnlineStore
{
    /// <summary>
    /// Логика взаимодействия для AdministratorWindow.xaml
    /// </summary>
    public partial class AdministratorWindow : Window
    {
        public Registration reg;
        public Registration[] registrations;
        EntitiesOnlineStore db;

        PageEntityUsers entityUsers;
        public AdministratorWindow(int id)
        {
            InitializeComponent();
            IdUsers.Text = id.ToString();
            entityUsers = new PageEntityUsers(this);
            frameDataGrid.Navigate(entityUsers);
            db = new EntitiesOnlineStore();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Autorization autorization = new Autorization();
            autorization.Show();
            this.Close();
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            WindowRegistrationUsers windowRegistrationUsers = new WindowRegistrationUsers();
            windowRegistrationUsers.ShowDialog();
        }

        private void editBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Данная функция пока что не работает", "Внимание!");
        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            db = new EntitiesOnlineStore();
            try
            {
                MessageBoxResult result = MessageBox.Show("Вы уверены что хотите удалить этого пользоватлея", "Внимание!", MessageBoxButton.YesNo);

                if (result == MessageBoxResult.Yes)
                {
                    var removedUser = db.Registrations.Where(x => x.Registartion_id == reg.Registartion_id).FirstOrDefault();
                    db.Registrations.Remove(removedUser);
                    db.SaveChanges();
                    MessageBox.Show("Пользователь успешно удалён", "Внимание!");
                    frameDataGrid.Navigate(new PageEntityUsers(this));
                }
                
            }
            catch
            {
                MessageBox.Show("Выберите пользоваетля которого хотите удалить","Внимание!");
            }
        }

        private void searchTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            registrations = db.Registrations.ToArray();
            registrations = FindUser(registrations);
            entityUsers.dataGridUsers.ItemsSource = registrations;
        }

        private Registration[] FindUser(Registration[] reg)
        {
            if (searchTB.Text != null)
            {
                reg = reg.Where(x => x.FirstName.ToLower()
                .Contains(searchTB.Text.ToLower())).ToArray();
            }
            return reg;
        }
    }
}
