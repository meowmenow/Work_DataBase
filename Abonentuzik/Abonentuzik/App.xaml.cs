using Abonentuzik.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Abonentuzik
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
    }

    public static class Data
    {
        public static Abonent? abonent;
        public static bool Login = false;
        public static string UserSurname;
        public static string UserName;
        public static string UserPatronymic;
        public static string Right;
    }
}
