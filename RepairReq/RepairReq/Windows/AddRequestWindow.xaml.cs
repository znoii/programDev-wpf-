using RepairReq.Models;
using Microsoft.EntityFrameworkCore;
using System.Windows;
using System.Windows.Controls;

namespace RepairReq.Windows
{
    public partial class AddRequestWindow : Window
    {
        public AddRequestWindow()
        {
            InitializeComponent();
            Loaded += AddRequestWindow_Loaded;
        }

        private void AddRequestWindow_Loaded(object sender, RoutedEventArgs e)
        {
            StatusComboBox.ItemsSource = App.DbContext.Statuses.ToList();
            StatusComboBox.SelectedIndex = 0;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var newRequest = new Request
            {
                Id = IdTextBox.Text.Trim(),
                Description = DescriptionTextBox.Text.Trim(),
                Type = TypeTextBox.Text.Trim(),
                Problem = ProblemTextBox.Text.Trim(),
                CreatedAt = DateOnly.FromDateTime(DateTime.Now),
                StatusId = ((Status)StatusComboBox.SelectedItem).Id
            };

            try
            {
                App.DbContext.Requests.Add(newRequest);
                App.DbContext.SaveChanges();

                DialogResult = true;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}",
                    "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}