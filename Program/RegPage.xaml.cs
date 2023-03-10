using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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
    public partial class RegPage : Page
    {
        private readonly NavigationService Navigation;
        private readonly DatabaseEntities Database;

        public RegPage(NavigationService navigation, DatabaseEntities database)
        {
            InitializeComponent();
            Navigation = navigation;
            Database = database;
        }

        private void RegButtonClick(object sender, RoutedEventArgs e)
        {
            var login = LoginTextBox.Text;
            var password = PasswordBox.Password;
            var age = AgeTextBox.Text;
            var dateOfBirth = DateOfBirtDatePicker.SelectedDate;
            var adress = AdressTextBox.Text;

            if (MainPage.IsNullOrEmpty(login))
            {
                MessageBox.Show("Введите логин");
                return;
            }
            if (MainPage.IsNullOrEmpty(password))
            {
                MessageBox.Show("Введите пароль");
                return;
            }
            if (MainPage.IsNullOrEmpty(age))
            {
                MessageBox.Show("Введите возраст");
                return;
            }
            if (MainPage.IsNullOrEmpty(adress))
            {
                MessageBox.Show("Введите адрес");
                return;
            }
            if (dateOfBirth == null)
            {
                MessageBox.Show("Введите день рождения");
                return;
            }

            var usingg = new Using() { login = login, password = password, user_type = 3 };

            Database.Usings.Add(usingg);
            Database.Clients.Add(new Client() { fio = login, age = age, date_of_birth = dateOfBirth, address = adress, @using = usingg.id });

            Database.SaveChanges();

            Navigation.Navigate(new MainPage(Navigation, Database));
        }
    }
}
