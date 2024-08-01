using Abonentuzik.Models;
using Microsoft.EntityFrameworkCore;
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

namespace Abonentuzik
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        public Authorization()
        {
            InitializeComponent();
        }

        DispatcherTimer _timer;
        int _countLogin = 1;

        private void Window_Activated(object sender, EventArgs e)
        {
            tbLogin.Focus();
            _timer = new DispatcherTimer();
            _timer.Interval = new TimeSpan(0, 0, 10);
            _timer.Tick += new EventHandler(timer_Tick);
        }

        void GetCaptcha()
        {
            string masChar = "QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm" + "lpoiuytrewq1234567890";
            string captcha = " ";
            Random rnd = new Random();
            for (int i = 1; i <= 6; i++)
            {
                captcha = captcha + masChar[rnd.Next(0, masChar.Length)];
            }
            grid.Visibility = Visibility.Visible;
            txtCaptcha.Text = captcha;
            tbCaptcha.Text = null;
            txtCaptcha.LayoutTransform = new RotateTransform(rnd.Next(-15, 15));
            line.X1 = 10;
            line.Y1 = rnd.Next(10, 40);
            line.X2 = 280;
            line.Y2 = rnd.Next(10, 40);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            stackPanel.IsEnabled = true;
        }

        private void btnEsc_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnGuest_Click(object sender, RoutedEventArgs e)
        {
            Data.Login = true;
            Data.UserSurname = "Гость";
            Data.UserName = " ";
            Data.UserPatronymic = " ";
            Data.Right = "Клиент";
            Close();
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            using (AbonentzContext _db = new AbonentzContext())
            {
                var user = _db.Users.Where(user => user.UserLogin == tbLogin.Text && user.UserPassword == tbPas.Password);
                if (user.Count() == 1 && txtCaptcha.Text == tbCaptcha.Text)
                {
                    Data.Login = true;
                    Data.UserSurname = user.First().UserSurname;
                    Data.UserName = user.First().UserName;
                    Data.UserPatronymic = user.First().UserPatronymic;
                    _db.Roles.Load();
                    Data.Right = user.First().UserRoleNavigation.RoleName;
                    Close();
                }
            }
        }

    }
}
