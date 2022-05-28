using System;
using System.Collections.Generic;

#nullable disable

namespace App.Models
{
    public partial class Passengerdetail
    {
        public int PassengerId { get; set; }
        public DateTime Birthdate { get; set; }
        public string Sex { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public short Zip { get; set; }
        public string Country { get; set; }
        public string Emailaddress { get; set; }
        public string Telephoneno { get; set; }

        public virtual Passenger Passenger { get; set; }
    }
}
