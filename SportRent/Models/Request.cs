using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportRent.Models
{
    public class Request
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int InventoryId { get; set; }
        public DateTime CreatedAt {  get; set; } = DateTime.Now;
        public DateTime ExpectedClosed { get; set; }
        public DateTime? ClosedAt { get; set; }
        public RequestStatus Status { get; set; }

    }
    public enum RequestStatus
    {
        Забронирован, 
        Используется, 
        Просрочен,
        Завершен
    }
}
