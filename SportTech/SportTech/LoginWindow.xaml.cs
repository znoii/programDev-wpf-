using System.ComponentModel;
using System.Windows;

namespace SportTech
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            Closing += OnLoginWindowClosing;
            this.Content = new LoginControl();
        }

        private void OnLoginWindowClosing(object? sender, CancelEventArgs e)
        {
            if (DialogResult != true)
            {
                if (MessageBox.Show("хотите выйти", "Выход",
                    MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                {
                    e.Cancel = true;
                }
                else
                {
                    Application.Current.Shutdown();
                }
            }
        }
    }
}