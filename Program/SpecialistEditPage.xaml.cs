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
    public partial class SpecialistEditPage : Page
    {
        private readonly NavigationService Navigation;
        private readonly DatabaseEntities Database;
        private readonly Specialist CurrentSpecialist;
        private readonly bool ShouldAdd;


        public SpecialistEditPage(NavigationService navigation, DatabaseEntities database, Specialist currentSpecialist)
        {
            InitializeComponent();
            Navigation = navigation;
            Database = database;
            CurrentSpecialist = currentSpecialist;
            DataContext = CurrentSpecialist;
            ShouldAdd = false;
        }

        public SpecialistEditPage(NavigationService navigation, DatabaseEntities database) : this(navigation, database, new Specialist())
        {
            ShouldAdd = true;
        }

        private void SaveButtonClick(object sender, RoutedEventArgs e)
        {
            var fio = FioTextBox.Text;
            var work_experience = WorkExperienceTextBox.Text;
            var age = AgeTextBox.Text;
            var phone = PhoneTextBox.Text;
            var numberOffice = NumberOfficeTextBox.Text;
            var password = PasswordBox.Password;

            if (MainPage.IsNullOrEmpty(fio))
            {
                MessageBox.Show("Укажите ФИО");
                return;
            }
            if (MainPage.IsNullOrEmpty(work_experience))
            {
                MessageBox.Show("Выберите стаж");
                return;
            }
            if (MainPage.IsNullOrEmpty(age))
            {
                MessageBox.Show("Укажите возраст");
                return;
            }
            if (MainPage.IsNullOrEmpty(phone))
            {
                MessageBox.Show("Укажите номер телефона");
                return;
            }
            if (MainPage.IsNullOrEmpty(numberOffice))
            {
                MessageBox.Show("Укажите кабинет");
                return;
            }
            if (MainPage.IsNullOrEmpty(password))
            {
                MessageBox.Show("Введите пароль");
                return;
            }

            if (ShouldAdd)
            {
                var usingg = new Using() { login = fio, password = password, user_type = 2 };

                Database.Usings.Add(usingg);

                CurrentSpecialist.@using = usingg.id;

                Database.Specialists.Add(CurrentSpecialist);
            }
            else
            {
                CurrentSpecialist.Using1.login = fio;
                CurrentSpecialist.Using1.password = password;
            }

            Database.SaveChanges();

            Navigation.GoBack();
        }
    }
}
