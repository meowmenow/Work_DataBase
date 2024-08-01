using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Aeroflot_from_hell
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public static class Data
    {
        public static int id;
        // Признак авторизации
        public static bool Login = false;
        // Права доступа
        public static string Right;
    }

    public partial class App : Application
    {
    }
}
