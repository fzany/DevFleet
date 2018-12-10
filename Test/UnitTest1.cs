using DevFleet.Helpers;
using DevFleet.Models;
using System;
using Xunit;

namespace Test
{
    public class UnitTest1
    {
        /// <summary>
        /// Test for Adding a new fleet.
        /// </summary>
        [Fact]
        public void AddFleet()
        {
            Fleet fleet = new Fleet
            {
                Acquired = DateTime.UtcNow.AddDays(-50),
                Colour = Color.White,
                Destination = Commute_Destination.Abeokuta,
                Origin = Commute_Origin.Ikoyi_Lagos,
                Driver = Driver.David_Olatunde,
                Engine_Number = "Engine001",
                Insurance_Expiry = DateTime.UtcNow.AddYears(4),
                Insurance_Number = "Insure001",
                Is_In_Good_Condition = true,
                Last_Repair = DateTime.UtcNow.AddMonths(-4),
                Number_of_Seaters = 18,
                Plate_Number = "LSR-033-383",
                Purchase_Year = 2017,
                Trips_Count = 45,
                Type = DevFleet.Models.Type.Bus,
                Manufacturer = Manufacturer.Toyota

            };

            //insert fleet
            FleetResponse result = Store.Add(fleet);
            Assert.True(result.Status);
        }
        /// <summary>
        /// Test for updating a fleet.
        /// </summary>
        [Fact]
        public void UpdateFleet()
        {
            string fleet_id = Guid.NewGuid().ToString();

            //Modify Fleet data.
            Fleet fleet = new Fleet
            {
                Acquired = DateTime.UtcNow.AddDays(-50),
                Colour = Color.White,
                Destination = Commute_Destination.Abeokuta,
                Origin = Commute_Origin.Ikoyi_Lagos,
                Driver = Driver.David_Olatunde,
                Engine_Number = "Engine001",
                Insurance_Expiry = DateTime.UtcNow.AddYears(4),
                Insurance_Number = "Insure002",
                Is_In_Good_Condition = true,
                Last_Repair = DateTime.UtcNow.AddMonths(-4),
                Number_of_Seaters = 18,
                Plate_Number = "LSR-033-383",
                Purchase_Year = 2017,
                Trips_Count = 45,
                Type = DevFleet.Models.Type.Bus,
                Manufacturer = Manufacturer.Toyota

            };

            //send for update
            FleetResponse result = Store.Update(fleet);

            Assert.True(result.Status);
        }
        /// <summary>
        /// Test for deleting a fleet.
        /// </summary>
        [Fact]
        public void DeleteFleet()
        {
            string fleet_id = Guid.NewGuid().ToString();
            bool is_Exists = Store.CheckExistence(d => d.Guid, fleet_id);
            Assert.True(is_Exists);
            Store.Delete(fleet_id);
            Assert.True(is_Exists);
        }

        /// <summary>
        /// Test for fetching a fleet
        /// </summary>
        [Fact]
        public void FetchFleet()
        {
            string fleet_id = Guid.NewGuid().ToString();
            FleetResponse fleet = Store.FetchById(fleet_id);
            Assert.NotNull(fleet);
        }

        /// <summary>
        /// Test for fetching all fleets.
        /// </summary>
        [Fact]
        public void FetchAllFleets()
        {
            FleetResponses fleets = Store.FetchAll();
            Assert.NotEmpty(fleets.Data);
        }

        /// <summary>
        /// Test for fetching fleets by type
        /// </summary>
        [Fact]
        public void FetchFleetsByType()
        {
            int type = (int)DevFleet.Models.Type.Car;
            FleetResponses fleets = Store.FetchByType(type);
            Assert.NotEmpty(fleets.Data);
        }

    }
}
