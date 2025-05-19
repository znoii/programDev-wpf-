using System.Windows;
using System.Windows.Controls;
using SportTech.Models;

namespace SportTech
{
    public partial class LoginControl : UserControl
    {
        public LoginControl()
        {
            InitializeComponent();
        }

        private void OnRegistrationClick(object sender, RoutedEventArgs e)
        {
            if (this.Parent is Window win)
                win.Content = new RegistrationControl();
        }

        private void OnLoginClick(object sender, RoutedEventArgs e)
        {
            var user = App.DbContext.Users.FirstOrDefault(
                u => u.Login == LoginTextbox.Text && u.Password == PasswordTextbox.Text);

            if (user != null)
            {
                App.CurrentUser = user;
                if (this.Parent is Window win)
                {
                    win.DialogResult = true;
                    win.Close();
                }
            }
            else
            {
                MessageBox.Show("Невернo", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}