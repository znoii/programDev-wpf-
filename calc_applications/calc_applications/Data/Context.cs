using calc_applications.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calc_applications.Data
{
    public class Context
    {
        public static List<Request> Requests { get; set; } = new List<Request>
        {
            new Request {id = 1, fullname = "Петр Иванов", status = "Новая"},
            new Request {id = 2, fullname = "Елизавета Гончарова", status = "В работе"}
        };

    }
}
