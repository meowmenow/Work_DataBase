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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DataBaseHell
{
    public static class Data
    {
        public static Abonent? abonent;
    }
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainInfo_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDBInDataGrid();

        }
    
           void LoadDBInDataGrid()
           {
                using (AboltusContext _db = new AboltusContext())
                {
                        int selectedIndex = MainInfo.SelectedIndex;
                        MainInfo.ItemsSource = _db.Abonents.ToList();
                        if (selectedIndex != -1)
                        {
                                if (selectedIndex == MainInfo.Items.Count) selectedIndex--;
                                MainInfo.SelectedIndex = selectedIndex;
                                MainInfo.ScrollIntoView(MainInfo.SelectedItem);
                        }
                            MainInfo.Focus();
                }
           }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            Data.abonent = null;
            FormBlank f = new FormBlank();
            f.Owner = this;
            f.ShowDialog();
            LoadDBInDataGrid();
        }

        private void redact_Click(object sender, RoutedEventArgs e)
        {
            if (MainInfo.SelectedIndex != null) 
            {
                Data.abonent=(Abonent)MainInfo.SelectedItem;
                FormBlank f = new FormBlank();
                f.Owner = this;
                f.ShowDialog();
                LoadDBInDataGrid();
            }
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result;
            result = MessageBox.Show("Удалить запись?",
                                     "Удаление записи",
                                     MessageBoxButton.YesNo,
                                     MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    Abonent row = (Abonent)MainInfo.SelectedItem;
                    if (row != null)
                    {
                        using (AboltusContext _db = new AboltusContext())
                        {
                            _db.Abonents.Remove(row);
                            _db.SaveChanges();
                        }
                        LoadDBInDataGrid();
                    }
                }
                catch
                {
                    MessageBox.Show("Ошибка удаления");
                }
            }
            else MainInfo.Focus();
        }
    }
}
