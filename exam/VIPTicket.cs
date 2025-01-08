using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exam
{
    public class VIPTicket: Ticket
    {
        //properties
        public string AdditionalExtras { get; set; }
        public decimal AdditionalCost { get; set; }
    }
}
