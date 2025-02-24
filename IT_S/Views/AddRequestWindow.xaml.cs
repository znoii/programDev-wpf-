using IT_S.Models;
using IT_S.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace IT_S.Views
{
    /// <summary>
    /// Interaction logic for AddRequestWindow.xaml
    /// </summary>
    public partial class AddRequestWindow : Window
    {
        public Request NewRequest { get; set; }
        public AddRequestWindow()
        {
            InitializeComponent();
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(FullNameBox.Text) ||
                string.IsNullOrWhiteSpace(NumberBox.Text) ||
                string.IsNullOrWhiteSpace(EquipBox.Text) ||
                string.IsNullOrWhiteSpace(ModelBox.Text) ||
                string.IsNullOrWhiteSpace(ProblemBox.Text))
            {
                MessageBox.Show("Заполните все поля!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            NewRequest = new Request
            {
                RequestNumber = DataService.Requests.Count + 1,
                DateAdded = DateTime.Now,
                ClientName = FullNameBox.Text,
                PhoneNumber = NumberBox.Text,
                EquipmentType = EquipBox.Text,
                Model = ModelBox.Text,
                ProblemDescription = ProblemBox.Text,
                Status = ((ComboBoxItem)StatusBox.SelectedItem)?.Content.ToString() ?? "Новая",
                AssignedEngineer = DataService.Engineers[0]
            };

            DialogResult = true;
        }
        
    }
}
