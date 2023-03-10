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

namespace Program
{
    public partial class ClientMainPage : Page
    {
        private readonly NavigationService Navigation;
        private readonly DatabaseEntities Database;
        private readonly Client Client;

        public ClientMainPage(NavigationService navigation, DatabaseEntities database, Client client)
        {
            InitializeComponent();
            Navigation = navigation;
            Database = database;
            Client = client;
        }

        private void ApplicationsButtonClick(object sender, RoutedEventArgs e)
        {
            Navigation.Navigate(new ClientApplicationsPage(Navigation, Database, Client));
        }

        private void ClientsButtonClick(object sender, RoutedEventArgs e)
        {
            Navigation.Navigate(new ClientsPage(Navigation, Database));
        }

        private void ProblemButtonClick(object sender, RoutedEventArgs e)
        {
            Navigation.Navigate(new The_purpose_of_the_appealPage(Navigation, Database));
        }

        public static bool IsNullOrEmpty(String s)
        {
            return s.Length <= 0 || String.IsNullOrEmpty(s) || String.IsNullOrWhiteSpace(s);
        }
    }
}
