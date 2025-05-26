using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace BookRent.Models
{
    public class BookDbContext : DbContext
    {
        private static readonly User[] users = [
            new User() { Id = 1, FullName = "Marsheva Arina", Login = "123", Password = "pass1", 
                PhoneNumber = "89139832717", RegDate = new DateOnly(2021,11,01) },
            new User() { Id = 2, FullName = "Chripko Margo", Login = "1234", Password = "pass2", 
                PhoneNumber = "89139264545", RegDate = new DateOnly(2021,11,01) },
            new User() { Id = 3, FullName = "Kovaleva Anna", Login = "12", Password = "pass3", 
                PhoneNumber = "123", RegDate = new DateOnly(2021,11,01) }
        ];
        private static readonly Status[] statuses = [
            new Status() { Id = 1, StatusAvail = "в наличии" },
            new Status() { Id = 2, StatusAvail = "выдана" },
            new Status() { Id = 3, StatusAvail = "на обслуживании" }
        ];
        private static readonly Book[] books = [
            new Book() { BookId = "A1", Genre = "Horror", Title = "Counry of nightmares", StatusId = 1, 
                UserId = 1, DateStart = new DateOnly(2022,10,01), Description = "for 2 weeks" },
            new Book() { BookId = "A2", Genre = "Fantasy", Title = "Wonderland", StatusId = 2,
                UserId = 2, DateStart = new DateOnly(2022,11,15), Description = "for 3 weeks" },
            new Book() { BookId = "A3", Genre = "Adventure", Title = "Treasure island", StatusId = 3,
                UserId = 3, DateStart = new DateOnly(2023,01,27), Description = "nothing" }
            ];
        public DbSet<User> Users { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Book> Books { get; set; }


        public BookDbContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = database.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().HasData(users);
            modelBuilder.Entity<Status>().HasData(statuses);
            modelBuilder.Entity<Book>().HasData(books);
            

        }
    }
}
