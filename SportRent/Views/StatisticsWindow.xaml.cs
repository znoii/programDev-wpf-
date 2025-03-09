using SportRent.Data;
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
    /// Interaction logic for StatisticsWindow.xaml
    /// </summary>
    public partial class StatisticsWindow : Window
    {
        public StatisticsWindow()
        {
            InitializeComponent();
            LoadStatistics();
        }

        private void LoadStatistics()
        {
            var requests = Service.Requests;

            // 1. Общее количество заявок
            TotalRequestsText.Text = requests.Count.ToString();

            // 2. Среднее время выполнения заявки (в днях)
            var completedRequests = requests.Where(r => r.ClosedAt.HasValue).ToList();
            if (completedRequests.Any())
            {
                double avgTime = completedRequests
                    .Select(r => (r.ClosedAt.Value - r.CreatedAt).TotalDays)
                    .Average();
                AverageCompletionTimeText.Text = avgTime.ToString("0.0"); // Округляем до 1 знака
            }
            else
            {
                AverageCompletionTimeText.Text = "Нет данных";
            }
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
