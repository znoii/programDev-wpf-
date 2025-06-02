using Microsoft.EntityFrameworkCore;
using RepairReq.Models;

namespace RepairReq.Models
{
    public class RepairDbContext : DbContext
    {
        private static readonly Master[] masters = [
            new Master() {
                Id = 1,
                FullName = "Маршева Арина Анатольевна",
                Login = "master1",
                Password = "pass1",
                PhoneNumber = "89131234567",
                RegDate = new DateOnly(2023, 01, 15)
            },
            new Master() {
                Id = 2,
                FullName = "Хрипко Марго",
                Login = "master2",
                Password = "pass2",
                PhoneNumber = "89137654321",
                RegDate = new DateOnly(2023, 02, 20)
            }
        ];

        private static readonly Status[] statuses = [
            new Status() { Id = 1, ReqStatus = "В обработке" },
            new Status() { Id = 2, ReqStatus = "В работе" },
            new Status() { Id = 3, ReqStatus = "Завершена" }
        ];

        private static readonly Request[] requests = [
            new Request() {
                Id = "RQ001",
                Description = "Не включается компьютер",
                Type = "Ремонт",
                Problem = "Полное описание проблемы",
                CreatedAt = new DateOnly(2023, 05, 10),
                StatusId = 1, MasterId = 1
            },
            new Request() {
                Id = "RQ002",
                Description = "термопаста",
                Type = "Обслуживание",
                Problem = "Перегрев",
                CreatedAt = new DateOnly(2023, 05, 12),
                StatusId = 2, MasterId = 2
            }
        ];

        public DbSet<Master> Masters { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Request> Requests { get; set; }

        public RepairDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = repair.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Master>().HasData(masters);
            modelBuilder.Entity<Status>().HasData(statuses);
            modelBuilder.Entity<Request>().HasData(requests);
        }
    }
}