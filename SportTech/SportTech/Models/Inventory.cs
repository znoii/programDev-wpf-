using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SportTech.Models
{
    public class Inventory
    {
        [Key]
        public string ArticleNum { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Type { get; set; } = null!;
        public DateOnly Date { get; set; }
        public int? UserId { get; set; }  
        public User? User { get; set; }

        public int StatusId { get; set; }
        public Status Status { get; set; } = null!;

    }
}
