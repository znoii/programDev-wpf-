using SportRent.Data;
using SportRent.Models;
using SportRent.Views;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SportRent
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadInventories();
            LoadData();
            
        }
        private void LoadData()
        {
            if (LoginWindow.CurrentUser != null)
            {
                UserInfoText.Text = $"Пользователь: {LoginWindow.CurrentUser.Name} ({LoginWindow.CurrentUser.Role})";

                LoadInventories(); //для всех пользователей
                if (LoginWindow.CurrentUser.Role == UserRole.Admin)
                {
                    AdminTabControl.Visibility = Visibility.Visible;
                    AdminButtonsPanel.Visibility = Visibility.Visible;
                    LoadRequests();
                }
                else
                {
                    VisitorButtonsPanel.Visibility = Visibility.Visible;
                }
            }
            InventoryListView.ItemsSource = Service.Inventories;
        }
        private void OpenStatistics_Click(object sender, RoutedEventArgs e)
        {
            StatisticsWindow statisticsWindow = new StatisticsWindow();
            statisticsWindow.ShowDialog();
        }

        private void CreateRequest_Click(object sender, RoutedEventArgs e)
        {
            if (InventoryListView.SelectedItem is Inventory selectedInventory)
            {
                RequestWindow requestWindow = new RequestWindow(selectedInventory);
                requestWindow.ShowDialog();
                LoadData(); 
            }
            else
            {
                MessageBox.Show("Выберите инвентарь для аренды.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            Close();
        }

        private void AddInventory_Click(object sender, RoutedEventArgs e)
        {
            InventoryWindow inventoryWindow = new InventoryWindow();
            if (inventoryWindow.ShowDialog() == true)
            {
                inventoryWindow.CurrentInventory.Id = Service.Inventories.Count + 1;
                Service.Inventories.Add(inventoryWindow.CurrentInventory);
                LoadInventories();
            }
        }

        private void EditInventory_Click(object sender, RoutedEventArgs e)
        {
            if (InventoryListView.SelectedItem is Inventory selectedInventory)
            {
                InventoryWindow inventoryWindow = new InventoryWindow(selectedInventory);
                if (inventoryWindow.ShowDialog() == true)
                {
                    LoadInventories();
                }
            }
        }

        private void LoadInventories()
        {
            InventoryListView.ItemsSource = null; 
            InventoryListView.ItemsSource = Service.Inventories;
        }


        private void DeleteInventory_Click(object sender, RoutedEventArgs e)
        {
            if (InventoryListView.SelectedItem is Inventory selectedInventory)
            {
                var confirm = MessageBox.Show("Вы уверены, что хотите удалить этот инвентарь?",
                                              "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (confirm == MessageBoxResult.Yes)
                {
                    Service.Inventories.Remove(selectedInventory);
                    LoadInventories();
                }
            }
        }

        private void LoadRequests()
        {
            RequestListView.ItemsSource = Service.Requests
                .Select(r => new RequestViewModel
                {
                    Id = r.Id,
                    Status = r.Status,
                    ClosedAt = r.ClosedAt?.ToString("dd.MM.yyyy") ?? "Не закрыта"
                })
                .ToList();

        }


        private void EditRequestStatus_Click(object sender, RoutedEventArgs e)
        {
            if (RequestListView.SelectedItem is RequestViewModel selectedRequest)
            {
                var request = Service.Requests.FirstOrDefault(r => r.Id == selectedRequest.Id);
                if (request == null) return;

                EditRequestStatusWindow editWindow = new EditRequestStatusWindow(request);
                if (editWindow.ShowDialog() == true)
                {
                    LoadRequests();
                }
            }
            else
            {
                MessageBox.Show("Выберите заявку для изменения.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void DeleteRequest_Click(object sender, RoutedEventArgs e)
        {
            if (RequestListView.SelectedItem is RequestViewModel selectedRequest)
            {
                var request = Service.Requests.FirstOrDefault(r => r.Id == selectedRequest.Id);
                if (request == null) return;

                var confirm = MessageBox.Show("Вы уверены, что хотите удалить заявку?", "Удаление", MessageBoxButton.YesNo);
                if (confirm == MessageBoxResult.Yes)
                {
                    Service.Requests.Remove(request);
                    LoadRequests();
                }
            }
            else
            {
                MessageBox.Show("Выберите заявку для удаления.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

    }
}