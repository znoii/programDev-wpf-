using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportRent.Models
{
    public class RequestViewModel
    {
        public int Id { get; set; }
        public RequestStatus Status { get; set; }
        public string ClosedAt { get; set; }
    }
}
