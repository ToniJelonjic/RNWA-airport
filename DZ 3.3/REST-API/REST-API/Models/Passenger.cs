using System;
using System.Collections.Generic;

#nullable disable

namespace REST_API.Models
{
    public partial class Passenger
    {
        public Passenger()
        {
            Bookings = new HashSet<Booking>();
        }

        public int PassengerId { get; set; }
        public string Passportno { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        public virtual Passengerdetail Passengerdetail { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
