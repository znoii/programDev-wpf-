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
    /// Interaction logic for RequestWindow.xaml
    /// </summary>
    public partial class RequestWindow : Window
    {
        private readonly Inventory _selectedInventory;

        public RequestWindow(Inventory inventory)
        {
            InitializeComponent();
            _selectedInventory = inventory;
            InventoryNameText.Text = _selectedInventory.Name;
            ReturnDatePicker.SelectedDate = DateTime.Now.AddDays(1);
        }

        private void ConfirmRequest_Click(object sender, RoutedEventArgs e)
        {
            if (ReturnDatePicker.SelectedDate == null || ReturnDatePicker.SelectedDate <= DateTime.Now)
            {
                MessageBox.Show("Выберите корректную дату возврата.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var newRequest = new Request
            {
                Id = Service.Requests.Count + 1,
                UserId = LoginWindow.CurrentUser.Id,
                InventoryId = _selectedInventory.Id,
                CreatedAt = DateTime.Now,
                ExpectedClosed = ReturnDatePicker.SelectedDate.Value,
                Status = RequestStatus.Забронирован
            };

            Service.Requests.Add(newRequest);
            MessageBox.Show("Заявка успешно оформлена!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            Close();
        }
    }
}
