using carserv.Models;
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

namespace carserv.Windows
{
    /// <summary>
    /// Interaction logic for EmployeeWindow.xaml
    /// </summary>
    public partial class EmployeeWindow : Window
    {
        private readonly CarServiceRequest _request;
        private readonly CarDbContext _context;
        public EmployeeWindow(CarServiceRequest request)
        {
            InitializeComponent();
            _request = request;
            _context = new CarDbContext();

            EmployeeComboBox.ItemsSource = _context.Employees.ToList();

            if (_request.EmployeeId != null)
            {
                EmployeeComboBox.SelectedItem = _context.Employees
                    .FirstOrDefault(e => e.Id == _request.EmployeeId);
            }
        }
        private void AssignClick(object sender, RoutedEventArgs e)
        {
            if (EmployeeComboBox.SelectedItem is Employee selectedEmployee)
            {
                _request.EmployeeId = selectedEmployee.Id;
                _context.SaveChanges();
                DialogResult = true;
                Close();
            }
            else
            {
                MessageBox.Show("Выберите сотрудника из списка",
                              "Ошибка",
                              MessageBoxButton.OK,
                              MessageBoxImage.Warning);
            }
        }
    }
}
