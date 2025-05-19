using Microsoft.EntityFrameworkCore;

namespace SportTech.Models
{
    public class SportDbContext : DbContext
    {
        private static readonly User[] users = [
            new User() { Id = 1, FullName = "Marsheva Arina", Login = "123", Password = "pass1", PhoneNumber = "89139832717", RegDate = new DateOnly(2021,11,01) },
            new User() { Id = 2, FullName = "Chripko Margo", Login = "1234", Password = "pass2", PhoneNumber = "89139264545", RegDate = new DateOnly(2021,11,01) },
            new User() { Id = 3, FullName = "Kovaleva Anna", Login = "12", Password = "pass3", PhoneNumber = "123", RegDate = new DateOnly(2021,11,01) }
        ];

        private static readonly Status[] statuses = [
            new Status() { Id = 1, StatusInv = "В наличии" },
            new Status() { Id = 2, StatusInv = "Выдана" },
            new Status() { Id = 3, StatusInv = "В обслуживании" }
        ];

        private static readonly Inventory[] inventories = [
            new Inventory() { ArticleNum = "B6", Date = new DateOnly(2021,11,01), Name = "Ball", Type = "Equipment", StatusId = 2, UserId = 2 },
            new Inventory() { ArticleNum = "B7", Date = new DateOnly(2021,11,01), Name = "Dumbbells", Type = "Equipment", StatusId = 3, UserId = 3 },
            new Inventory() { ArticleNum = "B8", Date = new DateOnly(2021,11,01), Name = "Carpet", Type = "Equipment", StatusId = 1, UserId = null }
        ];

        public DbSet<User> Users { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Status> Statuses { get; set; }

        public SportDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=database.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Status>().HasData(statuses);
            modelBuilder.Entity<User>().HasData(users);
            modelBuilder.Entity<Inventory>().HasData(inventories);
        }
    }
}