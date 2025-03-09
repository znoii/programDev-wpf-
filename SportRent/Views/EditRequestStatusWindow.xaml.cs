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
    /// Interaction logic for EditRequestStatusWindow.xaml
    /// </summary>
    public partial class EditRequestStatusWindow : Window
    {
        private readonly Request _request;

        public EditRequestStatusWindow(Request request)
        {
            InitializeComponent();
            _request = request;
            StatusComboBox.ItemsSource = Enum.GetValues(typeof(RequestStatus));
            StatusComboBox.SelectedItem = _request.Status;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (StatusComboBox.SelectedItem is RequestStatus newStatus)
            {
                _request.Status = newStatus;

                if (newStatus == RequestStatus.Завершен)
                {
                    _request.ClosedAt = DateTime.Now;
                }
                else
                {
                    _request.ClosedAt = null;
                }

                DialogResult = true;
                Close();
            }
            else
            {
                MessageBox.Show("Выберите статус!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
