using System.Configuration;
using System.Data;
using System.Windows;
using BookRent.Models;
using Microsoft.EntityFrameworkCore;

namespace BookRent
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static BookDbContext? _dbContext;
        public static BookDbContext DbContext => _dbContext ??= new BookDbContext();
        public static User? CurrentUser { get; set; }
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

           
                DbContext.Books.Load();
                DbContext.Users.Load();
                DbContext.Statuses.Load();
        }
    }

}
