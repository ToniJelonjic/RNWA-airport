using System;
using System.Collections.Generic;

#nullable disable

namespace REST_API.Models
{
    public partial class FlightLog
    {
        public uint FlightLogId { get; set; }
        public DateTime LogDate { get; set; }
        public string User { get; set; }
        public int FlightId { get; set; }
        public string FlightnoOld { get; set; }
        public string FlightnoNew { get; set; }
        public short FromOld { get; set; }
        public short ToOld { get; set; }
        public short FromNew { get; set; }
        public short ToNew { get; set; }
        public DateTime DepartureOld { get; set; }
        public DateTime ArrivalOld { get; set; }
        public DateTime DepartureNew { get; set; }
        public DateTime ArrivalNew { get; set; }
        public int AirplaneIdOld { get; set; }
        public int AirplaneIdNew { get; set; }
        public short AirlineIdOld { get; set; }
        public short AirlineIdNew { get; set; }
        public string Comment { get; set; }

        public virtual Flight Flight { get; set; }
    }
}
