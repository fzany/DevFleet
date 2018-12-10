using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevFleet.Models
{
    /// <summary>
    /// Class for retrieving fleets
    /// </summary>
    public class Fleet
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Guid { get; set; }
        /// <summary>
        /// Unique field
        /// </summary>
        public string Engine_Number { get; set; } = string.Empty;
        /// <summary>
        /// Unique field
        /// </summary>
        public string Plate_Number { get; set; } = string.Empty;
        public string Insurance_Number { get; set; } = string.Empty;
        public int Purchase_Year { get; set; }
        public int Trips_Count { get; set; }
        public int Number_of_Seaters { get; set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime Insurance_Expiry { get; set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime Last_Repair { get; set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime Acquired { get; set; }
        public bool Is_In_Good_Condition { get; set; }
        public Driver Driver { get; set; }
        public Type Type { get; set; }
        public Color Colour { get; set; }
        public Commute_Origin Origin { get; set; }
        public Commute_Destination Destination  { get; set; }

    }
}
