using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using Microsoft.EntityFrameworkCore;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Collections.ObjectModel;
using System.Windows.Shapes;
using carserv.Models;
using carserv.Windows;
using System.Runtime.CompilerServices;
using System.Diagnostics;


namespace carserv
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private ObservableCollection<CarServiceRequest> _requests;
        public ObservableCollection<CarServiceRequest> Requests
        {
            get { return _requests; }
            set
            {
                _requests = value;
                OnPropertyChanged();
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            using (var context = new CarDbContext())
            {
                /*text.Requests.Add(new CarServiceRequest
                {
                    ClientName = "Иванов Иван",
                    Description = "Замена масла"
                });
                context.SaveChanges(); */
                if (context.Database.CanConnect())
                {
                    MessageBox.Show("База данных подключена успешно!", "Проверка",
                                   MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Ошибка подключения к базе!", "Ошибка",
                                   MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            InitializeDatabase();
            DataContext = this;
            GetRequests();
        }
        private void InitializeDatabase()
        {
            using (var context = new CarDbContext())
            {
                // Применяем все pending миграции
                context.Database.Migrate();

                if (context.Database.CanConnect())
                {
                    Debug.WriteLine("База данных подключена успешно!");
                }
            }
        }
        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string paramName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(paramName));
        }


        /*private void AddClick(object sender, RoutedEventArgs e)
        {
            AddRequestWindow win = new();
            win.ShowDialog();
            if (win.DialogResult == true)
            {
                GetRequests();
            }
        }*/

        /*private void EditClick(object sender, RoutedEventArgs e)
        {
            if (RequestsList.SelectedItem is CarServiceRequest selected)
            {
                EditRequestWindow win = new(selected);
                win.ShowDialog();
                if (win.DialogResult == true)
                {
                    GetRequests();
                }
            }
            else
            {
                MessageBox.Show("Выберите заявку для редактирования");
            }
        }*/

        private void EmployeeClick(object sender, RoutedEventArgs e)
        {
            if (RequestsList.SelectedItem is CarServiceRequest selected)
            {
                EmployeeWindow win = new(selected);
                win.ShowDialog();
                if (win.DialogResult == true)
                {
                    GetRequests();
                }
            }
            else
            {
                MessageBox.Show("Выберите заявку для назначения ответственного");
            }
        }

        /*private void ManageEmployeesClick(object sender, RoutedEventArgs e)
        {
            //EmployeesWindow win = new();
            win.ShowDialog();
            GetRequests();
        }*/

        private void GetRequests()
        {
            using var context = new CarDbContext();
            Requests = new ObservableCollection<CarServiceRequest>(
                context.Requests.Include(r => r.Employee).ToList());
        }

    }
}