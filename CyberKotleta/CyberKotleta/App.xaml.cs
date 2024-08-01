using CyberKotleta.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace CyberKotleta
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
    }

    public static class Data
    {
        public static CyberAthlete? cyberAthlete;
        public static Role? user;
        public static User? reg;
        public static bool Login = false;
        public static string UserFio;
        public static string UserName;
        public static string UserPatronymic;
        public static string Right;
    }
}
