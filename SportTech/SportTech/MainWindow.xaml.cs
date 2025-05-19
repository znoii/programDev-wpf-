using Microsoft.EntityFrameworkCore;
using SportTech.Models;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace SportTech
{
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
                CurrentUserTextBlock.Text = $"Текущий пользователь: {App.CurrentUser?.FullName}";
                RefreshInventoryList();
                StatusComboBox.ItemsSource = App.DbContext.Statuses.ToList();
                UsersComboBox.ItemsSource = App.DbContext.Users.ToList();
            }
            else
            {
                Close();
            }
        }

        private void RefreshInventoryList()
        {
            InventoryListView.ItemsSource = App.DbContext.Inventories
                .Include(i => i.Status)
                .Include(i => i.User)
                .ToList();
        }

        private void AddInventoryButton_Click(object sender, RoutedEventArgs e)
        {
            var newInventory = new Inventory
            {
                ArticleNum = ArticleNumTextBox.Text,
                Name = NameTextBox.Text,
                Type = TypeTextBox.Text,
                Date = DateOnly.FromDateTime(DateTime.Now),
                StatusId = 1 // По умолчанию "В наличии"
            };

            App.DbContext.Inventories.Add(newInventory);
            App.DbContext.SaveChanges();
            RefreshInventoryList();
            ClearInputFields();
        }

        private void UpdateInventoryButton_Click(object sender, RoutedEventArgs e)
        {
            if (InventoryListView.SelectedItem is Inventory selectedInventory)
            {
                selectedInventory.StatusId = ((Status)StatusComboBox.SelectedItem).Id;
                selectedInventory.UserId = UsersComboBox.SelectedItem != null ? ((User)UsersComboBox.SelectedItem).Id : null;

                App.DbContext.SaveChanges();
                RefreshInventoryList();
            }
        }

        private void DeleteInventoryButton_Click(object sender, RoutedEventArgs e)
        {
            if (InventoryListView.SelectedItem is Inventory selectedInventory)
            {
                App.DbContext.Inventories.Remove(selectedInventory);
                App.DbContext.SaveChanges();
                RefreshInventoryList();
            }
        }

        private void ClearInputFields()
        {
            ArticleNumTextBox.Text = "";
            NameTextBox.Text = "";
            TypeTextBox.Text = "";
        }

        private void InventoryListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (InventoryListView.SelectedItem is Inventory selectedInventory)
            {
                StatusComboBox.SelectedItem = App.DbContext.Statuses.Find(selectedInventory.StatusId);
                UsersComboBox.SelectedItem = selectedInventory.UserId.HasValue ?
                    App.DbContext.Users.Find(selectedInventory.UserId.Value) : null;
            }
        }
    }
}