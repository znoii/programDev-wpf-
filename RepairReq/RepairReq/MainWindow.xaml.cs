using Microsoft.EntityFrameworkCore;
using RepairReq.Models;
using RepairReq.Windows;
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

namespace RepairReq
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += OnWindowLoaded;
        }

        private void OnWindowLoaded(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            if (loginWindow.ShowDialog() == true)
            {
                CurrentUserTextBlock.Text = $"Current user: {App.CurrentUser?.FullName}";
                RefreshBooksList();
            }
            else
            {
                Close();
            }
        }

        private void RefreshBooksList()
        {
            RequestsListView.ItemsSource = App.DbContext.Requests
                .Include(b => b.Status)
                .Include(b => b.Master)
                .ToList();
        }

        private void AddBookButton_Click(object sender, RoutedEventArgs e)
        {
            AddRequestWindow addWindow = new AddRequestWindow();
            if (addWindow.ShowDialog() == true)
            {
                RefreshBooksList();
            }
        }

        private void EditBookButton_Click(object sender, RoutedEventArgs e)
        {
            if (RequestsListView.SelectedItem is Request selectedRequest)
            {
                EditRequestWindow editWindow = new EditRequestWindow(selectedRequest);
                if (editWindow.ShowDialog() == true)
                {
                    RefreshBooksList();
                }
            }
            else
            {
                MessageBox.Show("Please select a book to edit", "No Selection",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void DeleteBookButton_Click(object sender, RoutedEventArgs e)
        {
            if (RequestsListView.SelectedItem is Request selectedRequest)
            {
                var result = MessageBox.Show($"Are you sure you want to delete '{selectedRequest.Problem}'?",
                    "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    App.DbContext.Requests.Remove(selectedRequest);
                    App.DbContext.SaveChanges();
                    RefreshBooksList();
                }
            }
            else
            {
                MessageBox.Show("Please select a book to delete", "No Selection",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}

