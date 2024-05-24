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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OnlineStore
{
    /// <summary>
    /// Логика взаимодействия для PageEntityUsers.xaml
    /// </summary>
    public partial class PageEntityUsers : Page
    {
        Entity.EntitiesOnlineStore db;

        AdministratorWindow administrator;
        public PageEntityUsers(AdministratorWindow administrator)
        {
            InitializeComponent();
            this.administrator = administrator;
            db = new Entity.EntitiesOnlineStore();
            dataGridUsers.ItemsSource = db.Registrations.ToList();
        }

        private void dataGridUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            administrator.reg = (Entity.Registration)dataGridUsers.SelectedItem;
        }
    }
}
