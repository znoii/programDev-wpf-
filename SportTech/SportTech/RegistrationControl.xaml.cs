using System;
using System.Windows;
using System.Windows.Controls;
using SportTech.Models;

namespace SportTech
{
    public partial class RegistrationControl : UserControl
    {
        public RegistrationControl()
        {
            InitializeComponent();
            RegDateTextbox.Text = DateOnly.FromDateTime(DateTime.Now).ToString();
        }

        private void OnLoginClick(object sender, RoutedEventArgs e)
        {
            var newUser = new User
            {
                Login = LoginTextbox.Text,
                Password = PasswordTextbox.Text,
                FullName = FullNameTextbox.Text,
                PhoneNumber = PhoneNumberTextbox.Text,
                RegDate = DateOnly.Parse(RegDateTextbox.Text)
            };

            App.DbContext.Users.Add(newUser);
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