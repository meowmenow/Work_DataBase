using Abonentuzik.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Abonentuzik
{
    /// <summary>
    /// Логика взаимодействия для AddEditForm.xaml
    /// </summary>
    public partial class AddEditForm : Window
    {
        public AddEditForm()
        {
            InitializeComponent();
        }

        AbonentzContext _db = new AbonentzContext();
        Abonent _abonent;
        OpenFileDialog open = new OpenFileDialog();

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

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (tbFio.Text.Length == 0) errors.AppendLine("Введите фамилию");
            if (cbGender.Text != "Муж" && cbGender.Text != "Жён") errors.AppendLine("Введите пол Муж/Жён");
            if (tbInn.Text.Length != 0)
                if (tbInn.Text.Length != 12 || double.TryParse(tbInn.Text, out double x) == false)
                    errors.AppendLine("Неправильный ИНН");

            //if (dbPhone.Text.Length != 0)
            //    if (dbPhone.Text.Length != 10 || double.TryParse(dbPhone.Text, out double y) == false)
            //    errors.AppendLine("Неправильный номер");

            //DateTime dt = DateTime.Now;
            //DateTime dp = Convert.ToDateTime(dpAge.SelectedDate);
            //int yt=dt.Year;
            //int yp = dp.Year;
            //if (yt - yp < 18)
            //{
            //    errors.AppendLine("ТЫ КОГДА РОДИЛСЯ ТО А?!");
            //}

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            try
            {
                if (open.SafeFileName.Length != 0)
                {
                    string newNamePhoto = Directory.GetCurrentDirectory() + "\\image\\" + open.SafeFileName;
                    _abonent.Photo = open.SafeFileName;
                }
            }
            catch { }

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

        private void Otminet_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnAddPhoto_Click(object sender, RoutedEventArgs e)
        {
            open.Filter = "Все файлы |*.*| Файлы *.jpg|*.jpg";
            open.FilterIndex = 2;
            if (open.ShowDialog()==true)
            {
                BitmapImage photoImage = new BitmapImage(new Uri(open.FileName));
                imgPhoto.Source = photoImage;
            }
        }
    }
}
