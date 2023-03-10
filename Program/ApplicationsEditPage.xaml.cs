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
    public partial class ApplicationsEditPage : Page
    {
        private readonly NavigationService Navigation;
        private readonly DatabaseEntities Database;
        private readonly Application CurrentApplication;
        private readonly bool ShouldAdd;

        public ApplicationsEditPage(NavigationService navigation, DatabaseEntities database, Application currentApplication)
        {
            InitializeComponent();
            Navigation = navigation;
            Database = database;
            CurrentApplication = currentApplication;
            DataContext = CurrentApplication;
            CbFilter.ItemsSource = Database.Clients.ToList();
            CbFilter2.ItemsSource = Database.Specialists.ToList();
            CbFilter3.ItemsSource = Database.The_purpose_of_the_appeal.ToList();
            ShouldAdd = false;
        }

        public ApplicationsEditPage(NavigationService navigation, DatabaseEntities database) : this(navigation, database, new Application())
        {
            ShouldAdd = true;
        }

        private void SaveButtonClick(object sender, RoutedEventArgs e)
        {
            if (CbFilter.SelectedItem == null)
            {
                MessageBox.Show("Выберите клиента");
                return;
            }
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
            Database.SaveChanges();
            Navigation.GoBack();
        }
    }
}
