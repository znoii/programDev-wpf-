using calc_applications.Data;
using calc_applications.Models;
using calc_applications.Views;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace calc_applications
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Request> Requests { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            Requests = new ObservableCollection<Request>(Context.Requests);
            DataContext = this;
        }
        private void AddRequest_Click(object sender, RoutedEventArgs e)
        {
            var addWindow = new AddRequestWindow();
            if (addWindow.ShowDialog() == true)
            {
                Requests.Add(addWindow.NewRequest);
                Context.Requests.Add(addWindow.NewRequest);
            }
        }

        private void EditRequest_Click(object sender, RoutedEventArgs e)
        {
            int id = (int)((Button)sender).Tag;
            var request = Context.Requests.FirstOrDefault(r => r.id == id);
            if (request != null)
            {
                var editWindow = new EditRequestWindow(request);
                if (editWindow.ShowDialog() == true)
                {
                    var updated = Context.Requests.First(r => r.id == id);
                    updated.fullname = editWindow.EditedRequest.fullname;
                    updated.status = editWindow.EditedRequest.status;

                    Requests.Clear();
                    foreach (var req in Context.Requests)
                        Requests.Add(req);
                }
            }
        }
    }
}