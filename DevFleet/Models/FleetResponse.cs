using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevFleet.Models
{
    public class FleetResponse: GeneralResponse
    {
        public Fleet Data { get; set; }
    }
    public class FleetResponses: GeneralResponse
    {
        public List<Fleet> Data { get; set; }
    }
    public class GeneralResponse
    {
        public string Message { get; set; } = string.Empty;
        public bool Status { get; set; }
    }
}
