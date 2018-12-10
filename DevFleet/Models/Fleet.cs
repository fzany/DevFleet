using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevFleet.Models
{
    public class Fleet
    {
        public string Id { get; set; }
        public string Plate_Number { get; set; } = string.Empty;
        public string Serial_Number { get; set; } = string.Empty;
        public Colors Colour { get; set; } 
        public int Purchase_Year { get; set; }
        public int Trips_Count { get; set; }
        public DateTime Insurance_Expiry { get; set; }
        public DateTime Last_Repair { get; set; }
        public DateTime Acquired { get; set; }
        public Driver Driver { get; set; } 
        public Type Type { get; set; }
        public int Number_of_Seaters { get; set; } 
        public bool Is_In_Good_Condition { get; set; }
        public Commute_Origin Origin { get; set; }
        public Commute_Destination Destination  { get; set; }
        public string Engine_Number { get; set; } = string.Empty;

    }
}
