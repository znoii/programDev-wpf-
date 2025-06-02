using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairReq.Models
{
    public class Request
    {
        [Key]
        public string Id { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Type { get; set; } = null!;
        public string Problem { get; set; } = null!;
        public DateOnly CreatedAt { get; set; }
        public int? MasterId { get; set; }
        public Master Master { get; set; } 
        public int StatusId { get; set; }
        public Status Status { get; set; } = null!;

    }
}
