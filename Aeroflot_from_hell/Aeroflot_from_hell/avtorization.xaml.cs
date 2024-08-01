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

namespace Aeroflot_from_hell
{
    /// <summary>
    /// Логика взаимодействия для avtorization.xaml
    /// </summary>
    public partial class avtorization : Window
    {
        public avtorization()
        {
            InitializeComponent();
        }

        private void btnEsc_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            txtLogin.Focus();
            Data.Login = false;
        }

        AeroflotEntities db = AeroflotEntities.GetContext();

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {

            var user = from p in db.Logins
                       where p.login1 == txtLogin.Text && p.password == txtPas.Password
                       select p;
            // Если запись найдена
            if (user.Count() == 1)
            {
                // Заполняем информейшн
                Data.Login = true;
                Data.Right = user.First().rights;
                Close();
            }
            else
            {
                MessageBox.Show("Кого вы пытаетесь обмануть? Вы робот мб? Каптчи накидать?");
                txtLogin.Focus();
            }
        }
    }
}
