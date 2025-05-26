using BookRent.Models;
using BookRent.Windows;
using Microsoft.EntityFrameworkCore;
using System.Windows;

namespace BookRent
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += OnWindowLoaded;
        }

        private void OnWindowLoaded(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            if (loginWindow.ShowDialog() == true)
            {
                CurrentUserTextBlock.Text = $"Current user: {App.CurrentUser?.FullName}";
                RefreshBooksList();
            }
            else
            {
                Close();
            }
        }

        private void RefreshBooksList()
        {
            BooksListView.ItemsSource = App.DbContext.Books
                .Include(b => b.Status)
                .Include(b => b.User)
                .ToList();
        }

        private void AddBookButton_Click(object sender, RoutedEventArgs e)
        {
            AddBookWindow addWindow = new AddBookWindow();
            if (addWindow.ShowDialog() == true)
            {
                RefreshBooksList();
            }
        }

        private void EditBookButton_Click(object sender, RoutedEventArgs e)
        {
            if (BooksListView.SelectedItem is Book selectedBook)
            {
                EditBookWindow editWindow = new EditBookWindow(selectedBook);
                if (editWindow.ShowDialog() == true)
                {
                    RefreshBooksList();
                }
            }
            else
            {
                MessageBox.Show("Please select a book to edit", "No Selection",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void DeleteBookButton_Click(object sender, RoutedEventArgs e)
        {
            if (BooksListView.SelectedItem is Book selectedBook)
            {
                var result = MessageBox.Show($"Are you sure you want to delete '{selectedBook.Title}'?",
                    "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    App.DbContext.Books.Remove(selectedBook);
                    App.DbContext.SaveChanges();
                    RefreshBooksList();
                }
            }
            else
            {
                MessageBox.Show("Please select a book to delete", "No Selection",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}