using CyberKotleta.Models;
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

namespace CyberKotleta
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            reg = new User();
            this.DataContext = reg;
            cbRole.ItemsSource = _db.Roles.ToList();
            cbRole.DisplayMemberPath = "RoleName";
     
        }

        ESportikContext _db = new ESportikContext();
        User reg;
        Role roles;

        private void Registr_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder error = new StringBuilder();
            if (tbFIO.Text.Length == 0) error.AppendLine("Введите ФИО");
            if (tbLogin.Text.Length == 0) error.AppendLine("Введиите логин");
            if (tbPassword.Text.Length == 0) error.AppendLine("Задайте пароль");
            if (cbRole.Text.Length == 0) error.AppendLine("Какую роль желаете?");
            if (cbRole.Text != "Админ" && cbRole.Text != "Гость") error.AppendLine("Выберите желаемую роль");
            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString());
                return;
            }
            try
            {
                if (Data.reg == null)
                {
                    _db.Users.Add(reg);
                   
                    _db.SaveChanges();

                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void Otmena_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

