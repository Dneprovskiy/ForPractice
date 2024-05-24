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
    /// Логика взаимодействия для CustomerWindow.xaml
    /// </summary>
    public partial class CustomerWindow : Window
    {
        private TimeSpan timeElapsed;
        private DispatcherTimer timer;

        Entity.EntitiesOnlineStore db;
        public CustomerWindow(int id)
        {
            InitializeComponent();
            IdUsers.Text = id.ToString();

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        public void Timer_Tick(object sender, EventArgs e)
        {
            db = new Entity.EntitiesOnlineStore();

            timeElapsed = timeElapsed.Add(TimeSpan.FromSeconds(1));
            timeTB.Text = timeElapsed.ToString("mm\\:ss");

            if (timeElapsed.TotalSeconds >= 10)
            {
                timer.Stop();
                MessageBox.Show("Время сенса окончено", "Внимание!");
                int id = Convert.ToInt32(IdUsers.Text);
                var user = db.Registrations.FirstOrDefault(x => x.Registartion_id == id);

                if (user != null)
                {
                    user.BlockedUtil = DateTime.Now.AddMinutes(1);
                }
                db.SaveChanges();

                Autorization autorization = new Autorization();
                autorization.Show();
                this.Close();
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            Autorization autorization = new Autorization();
            autorization.Show();
            this.Close();
        }
    }
}
