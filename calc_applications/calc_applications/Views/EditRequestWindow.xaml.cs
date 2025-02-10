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
    /// Логика взаимодействия для EditRequestWindow.xaml
    /// </summary>
    public partial class EditRequestWindow : Window
    {
        public EditRequestWindow()
        {
            InitializeComponent();
        }
        public Request EditedRequest { get; set; }

        public EditRequestWindow(Request request)
        {
            InitializeComponent();
            EditedRequest = request;
            FullNameBox.Text = EditedRequest.fullname;
            StatusBox.SelectedItem = StatusBox.Items.OfType<ComboBoxItem>()
                .FirstOrDefault(item => (string)item.Content == EditedRequest.status);
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(FullNameBox.Text))
            {
                MessageBox.Show("Введите ФИО!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            EditedRequest.fullname = FullNameBox.Text;
            EditedRequest.status = ((ComboBoxItem)StatusBox.SelectedItem)?.Content.ToString() ?? "Новая";

            DialogResult = true;
        }
    }
}

