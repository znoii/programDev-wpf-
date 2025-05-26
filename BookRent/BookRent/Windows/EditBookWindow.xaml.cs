using BookRent.Models;
using Microsoft.EntityFrameworkCore;
using System.Windows;

namespace BookRent
{
    public partial class EditBookWindow : Window
    {
        private readonly Book _book;

        public EditBookWindow(Book book)
        {
            InitializeComponent();
            _book = book;
            Loaded += EditBookWindow_Loaded;
        }

        private void EditBookWindow_Loaded(object sender, RoutedEventArgs e)
        {
            CurrentTitleText.Text = _book.Title;

            StatusComboBox.ItemsSource = App.DbContext.Statuses.ToList();
            UserComboBox.ItemsSource = App.DbContext.Users.ToList();

            StatusComboBox.SelectedItem = App.DbContext.Statuses.Find(_book.StatusId);
            UserComboBox.SelectedItem = _book.UserId.HasValue ?
                App.DbContext.Users.Find(_book.UserId.Value) : null;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            _book.StatusId = ((Status)StatusComboBox.SelectedItem).Id;
            _book.UserId = UserComboBox.SelectedItem != null ?
                ((User)UserComboBox.SelectedItem).Id : null;

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