using System;
using System.Collections.Generic;

#nullable disable

namespace REST_API.Models
{
    public partial class Airline
    {
        public Airline()
        {
            Flights = new HashSet<Flight>();
            Flightschedules = new HashSet<Flightschedule>();
        }

        public short AirlineId { get; set; }
        public string Iata { get; set; }
        public string Airlinename { get; set; }
        public short BaseAirport { get; set; }

        public virtual Airport BaseAirportNavigation { get; set; }
        public virtual ICollection<Flight> Flights { get; set; }
        public virtual ICollection<Flightschedule> Flightschedules { get; set; }
    }
}
