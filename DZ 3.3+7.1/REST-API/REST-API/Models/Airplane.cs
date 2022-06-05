using System;
using System.Collections.Generic;

#nullable disable

namespace REST_API.Models
{
    public partial class Airplane
    {
        public Airplane()
        {
            Flights = new HashSet<Flight>();
        }

        public int AirplaneId { get; set; }
        public uint Capacity { get; set; }
        public int TypeId { get; set; }
        public int AirlineId { get; set; }

        public virtual AirplaneType Type { get; set; }
        public virtual ICollection<Flight> Flights { get; set; }
    }
}
