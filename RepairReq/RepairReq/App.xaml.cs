using Microsoft.EntityFrameworkCore;
using RepairReq.Models;
using System.Configuration;
using System.Data;
using System.Windows;

namespace RepairReq
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static RepairDbContext? _dbContext;
        public static RepairDbContext DbContext => _dbContext ??= new RepairDbContext();
        public static Master? CurrentUser { get; set; }
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);


            DbContext.Masters.Load();
            DbContext.Requests.Load();
            DbContext.Statuses.Load();
        }
    }

}
