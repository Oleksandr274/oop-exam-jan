using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace exam
{
    public enum EventType{ Music, Comedy, Theatre }
    public class Event: IComparable<Event>
    {
        //properties
        public string Name { get; set; }
        public DateTime EventDate { get; set; }
        public List<Ticket> Tickets = new List<Ticket>();
        public EventType TypeOfEvent { get; set; }



        //methods

        public override string ToString()
        {
            return $"{Name} - {EventDate.ToShortDateString()}";
        }


        public int CompareTo(Event? other)
        {
            return this.EventDate.CompareTo(other.EventDate);
        }
    }
}
