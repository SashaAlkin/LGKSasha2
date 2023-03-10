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
    public partial class ClientApplicationsPage : Page
    {
        private readonly NavigationService Navigation;
        private readonly DatabaseEntities Database;
        private readonly Client Client;

        public ClientApplicationsPage(NavigationService navigation, DatabaseEntities database, Client client)
        {
            InitializeComponent();
            Navigation = navigation;
            Database = database;
            Client = client;

            UpdateTable();
        }

        private void EditButtonClick(object sender, RoutedEventArgs e)
        {
            if (DataGrid.SelectedItem is Application currentApplication)
            {
                var page = new ClientApplicationsEditPage(Navigation, Database, Client, currentApplication);
                page.SaveButton.Click += UpdateTable;
                Navigation.Navigate(page);
            }
        }

        private void AddButtonClick(object sender, RoutedEventArgs e)
        {
            var page = new ClientApplicationsEditPage(Navigation, Client, Database);
            page.SaveButton.Click += UpdateTable;
            Navigation.Navigate(page);
        }

        private void DeleteButtonClick(object sender, RoutedEventArgs e)
        {
            var toRemove = DataGrid.SelectedItems.Cast<Application>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить {toRemove.Count()} записей?", "Удалить?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Database.Applications.RemoveRange(toRemove);
                Database.SaveChanges();

                MessageBox.Show("Записи удалены");

                UpdateTable();
            }
        }

        private void UpdateTable(object sender, RoutedEventArgs e)
        {
            DataGrid.ItemsSource = Client.Applications;
        }

        private void UpdateTable()
        {
            DataGrid.ItemsSource = Client.Applications;
        }

        private void TbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            DataGrid.ItemsSource = Client.Applications
                .Where(x => x.Client1.fio.ToLower().Contains(TbSearch.Text.ToLower())).ToList();
        }
    }
}
