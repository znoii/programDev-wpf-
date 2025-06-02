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
    /// Логика взаимодействия для LoginControl.xaml
    /// </summary>
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
            var user = App.DbContext.Masters.FirstOrDefault(
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
