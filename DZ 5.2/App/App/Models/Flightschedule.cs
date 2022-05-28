using System;
using System.Collections.Generic;

#nullable disable

namespace App.Models
{
    public partial class Flightschedule
    {
        public Flightschedule()
        {
            Flights = new HashSet<Flight>();
        }

        public string Flightno { get; set; }
        public short From { get; set; }
        public short To { get; set; }
        public TimeSpan Departure { get; set; }
        public TimeSpan Arrival { get; set; }
        public short AirlineId { get; set; }
        public bool? Monday { get; set; }
        public bool? Tuesday { get; set; }
        public bool? Wednesday { get; set; }
        public bool? Thursday { get; set; }
        public bool? Friday { get; set; }
        public bool? Saturday { get; set; }
        public bool? Sunday { get; set; }

        public virtual Airline Airline { get; set; }
        public virtual Airport FromNavigation { get; set; }
        public virtual Airport ToNavigation { get; set; }
        public virtual ICollection<Flight> Flights { get; set; }
    }
}
