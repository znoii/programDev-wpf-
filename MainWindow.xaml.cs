using IT_S.Models;
using IT_S.Services;
using IT_S.Views;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
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

namespace IT_S
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Request> Requests { get; set; }
        public ObservableCollection<Engineer> Engineers { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Requests = new ObservableCollection<Request>(DataService.Requests);
            Engineers = new ObservableCollection<Engineer>(DataService.Engineers);

            DataContext = this;
        }
        private void EditRequest_Click(object sender, RoutedEventArgs e)
        {
            if (RequestsGrid.SelectedItem is Request selectedRequest)
            {
                var editWindow = new EditedRequestWindow(selectedRequest);
                if (editWindow.ShowDialog() == true)
                {
                    // Обновляем данные заявки
                    selectedRequest.EquipmentType = editWindow.EditedRequest.EquipmentType;
                    selectedRequest.Model = editWindow.EditedRequest.Model;
                    selectedRequest.ProblemDescription = editWindow.EditedRequest.ProblemDescription;
                    selectedRequest.Status = editWindow.EditedRequest.Status;

                    // Перерисовываем DataGrid
                    Requests.Clear();
                    foreach (var req in DataService.Requests)
                        Requests.Add(req);
                }
            }
            else
            {
                MessageBox.Show("Сначала создайте заявку!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void AddRequest_Click(object sender, RoutedEventArgs e)
        {
            var addWindow = new AddRequestWindow();
            if (addWindow.ShowDialog() == true)
            {
                Requests.Add(addWindow.NewRequest);
                DataService.Requests.Add(addWindow.NewRequest);
            }
        }

    }
}