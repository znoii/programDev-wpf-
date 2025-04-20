using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace carserv.Models
{
    public class CarServiceRequest
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string Description { get; set; }
        public string ClientName { get; set; }
        public RequestStatus Status { get; set; } = RequestStatus.New;
        public int? EmployeeId { get; set; }
        public Employee Employee { get; set; }

    }
    public enum RequestStatus {
        New,
        InProgress,
        WaitingForParts,
        Completed
    }

}
