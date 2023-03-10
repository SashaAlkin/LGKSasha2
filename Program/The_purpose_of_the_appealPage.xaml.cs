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
    public partial class The_purpose_of_the_appealPage : Page
    {
        private readonly NavigationService Navigation;
        private readonly DatabaseEntities Database;

        public The_purpose_of_the_appealPage(NavigationService navigation, DatabaseEntities database)
        {
            InitializeComponent();
            Navigation = navigation;
            Database = database;

            UpdateTable();
        }

        private void EditButtonClick(object sender, RoutedEventArgs e)
        {
            if (DataGrid.SelectedItem is The_purpose_of_the_appeal currentThe_purpose_of_the_appeal)
            {
                var page = new The_purpose_of_the_appealEditPage(Navigation, Database, currentThe_purpose_of_the_appeal);
                page.SaveButton.Click += UpdateTable;
                Navigation.Navigate(page);
            }
        }

        private void AddButtonClick(object sender, RoutedEventArgs e)
        {
            var page = new The_purpose_of_the_appealEditPage(Navigation, Database);
            page.SaveButton.Click += UpdateTable;
            Navigation.Navigate(page);
        }

        private void DeleteButtonClick(object sender, RoutedEventArgs e)
        {
            var toRemove = DataGrid.SelectedItems.Cast<The_purpose_of_the_appeal>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить {toRemove.Count()} записей?", "Удалить?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Database.The_purpose_of_the_appeal.RemoveRange(toRemove);
                Database.SaveChanges();

                MessageBox.Show("Записи удалены");

                UpdateTable();
            }
        }

        private void UpdateTable(object sender, RoutedEventArgs e)
        {
            DataGrid.ItemsSource = Database.The_purpose_of_the_appeal.ToList();
        }

        private void UpdateTable()
        {
            DataGrid.ItemsSource = Database.The_purpose_of_the_appeal.ToList();
        }

        private void TbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            DataGrid.ItemsSource = Database.The_purpose_of_the_appeal
                .Where(x => x.the_purpose_of_the_appeal1.ToLower().Contains(TbSearch.Text.ToLower())).ToList();
        }
    }
}
