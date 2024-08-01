using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
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

namespace Aeroflot_from_hell
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        AeroflotEntities db= AeroflotEntities.GetContext();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Получаем доступ к контексту данных
            db.Flight_details.Load();
            // Загружаем таблицу в ДатаГрид без отслеживания изменения контекста
            // DataGrid1.ItemsSource = db.Flight_details.ToList();
            // Загружаем таблицу в DataGrid с отслеживания изменения контекста
            Aerohell.ItemsSource= db.Flight_details.Local.ToBindingList();
            // Открываем окно авторизации
            avtorization w = new avtorization();
            w.ShowDialog();
            // При отказе от авторизации выходим из программы
            if (Data.Login == false) Close();
            // Устанавливаем права доступа
            string right;
            if (Data.Right == "A") right = "Администратор";
            else
            {
                right = "Пользователь";
                // Я ЗАПРЕЩАЮ!
                delete.IsEnabled = false;
            }
           
        }

        private void add_click(object sender, RoutedEventArgs e)
        {
            Flight_registr f = new Flight_registr();
            f.ShowDialog();
            Aerohell.Focus();
        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {
            int indexRow = Aerohell.SelectedIndex;
            if (indexRow != -1)
            {

            }
        }

        private void edit_click(object sender, RoutedEventArgs e)
        {
            int indexRow = Aerohell.SelectedIndex;
            if (indexRow != -1)
            {
                // Получает ключ текущей записи
                Flight_detail row = (Flight_detail)Aerohell.Items[indexRow];
                Data.id = row.id;
                // Открываем форму "редактирования"
                edit f = new edit();
                f.ShowDialog();
                //Обновляем таблицу 
                Aerohell.Items.Refresh();
                Aerohell.Focus();
            }
        }

        private void delete_click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result;
            result = MessageBox.Show("Удалить запись?", "Удаление записи", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    Flight_detail row = (Flight_detail)Aerohell.SelectedItems[0];
                    db.Flight_details.Remove(row);
                    db.SaveChanges();
                }
                catch (ArgumentOutOfRangeException)
                {
                    MessageBox.Show("Выберите запись");
                }
            }
        }

        private void search_click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < Aerohell.Items.Count; i++)
            {
                var row = (Flight_detail)Aerohell.Items[i];
                string findContent = row.Destination;
                try
                {
                    if (findContent != null && findContent.Contains(gde.Text))
                    {
                        object item = Aerohell.Items[i];
                        Aerohell.SelectedItem = item;
                        Aerohell.ScrollIntoView(item);
                        Aerohell.Focus();
                        break;
                    }
                }
                catch { }

            }
        }


        List<Flight_detail> _flight;
        private void filtered_click(object sender, RoutedEventArgs e)
        {
            _flight = db.Flight_details.ToList();
            var filtered = _flight.Where(_flight => _flight.Flight == kto.Text);
            Aerohell.ItemsSource = filtered;
        }

        private void flight_sql(object sender, RoutedEventArgs e)
        {
            // Простой запрос
            var destination = db.Database.SqlQuery<Flight_detail>("SELECT * FROM [Flight details] WHERE Destination = 'Moon' ");
            Aerohell.ItemsSource = destination.ToList();
        }

        private void aircraft_sql(object sender, RoutedEventArgs e)
        {
            // Запросы с параметром - using System.Data.Sqlclient;
            SqlParameter aircraft = new SqlParameter();

            aircraft.ParameterName = "@surname";
            aircraft.Value = sql_request.Text;

            var sql = db.Database.SqlQuery<Flight_detail>("SELECT * FROM Flight_detail WHERE Aircraft_type = @aircraft", aircraft);
            Aerohell.ItemsSource = sql.ToList();

        }
    }
}
