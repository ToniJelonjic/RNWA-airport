using System;
using System.Collections.Generic;

#nullable disable

namespace App.Models
{
    public partial class AirportGeo
    {
        public short AirportId { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }

        public virtual Airport Airport { get; set; }
    }
}
