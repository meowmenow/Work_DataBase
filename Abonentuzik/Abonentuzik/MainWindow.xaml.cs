using Abonentuzik.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Abonentuzik
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
            LoadDBInDataGrid();
            LoadDBInListView();
        }

        void LoadDBInListView()
        {
            using (AbonentzContext _db = new AbonentzContext())
            {
                int selectedIndex = listView1.SelectedIndex;
                listView1.ItemsSource = _db.Abonents.ToList();
                if (selectedIndex != -1)
                {
                    if (selectedIndex == listView1.Items.Count) selectedIndex--;
                    listView1.SelectedIndex = selectedIndex;
                    listView1.ScrollIntoView(listView1.SelectedItem);
                }
                listView1.Focus();
            }
        }

        void LoadDBInDataGrid()
        {
            using (AbonentzContext _db = new AbonentzContext())
            {
                int selectedIndex = listView1.SelectedIndex;
                listView1.ItemsSource = _db.Abonents.ToList();
                if (selectedIndex != -1)
                {
                    if (selectedIndex == listView1.Items.Count) selectedIndex--;
                    listView1.SelectedIndex = selectedIndex;
                    listView1.ScrollIntoView(listView1.SelectedItem);
                }
                listView1.Focus();
            }
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            Data.abonent = null;
            AddEditForm f = new AddEditForm();
            f.Owner = this;
            f.ShowDialog();
            LoadDBInListView();
        }

        private void redact_Click(object sender, RoutedEventArgs e)
        {
            if (listView1.SelectedItem != null)
            {
                Data.abonent = (Abonent)listView1.SelectedItem;
                AddEditForm f = new AddEditForm();
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
                    Abonent row = (Abonent)listView1.SelectedItem;
                    String value = row.Fio;
                    if (row != null)
                    {
                        using (AbonentzContext _db = new AbonentzContext())
                        {
                            _db.Abonents.Remove(row);
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

        private void search_Click(object sender, RoutedEventArgs e)
        {
            List<Abonent> listItem = (List<Abonent>)listView1.ItemsSource;
            var filtered = listItem.Where(p => p.Fio.Contains(tbFind.Text));
            if (filtered.Count() > 0)
            {
                var item = filtered.First();
                listView1.SelectedItem = item;
                listView1.ScrollIntoView(item);
                listView1.Focus();
            }
        }

        private void btnFiltered_Click(object sender, RoutedEventArgs e)
        {
            if (tbFiltered.Text.IsNullOrEmpty() == false)
            {
                using (AbonentzContext _db = new AbonentzContext())
                {
                    var filtered = _db.Abonents.Where(p => p.Fio == tbFiltered.Text);
                    listView1.ItemsSource = filtered.ToList();
                }
            }
            else
            {
                LoadDBInDataGrid();
            }
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            Authorization f = new Authorization();
            f.ShowDialog();
            if (Data.Login == false) Close();
            if (Data.Right == "Администратор") ;
            else
            {
                btnDelete.IsEnabled = false;
            }
            this.Title = this.Title + " " + Data.UserSurname + " " + Data.UserName + " (" + Data.Right + ")";
        }

        private void tbFind_TextChanged(object sender, TextChangedEventArgs e)
        {
            List<Abonent> listItem = (List<Abonent>)listView1.ItemsSource;
            var filtered = listItem.Where(p=>p.Fio.Contains(tbFind.Text));
            if (filtered.Count() > 0)
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
                using (AbonentzContext _db = new AbonentzContext())
                {
                    var filtered = _db.Abonents.Where(p=>p.Fio.Contains(tbFiltered.Text));
                    listView1.ItemsSource = filtered.ToList();
                }
            }
            else
            {
                LoadDBInListView();
            }
        }
    }
}
