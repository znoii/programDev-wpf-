using RepairReq.Models;
using Microsoft.EntityFrameworkCore;
using System.Windows;

namespace RepairReq.Windows
{
    public partial class EditRequestWindow : Window
    {
        private readonly Request _request;

        public EditRequestWindow(Request request)
        {
            InitializeComponent();
            _request = request;
            Loaded += EditRequestWindow_Loaded;
        }

        private void EditRequestWindow_Loaded(object sender, RoutedEventArgs e)
        {
            DescriptionText.Text = _request.Description;
            TypeTextBox.Text = _request.Type;
            ProblemTextBox.Text = _request.Problem;

            StatusComboBox.ItemsSource = App.DbContext.Statuses.ToList();
            MasterComboBox.ItemsSource = App.DbContext.Masters.ToList();

            StatusComboBox.SelectedItem = App.DbContext.Statuses.Find(_request.StatusId);
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            _request.Type = TypeTextBox.Text;
            _request.Problem = ProblemTextBox.Text;
            _request.StatusId = ((Status)StatusComboBox.SelectedItem).Id;

            App.DbContext.SaveChanges();
            DialogResult = true;
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}