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
    public partial class ApplicationsPage : Page
    {
        private readonly NavigationService Navigation;
        private readonly DatabaseEntities Database;

        public ApplicationsPage(NavigationService navigation, DatabaseEntities database)
        {
            InitializeComponent();
            Navigation = navigation;
            Database = database;

            UpdateTable();
        }

        private void EditButtonClick(object sender, RoutedEventArgs e)
        {
            if (DataGrid.SelectedItem is Application currentApplication)
            {
                var page = new ApplicationsEditPage(Navigation, Database, currentApplication);
                page.SaveButton.Click += UpdateTable;
                Navigation.Navigate(page);
            }
        }

        private void AddButtonClick(object sender, RoutedEventArgs e)
        {
            var page = new ApplicationsEditPage(Navigation, Database);
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
            DataGrid.ItemsSource = Database.Applications.ToList();
        }

        private void UpdateTable()
        {
            DataGrid.ItemsSource = Database.Applications.ToList();
        }

        private void TbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            DataGrid.ItemsSource = Database.Applications
                .Where(x => x.Client1.fio.ToLower().Contains(TbSearch.Text.ToLower())).ToList();
        }
    }
}
