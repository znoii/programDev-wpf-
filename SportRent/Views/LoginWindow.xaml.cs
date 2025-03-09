using SportRent.Data;
using SportRent.Models;
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
using System.Windows.Shapes;

namespace SportRent.Views
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public static User? CurrentUser { get; private set; }
        public LoginWindow()
        {
            InitializeComponent();
        }
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string email = EmailTextBox.Text;
            string password = PasswordBox.Password;

            CurrentUser = Service.Users.FirstOrDefault(u => u.Email == email && u.Password == password);

            if (CurrentUser != null)
            {
                MessageBox.Show($"Добро пожаловать, {CurrentUser.Name}!", "Успешный вход", MessageBoxButton.OK, MessageBoxImage.Information);

                // Открываем главное окно в зависимости от роли
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Неверный email или пароль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
