using System;
using System.Collections.Generic;

#nullable disable

namespace REST_API.Models
{
    public partial class Booking
    {
        public int BookingId { get; set; }
        public int FlightId { get; set; }
        public string Seat { get; set; }
        public int PassengerId { get; set; }
        public decimal Price { get; set; }

        public virtual Flight Flight { get; set; }
        public virtual Passenger Passenger { get; set; }
    }
}
