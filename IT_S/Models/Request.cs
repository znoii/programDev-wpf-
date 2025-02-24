using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT_S.Models
{
    public class Request
    {
        public int RequestNumber { get; set; }
        public required DateTime DateAdded { get; set; }
        public required string EquipmentType { get; set; }
        public required string Model { get; set; }
        public required string ProblemDescription { get; set; }
        public required string ClientName { get; set; }
        public required string PhoneNumber { get; set; }
        public required string Status { get; set; }
        public required Engineer AssignedEngineer { get; set; }
    }
}
