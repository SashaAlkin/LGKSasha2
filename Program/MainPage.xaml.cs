using System;
using System.Collections.Generic;
using System.Data;
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
    public partial class MainPage : Page
    {
        private readonly NavigationService Navigation;
        private readonly DatabaseEntities Database;

        public MainPage(NavigationService navigation, DatabaseEntities database)
        {
            InitializeComponent();
            Navigation = navigation;
            Database = database;
        }


        private void ApplicationsButtonClick(object sender, RoutedEventArgs e)
        {
            Navigation.Navigate(new ApplicationsPage(Navigation, Database));
        }

        private void ClientsButtonClick(object sender, RoutedEventArgs e)
        {
            Navigation.Navigate(new ClientsPage(Navigation, Database));
        }

        private void SpecialistButtonClick(object sender, RoutedEventArgs e)
        {
            Navigation.Navigate(new SpecialistPage(Navigation, Database));
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
