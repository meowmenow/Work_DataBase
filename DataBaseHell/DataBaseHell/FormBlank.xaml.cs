using DataBaseHell.Models;
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

namespace DataBaseHell
{
    /// <summary>
    /// Логика взаимодействия для FormBlank.xaml
    /// </summary>
    public partial class FormBlank : Window
    {
        public FormBlank()
        {
            InitializeComponent();
        }

        AboltusContext _db = new AboltusContext();
        Abonent _abonent;

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (tbFio.Text.Length ==  0 ) errors.AppendLine("Введите фамилию");
            if (cbGender.Text != "Муж" && cbGender.Text != "Жён") errors.AppendLine("Введите пол Муж/Жён");
            if (tbInn.Text.Length != 0)
                if (tbInn.Text.Length != 12 || double.TryParse(tbInn.Text, out double x) == false)
                    errors.AppendLine("Неправильный ИНН");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            try
            {
                if (Data.abonent == null)
                {
                    _db.Abonents.Add(_abonent);
                    _db.SaveChanges();
                }
                else
                {
                    _db.SaveChanges();
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (Data.abonent == null)
            {
                this.Title = "Добавление записи";
                btnadd.Content = "Добавить";
                _abonent = new Abonent();
            }
            else
            {
                this.Title = "Изменение записи";
                btnadd.Content = "Изменить";
                _abonent = _db.Abonents.Find(Data.abonent.Id);
            }
            this.DataContext = _abonent;

        }

        private void Otminet_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
