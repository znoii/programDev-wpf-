using IT_S.Models;
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

namespace IT_S.Views
{
    /// <summary>
    /// Interaction logic for EditRequestWindow.xaml
    /// </summary>
    public partial class EditedRequestWindow : Window
    {
        public Request EditedRequest { get; set; }
        public EditedRequestWindow(Request request)
        {
            InitializeComponent();
            EditedRequest = request;
            EquipBox.Text = EditedRequest.EquipmentType;
            ModelBox.Text = EditedRequest.Model;
            ProblemBox.Text = EditedRequest.ProblemDescription;
            StatusBox.SelectedItem = StatusBox.Items.OfType<ComboBoxItem>()
                .FirstOrDefault(item => (string)item.Content == EditedRequest.Status);
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(EquipBox.Text) ||
                string.IsNullOrWhiteSpace(ModelBox.Text) ||
                string.IsNullOrWhiteSpace(ProblemBox.Text))
            {
                MessageBox.Show("Поля не длжны быть пустыми!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            EditedRequest.EquipmentType = EquipBox.Text;
            EditedRequest.Model = ModelBox.Text;
            EditedRequest.ProblemDescription = ProblemBox.Text;
            EditedRequest.Status = ((ComboBoxItem)StatusBox.SelectedItem)?.Content.ToString() ?? "Новая";

            DialogResult = true;
        }
    }
}
