using CyberKotleta.Models;
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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CyberKotleta
{
    /// <summary>
    /// Логика взаимодействия для AddEdit.xaml
    /// </summary>
    public partial class AddEdit : Window
    {
        public AddEdit()
        {
            InitializeComponent();
        }

        ESportikContext _db = new ESportikContext();
        CyberAthlete _cyberAthlete;
        OpenFileDialog open = new OpenFileDialog();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (Data.cyberAthlete == null)
            {
                this.Title = "Добавить запись";
                btnadd.Content = "Добавить";
                _cyberAthlete = new CyberAthlete();
            }
            else
            {
                this.Title = "Изменение записи";
                btnadd.Content = "Изменить";
                _cyberAthlete = _db.CyberAthletes.Find(Data.cyberAthlete.Id);
            }
            this.DataContext = _cyberAthlete;
        }

        private void btnadd_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (tbFio_sportik.Text.Length == 0) errors.AppendLine("Введите фамилию киберспортика");
            if (tbFio_Coach.Text.Length == 0) errors.AppendLine("Введите фамилию киберспортика");
            if (cbGender.Text != "Муж" && cbGender.Text != "Жён") errors.AppendLine("Введите пол Муж/Жена");
            if (tbCountry.Text.Length == 0) errors.AppendLine("Введите страну киберспортика");
            if (tbDPR.Text.Length == 0) errors.AppendLine("Введите DPR");
            if (tbIMPACT.Text.Length == 0) errors.AppendLine("Введите IMPACT");
            if (tbADR.Text.Length == 0) errors.AppendLine("Введите ADR");
            if (tbKPR.Text.Length == 0) errors.AppendLine("Введите KPR");
            if (tbKAST.Text.Length == 0) errors.AppendLine("Введите KAST");

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
                    File.Copy(open.FileName, newNamePhoto, true);
                    _cyberAthlete.Photo = open.SafeFileName;
                }
            } catch { }

            try
            {
                if (Data.cyberAthlete == null)
                {
                    _db.CyberAthletes.Add(_cyberAthlete);
                    _db.SaveChanges();
                }
                else
                {
                    _db.SaveChanges();
                }
                this.Close();
            }
            catch { }

        }

        private void addPhoto_Click(object sender, RoutedEventArgs e)
        {
            open.Filter = "Все файлы |*.*|Файлы *.jpg|*.jpg";
            open.FilterIndex = 2;
            if (open.ShowDialog() == true)
            {
                BitmapImage photoImage = new BitmapImage(new Uri(open.FileName));
                imgPhoto.Source = photoImage;
            }
        }

        private void Otminet_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
