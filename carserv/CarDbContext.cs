using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using carserv.Models;
using Microsoft.EntityFrameworkCore;

namespace carserv
{
    public class CarDbContext : DbContext
    {

        
        public DbSet<CarServiceRequest> Requests { get; set; }
        public DbSet<Employee>Employees { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=carServ.db");
        }
    }
}
