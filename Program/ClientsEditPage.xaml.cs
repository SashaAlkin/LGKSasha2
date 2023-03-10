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
    public partial class ClientsEditPage : Page
    {
        private readonly NavigationService Navigation;
        private readonly DatabaseEntities Database;
        private readonly Client CurrentClient;
        private readonly bool ShouldAdd;

        public ClientsEditPage(NavigationService navigation, DatabaseEntities database, Client currentClient)
        {
            InitializeComponent();
            Navigation = navigation;
            Database = database;
            CurrentClient = currentClient;
            DataContext = CurrentClient;
            ShouldAdd = false;
        }

        public ClientsEditPage(NavigationService navigation, DatabaseEntities database) : this(navigation, database, new Client())
        {
            ShouldAdd = true;
        }

        private void SaveButtonClick(object sender, RoutedEventArgs e)
        {
            var fio1 = FioTextBox.Text;
            var age1 = AgeTextBox.Text;
            var date_of_brith1 = Date_of_brithDatePicker.SelectedDate;
            var address1 = AddressTextBox.Text;
            var password = PasswordBox.Password;

            if (MainPage.IsNullOrEmpty(fio1))
            {
                MessageBox.Show("Введите имя");
                return;
            }
            if (MainPage.IsNullOrEmpty(age1))
            {
                MessageBox.Show("Введите фамилию");
                return;
            }
            if (date_of_brith1 == null)
            {
                MessageBox.Show("Введите отчество");
                return;
            }
            if (MainPage.IsNullOrEmpty(address1))
            {
                MessageBox.Show("Введите возраст");
                return;
            }
            if (MainPage.IsNullOrEmpty(password))
            {
                MessageBox.Show("Введите пароль");
                return;
            }

            if (ShouldAdd)
            {
                var usingg = new Using() { login = fio1, password = password, user_type = 3 };

                Database.Usings.Add(usingg);

                CurrentClient.@using = usingg.id;

                Database.Clients.Add(CurrentClient);
            }
            else
            {
                CurrentClient.Using1.login = fio1;
                CurrentClient.Using1.password = password;
            }

            Database.SaveChanges();

            Navigation.GoBack();
        }
    }
}
