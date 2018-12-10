using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevFleet.Models
{
    public class FleetResponse
    {
        public string Message { get; set; } = string.Empty;
        public bool Status { get; set; }
        public Fleet Data { get; set; }
    }
    public class FleetResponses
    {
        public string Message { get; set; } = string.Empty;
        public bool Status { get; set; }
        public List<Fleet> Data { get; set; }
    }
}
