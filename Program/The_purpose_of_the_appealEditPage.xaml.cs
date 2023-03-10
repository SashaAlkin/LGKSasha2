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
    public partial class The_purpose_of_the_appealEditPage : Page
    {
        private readonly NavigationService Navigation;
        private readonly DatabaseEntities Database;
        private readonly The_purpose_of_the_appeal CurrentThe_purpose_of_the_appeal;
        private readonly bool ShouldAdd;

        public The_purpose_of_the_appealEditPage(NavigationService navigation, DatabaseEntities database, The_purpose_of_the_appeal currentThe_purpose_of_the_appeal)
        {
            InitializeComponent();
            Navigation = navigation;
            Database = database;
            CurrentThe_purpose_of_the_appeal = currentThe_purpose_of_the_appeal;
            DataContext = CurrentThe_purpose_of_the_appeal;
            ShouldAdd = false;
        }

        public The_purpose_of_the_appealEditPage(NavigationService navigation, DatabaseEntities database) : this(navigation, database, new The_purpose_of_the_appeal())
        {
            ShouldAdd = true;
        }

        private void SaveButtonClick(object sender, RoutedEventArgs e)
        {
            if (MainPage.IsNullOrEmpty(ProblemTextBox.Text))
            {
                MessageBox.Show("Выберите актив");
                return;
            }

            if (ShouldAdd) Database.The_purpose_of_the_appeal.Add(CurrentThe_purpose_of_the_appeal);
            Database.SaveChanges();

            Navigation.GoBack();
        }
    }
}
