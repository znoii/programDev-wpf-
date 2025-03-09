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
    /// Interaction logic for InventoryWindow.xaml
    /// </summary>
    public partial class InventoryWindow : Window
    {
        public Inventory CurrentInventory { get; private set; }

        public InventoryWindow(Inventory inventory = null)
        {
            InitializeComponent();
            if (inventory != null)
            {
                CurrentInventory = inventory;
                NameTextBox.Text = inventory.Name;
                DescriptionTextBox.Text = inventory.Description;
                SizeTextBox.Text = inventory.Size;
                PriceTextBox.Text = inventory.PricePerHour.ToString();
                IsAvailableCheckBox.IsChecked = inventory.IsAvailable;
            }
            else
            {
                CurrentInventory = new Inventory();
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameTextBox.Text) ||
                string.IsNullOrWhiteSpace(DescriptionTextBox.Text) ||
                string.IsNullOrWhiteSpace(SizeTextBox.Text) ||
                !int.TryParse(PriceTextBox.Text, out int price))
            {
                MessageBox.Show("Заполните все поля корректно.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            CurrentInventory.Name = NameTextBox.Text;
            CurrentInventory.Description = DescriptionTextBox.Text;
            CurrentInventory.Size = SizeTextBox.Text;
            CurrentInventory.PricePerHour = price;
            CurrentInventory.IsAvailable = IsAvailableCheckBox.IsChecked ?? false;

            DialogResult = true;
            Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
