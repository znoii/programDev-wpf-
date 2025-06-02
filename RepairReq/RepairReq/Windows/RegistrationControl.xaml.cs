using RepairReq.Models;
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

namespace RepairReq.Windows
{
    /// <summary>
    /// Логика взаимодействия для RegistrationControl.xaml
    /// </summary>
    public partial class RegistrationControl : UserControl
    {
        public RegistrationControl()
        {
            InitializeComponent();
        }

        private void OnLoginClick(object sender, RoutedEventArgs e)
        {
            var newUser = new Master
            {
                Login = LoginTextbox.Text,
                Password = PasswordTextbox.Text,
                FullName = FullNameTextbox.Text,
                PhoneNumber = PhoneNumberTextbox.Text,
                RegDate = DateOnly.FromDateTime(RegDatePicker.SelectedDate.Value)
            };

            App.DbContext.Masters.Add(newUser);
            App.DbContext.SaveChanges();
            if (this.Parent is Window win)
                win.Content = new LoginControl();

        }

        private void OnRegistrationClick(object sender, RoutedEventArgs e)
        {
            if (this.Parent is Window win)
                win.Content = new LoginControl();
        }
    }
}
