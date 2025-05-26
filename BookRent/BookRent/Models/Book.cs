using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRent.Models
{
    public class Book
    {
        [Key]
        public string BookId { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Genre { get; set; } = null!;
        public string? Description { get; set; }
        public DateOnly DateStart { get; set; }

        public int? UserId { get; set; }
        public User? User { get; set; }

        public int StatusId { get; set; }
        public Status Status { get; set; } = null!;
    }
}
