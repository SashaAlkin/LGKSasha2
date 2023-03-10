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
    public partial class AuthPage : Page
    {
        private readonly NavigationService Navigation;
        private readonly DatabaseEntities Database;

        public AuthPage(NavigationService navigation, DatabaseEntities database)
        {
            InitializeComponent();
            Navigation = navigation;
            Database = database;

            CbFilter.ItemsSource = Database.Usings.ToList();
        }

        private void RegButtonClick(object sender, RoutedEventArgs e)
        {
            Navigation.Navigate(new RegPage(Navigation, Database));
        }

        private void AuthButtonClick(object sender, RoutedEventArgs e)
        {
            var user = CbFilter.SelectedItem as Using;
            if (user == null)
            {
                MessageBox.Show("Выберите пользователя");
            }
            else if (Database.Usings.Where(u => u.login.Equals(user.login) && u.password.Equals(PasswordBox.Password)).Count() > 0)
            {
                if (user.UserType.id == 3)
                {
                    Navigation.Navigate(new ClientMainPage(Navigation, Database, user.Clients.Where(x => x.Using1.id == user.id).First()));
                }
                else
                {
                    Navigation.Navigate(new MainPage(Navigation, Database));
                }
            }
            else
            {
                MessageBox.Show("Не удалось найти пользователя, проверьте введённые данные");
            }
        }
    }
}
