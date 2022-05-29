using System;
using System.Collections.Generic;

#nullable disable

namespace App.Models
{
    public partial class Flight
    {
        public Flight()
        {
            Bookings = new HashSet<Booking>();
            FlightLogs = new HashSet<FlightLog>();
        }

        public int FlightId { get; set; }
        public string Flightno { get; set; }
        public short From { get; set; }
        public short To { get; set; }
        public DateTime Departure { get; set; }
        public DateTime Arrival { get; set; }
        public short AirlineId { get; set; }
        public int AirplaneId { get; set; }

        public virtual Airline Airline { get; set; }
        public virtual Airplane Airplane { get; set; }
        public virtual Flightschedule FlightnoNavigation { get; set; }
        public virtual Airport FromNavigation { get; set; }
        public virtual Airport ToNavigation { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<FlightLog> FlightLogs { get; set; }
    }
}
