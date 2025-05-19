using Microsoft.EntityFrameworkCore;
using SportTech.Models;
using System.Configuration;
using System.Data;
using System.Windows;

namespace SportTech
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static SportDbContext? _dbContext;
        public static SportDbContext DbContext => _dbContext ??= new SportDbContext();
        public static User? CurrentUser { get; set; }
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            Task.Run(() =>
            {
                DbContext.Users.Load();
                DbContext.Statuses.Load();
                DbContext.Inventories.Load();

                //var LoginWindow = new LoginWindow();
                //LoginWindow.ShowDialog();

                //if (LoginWindow.DialogResult == true && CurrentUser != null)
                //{ 
                //    var MainWindow = new MainWindow();
                //    MainWindow.Show();
                //}
            });
        }

        //StartupUri="MainWindow.xaml"
    }

}
