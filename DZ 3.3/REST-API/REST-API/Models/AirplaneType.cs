using System;
using System.Collections.Generic;

#nullable disable

namespace REST_API.Models
{
    public partial class AirplaneType
    {
        public AirplaneType()
        {
            Airplanes = new HashSet<Airplane>();
        }

        public int TypeId { get; set; }
        public string Identifier { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Airplane> Airplanes { get; set; }
    }
}
