using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportRent.Models
{
    public class Inventory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Size { get; set; }
        public int PricePerHour { get; set; }
        public bool IsAvailable { get; set; }
        public bool HasDiscount { get; set; }
    }
}
