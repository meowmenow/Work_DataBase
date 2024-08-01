using CyberKotleta.Models;
using Microsoft.IdentityModel.Tokens;
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

namespace CyberKotleta
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDBInListView();
        }

        void LoadDBInListView()
        {
            using (ESportikContext _db = new ESportikContext())
            {
                int selectedIndex = listView1.SelectedIndex;
                listView1.ItemsSource = _db.CyberAthletes.ToList();

                if (selectedIndex != -1)
                {
                    if (selectedIndex == listView1.Items.Count) selectedIndex--;
                    listView1.SelectedIndex = selectedIndex;
                    listView1.ScrollIntoView(listView1.SelectedIndex);
                }
                listView1.Focus();
            }
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            Data.cyberAthlete = null;
            AddEdit f = new AddEdit();
            f.Owner = this;
            f.ShowDialog();
            LoadDBInListView();
        }

        private void redact_Click(object sender, RoutedEventArgs e)
        {
            if (listView1.SelectedIndex != null)
            {
                Data.cyberAthlete = (CyberAthlete)listView1.SelectedItem;
                AddEdit f = new AddEdit();
                f.Owner = this;
                f.ShowDialog();
                LoadDBInListView();
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
                    // CyberAthlete row = (CyberAthlete)listView1.SelectedItem;
                    CyberAthlete rol =(CyberAthlete)listView1.SelectedItem;
                    String value = rol.CyberFio;
                    if (rol != null)
                    {
                        using (ESportikContext _db = new ESportikContext())
                        {
                         _db.CyberAthletes.Remove(rol);
                            _db.SaveChanges();
                        }
                        LoadDBInListView();
                    }
                }
                catch
                {
                    MessageBox.Show("Ошибка удаления");
                }
            }
            else listView1.Focus();
        }

        private void tbFind_TextChanged(object sender, TextChangedEventArgs e)
        {
            List<CyberAthlete> listItem = new List<CyberAthlete>();
            var filtered = listItem.Where(p => p.CyberFio.Contains(tbFind.Text));
            if (filtered.Count() >0 )
            {
                var item = filtered.First();
                listView1.SelectedItem = item;
                listView1.ScrollIntoView(item);
            }
        }

        private void tbFiltered_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbFiltered.Text.IsNullOrEmpty() == false)
            {
                using (ESportikContext _db = new ESportikContext())
                {
                    var filtered = _db.CyberAthletes.Where(p => p.CyberFio.Contains(tbFiltered.Text));
                    listView1.ItemsSource = filtered.ToList();
                }
            }
            else
            {
                LoadDBInListView();
            }   
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            Authorization f = new Authorization();
            f.ShowDialog();
            if (Data.Login == false) Close();
            if (Data.Right == "Админ") ;
            else
            {
                btnDelete.IsEnabled = false;
            }
            this.Title = this.Title + " " + Data.UserFio + " (" + Data.Right + ")";
        }
    }
    

}
