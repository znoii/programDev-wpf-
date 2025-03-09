using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportRent.Models;

namespace SportRent.Data
{
    public static class Service
    {
        public static List<User> Users { get; set; } = new List<User>
        {
            new User { Id = 1, 
                Name = "Admin1", 
                Email = "admin@sport.com",
                GeneralDiscount = 1, //no discount
                Password = "123", 
                Role = UserRole.Admin },
            new User { Id = 2, 
                Name = "User1", 
                Email = "user@sport.com",
                GeneralDiscount = 0.9 , //no discount
                Password = "123", 
                Role = UserRole.Visitor }

        };
        
        
        public static List<Request> Requests { get; set; } = new List<Request>
        {
                new Request { Id = 1, UserId = 2, InventoryId = 1, 
                    CreatedAt = DateTime.Now.AddDays(-2), 
                    ExpectedClosed = DateTime.Now.AddDays(3), 
                    Status = RequestStatus.Забронирован },
                new Request { Id = 2, UserId = 2, InventoryId = 2, 
                    CreatedAt = DateTime.Now.AddDays(-5), 
                    ExpectedClosed = DateTime.Now.AddDays(-1), 
                    Status = RequestStatus.Просрочен },
                new Request { Id = 3,
                    UserId = 2, InventoryId = 1, CreatedAt = DateTime.Now.AddDays(-7),
                    ExpectedClosed = DateTime.Now.AddDays(-2),
                    ClosedAt = DateTime.Now.AddDays(-1), Status = RequestStatus.Завершен}
        };
        
        public static List<Inventory> Inventories { get; set; } = new List<Inventory>
        {
            new Inventory { Id = 1, Name = "Горный велосипед",
                Description = "Велосипед лала", Size = "M", PricePerHour = 15, 
                IsAvailable = true, HasDiscount = false },
            new Inventory { Id = 2, Name = "Лыжи Atomic",
                Description = "Лыжи буб", Size = "L", PricePerHour = 10, 
                IsAvailable = true, HasDiscount = true }
        };
        
    }
}
