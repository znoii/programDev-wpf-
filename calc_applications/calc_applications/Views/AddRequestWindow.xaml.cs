using calc_applications.Models;
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

namespace calc_applications.Views
{
    /// <summary>
    /// Логика взаимодействия для AddRequestWindow.xaml
    /// </summary>
    public partial class AddRequestWindow : Window
    {
        public Request NewRequest { get; set; }

        public AddRequestWindow()
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(FullNameBox.Text))
            {
                MessageBox.Show("Введите ФИО!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            NewRequest = new Request
            {
                id = new Random().Next(1000, 9999),  // Генерация случайного ID
                fullname = FullNameBox.Text,
                status = ((ComboBoxItem)StatusBox.SelectedItem)?.Content.ToString() ?? "Новая"
            };

            DialogResult = true;
        }
    }
}
