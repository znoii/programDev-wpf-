using IT_S.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT_S.Services
{
    public static class DataService
    {
        public static List<Engineer> Engineers { get; set; } = new List<Engineer>
            {
            new Engineer {Id = 1, FullName = "Петров" },
            new Engineer {Id = 3, FullName = "Кузнецов" }
            };
        public static List<Request> Requests { get; set; } = new List<Request>
        {
            new Request
            {
                RequestNumber = 1,
                AssignedEngineer = Engineers[0],
                ClientName = "Александра",
                DateAdded = DateTime.Now,
                EquipmentType = "Ноутбук",
                Model = "Lenovo ThinkPad X1",
                ProblemDescription = "Не включается после обновления",
                PhoneNumber = "+7 900 123-45-67",
                Status = "В В ремонте"
            }
        };
        
    }
}
