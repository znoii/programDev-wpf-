using BookRent.Models;
using Microsoft.EntityFrameworkCore;
using System.Windows;

namespace BookRent
{
    public partial class AddBookWindow : Window
    {
        public AddBookWindow()
        {
            InitializeComponent();
            Loaded += AddBookWindow_Loaded;
        }

        private void AddBookWindow_Loaded(object sender, RoutedEventArgs e)
        {
            StatusComboBox.ItemsSource = App.DbContext.Statuses.ToList();
            StatusComboBox.SelectedIndex = 0; 
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {

            var newBook = new Book
            {
                BookId = BookIdTextBox.Text.Trim(),
                Title = TitleTextBox.Text.Trim(),
                Genre = GenreTextBox.Text.Trim(),
                Description = "",
                DateStart = DateOnly.FromDateTime(DateTime.Now),
                StatusId = ((Status)StatusComboBox.SelectedItem).Id
            };

            try
            {
                App.DbContext.Books.Add(newBook);
                App.DbContext.SaveChanges(); 

                DialogResult = true;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}",
                    "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}