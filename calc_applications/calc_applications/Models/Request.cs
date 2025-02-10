using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calc_applications.Models
{
    public class Request
    {
        public int id {  get; set; }
        public required string  fullname { get; set; } 
        public required string status { get; set; } 


    }
}
