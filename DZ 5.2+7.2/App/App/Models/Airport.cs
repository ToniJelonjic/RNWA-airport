using System;
using System.Collections.Generic;

#nullable disable

namespace App.Models
{
    public partial class Airport
    {
        public Airport()
        {
            Airlines = new HashSet<Airline>();
            FlightFromNavigations = new HashSet<Flight>();
            FlightToNavigations = new HashSet<Flight>();
            FlightscheduleFromNavigations = new HashSet<Flightschedule>();
            FlightscheduleToNavigations = new HashSet<Flightschedule>();
        }

        public short AirportId { get; set; }
        public string Iata { get; set; }
        public string Icao { get; set; }
        public string Name { get; set; }

        public virtual AirportGeo AirportGeo { get; set; }
        public virtual AirportReachable AirportReachable { get; set; }
        public virtual ICollection<Airline> Airlines { get; set; }
        public virtual ICollection<Flight> FlightFromNavigations { get; set; }
        public virtual ICollection<Flight> FlightToNavigations { get; set; }
        public virtual ICollection<Flightschedule> FlightscheduleFromNavigations { get; set; }
        public virtual ICollection<Flightschedule> FlightscheduleToNavigations { get; set; }
    }
}
