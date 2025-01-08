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

        //constructors
        public VIPTicket(string name, decimal price, int availableTickets, string additionalExtras, decimal additionalCost) : base(name, price, availableTickets)
        {
            AdditionalExtras = additionalExtras;
            AdditionalCost = additionalCost;
        }


        //methods
        public override string ToString()
        {
            return $"{Name} - {Price} ({AdditionalExtras}) [AVAILABLE -{AvailableTickets}]";
        }
    }
}
