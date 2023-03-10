
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
    public partial class ClientsPage : Page
    {
        private readonly NavigationService Navigation;
        private readonly DatabaseEntities Database;

        public ClientsPage(NavigationService navigation, DatabaseEntities database)
        {
            InitializeComponent();
            Navigation = navigation;
            Database = database;

            UpdateTable();
        }

        private void EditButtonClick(object sender, RoutedEventArgs e)
        {
            if (DataGrid.SelectedItem is Client currentClient)
            {
                var page = new ClientsEditPage(Navigation, Database, currentClient);
                page.SaveButton.Click += UpdateTable;
                Navigation.Navigate(page);
            }
        }

        private void AddButtonClick(object sender, RoutedEventArgs e)
        {
            var page = new ClientsEditPage(Navigation, Database);
            page.SaveButton.Click += UpdateTable;
            Navigation.Navigate(page);
        }

        private void DeleteButtonClick(object sender, RoutedEventArgs e)
        {
            var toRemove = DataGrid.SelectedItems.Cast<Client>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить {toRemove.Count()} записей?", "Удалить?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Database.Usings.RemoveRange(toRemove.Select(x => x.Using1));

                Database.Clients.RemoveRange(toRemove);
                Database.SaveChanges();

                MessageBox.Show("Записи удалены");

                UpdateTable();
            }
        }

        private void UpdateTable(object sender, RoutedEventArgs e)
        {
            DataGrid.ItemsSource = Database.Clients.ToList();
        }

        private void UpdateTable()
        {
            DataGrid.ItemsSource = Database.Clients.ToList();
        }

        private void TbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            DataGrid.ItemsSource = Database.Clients
                .Where(x => x.fio.ToLower().Contains(TbSearch.Text.ToLower())).ToList();
        }
    }
}
