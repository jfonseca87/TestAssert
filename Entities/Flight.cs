using System;
using System.Collections.Generic;
using System.Text;

namespace Transversal.Entities
{
    public class Flight
    {
        public int IdFlight { get; set; }
        public string SourceCity { get; set; }
        public string DestinationCity { get; set; }
        public DateTime DepartureDateTime { get; set; }
        public string PlaneNumber { get; set; }
        public string PilotName { get; set; }
    }
}
