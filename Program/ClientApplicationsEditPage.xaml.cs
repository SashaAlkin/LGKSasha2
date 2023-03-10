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
    public partial class ClientApplicationsEditPage : Page
    {
        private readonly NavigationService Navigation;
        private readonly DatabaseEntities Database;
        private readonly Application CurrentApplication;
        private readonly Client Client;
        private readonly bool ShouldAdd;

        public ClientApplicationsEditPage(NavigationService navigation, DatabaseEntities database, Client client, Application currentApplication)
        {
            InitializeComponent();
            Navigation = navigation;
            Database = database;
            CurrentApplication = currentApplication;
            DataContext = CurrentApplication;
            Client = client;
            CbFilter2.ItemsSource = Database.Specialists.ToList();
            CbFilter3.ItemsSource = Database.The_purpose_of_the_appeal.ToList();
            ShouldAdd = false;
        }

        public ClientApplicationsEditPage(NavigationService navigation, Client client, DatabaseEntities database) : this(navigation, database, client, new Application())
        {
            ShouldAdd = true;
        }

        private void SaveButtonClick(object sender, RoutedEventArgs e)
        {
            if (CbFilter2.SelectedItem == null)
            {
                MessageBox.Show("Выберите специалиста");
                return;
            }
            if (CbFilter3.SelectedItem == null)
            {
                MessageBox.Show("Выберите цель обращения");
                return;
            }
            if (DateDatePicker.SelectedDate == null)
            {
                MessageBox.Show("Укажите дату");
                return;
            }

            if (ShouldAdd)
            {
                Database.Applications.Add(CurrentApplication);
            }

            CurrentApplication.client = Client.id;

            Database.SaveChanges();

            Navigation.GoBack();
        }
    }
}
