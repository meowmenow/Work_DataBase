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
    /// Логика взаимодействия для edit.xaml
    /// </summary>
    public partial class edit : Window
    {
        AeroflotEntities db = new AeroflotEntities();
        Flight_detail p1;

        public edit()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Получаем доступ к контексту данных
            p1 = db.Flight_details.Find(Data.id);
            // Отображаем запись
            flight_reg.Text = p1.Flight;
            destination_reg.Text = p1.Destination;
            departure_reg.SelectedDate = p1.Departure_time;
            arrival_reg.SelectedDate = p1.Arrival_time;
            seets_reg.Text = p1.Available_seets;
            aircraft_reg.Text = p1.Aircraft_type;
            capacity_reg.Text = p1.Capacity;
        }

        private void edit_click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (flight_reg.Text.Length == 0) errors.AppendLine("Введите номер рейса!");
            if (destination_reg.Text != "Moon" && destination_reg.Text != "Bebrovo" && destination_reg.Text != "Kolomna")
                errors.AppendLine("Выберите место назначения!");
            if (arrival_reg.Text.Length == 0) errors.AppendLine("Задайте время прибытия");
            if (departure_reg.Text.Length == 0) errors.AppendLine("Задайте время отбытия");
            if (aircraft_reg.Text != "Boeing 747" && aircraft_reg.Text != "Rocket Launcer" && aircraft_reg.Text != "Abobus")
                errors.AppendLine("Выберите тип самолёта!");
            if (capacity_reg.Text.Length == 0) errors.AppendLine("Задайте вместительность транспорта!");
            if (seets_reg.Text.Length == 0) errors.AppendLine("Кол-во свободных мест не указано!");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            Flight_detail p1 = new Flight_detail();

            p1.Flight = flight_reg.Text;
            p1.Destination = destination_reg.Text;
            p1.Departure_time = (DateTime)departure_reg.SelectedDate;
            p1.Arrival_time = (DateTime)arrival_reg.SelectedDate;
            p1.Available_seets = seets_reg.Text;
            p1.Aircraft_type = aircraft_reg.Text;
            p1.Capacity = capacity_reg.Text;
            try
            {
                db.SaveChanges();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void otmena_click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
