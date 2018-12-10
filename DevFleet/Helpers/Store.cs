using DevFleet.Models;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DevFleet.Helpers
{
    public class Store
    {
        public static readonly DataContext context = new DataContext();

        public static FleetResponse Add(Fleet data)
        {
            //initialize response
            FleetResponse response = new FleetResponse();

            //Check for existence of unique identifiers (engine number and plate number)
            if (string.IsNullOrWhiteSpace(data.Engine_Number))
            {
                response.Status = false;
                response.Message = Constants.Provide_Engine_Number;
                return response;
            }
            data.Engine_Number = data.Engine_Number.ToLower();
            if (string.IsNullOrWhiteSpace(data.Plate_Number))
            {
                response.Status = false;
                response.Message = Constants.Provide_Plate_Number;
                return response;
            }
            data.Plate_Number = data.Plate_Number.ToLower();

            //check for the existence in the database.
            if (CheckExistence(d => d.Engine_Number, data.Engine_Number))
            {
                response.Status = false;
                response.Message = Constants.Engine_Exists;
                return response;
            }
            if (CheckExistence(d => d.Plate_Number, data.Plate_Number))
            {
                response.Status = false;
                response.Message = Constants.Plate_Number_Exists;
                return response;
            }
            
            //insert the data into the database
            context.Fleet.Insert(data);

            //prepare response data
            response.Status = true;
            response.Message = Constants.Success;

            //return the newly inserted data from the database.
            response.Data = FetchOne(f => f.Engine_Number, data.Engine_Number);
            return response;
        }

        /// <summary>
        /// Fetch fleets by Expression
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Fleet FetchOne(Expression<Func<Fleet, string>> expression, string value)
        {
            IMongoQuery query = Query<Fleet>.EQ(expression, value.ToLower());
            return context.Fleet.FindOne(query);
        }

        /// <summary>
        /// Check if Expression exists in the database.
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool CheckExistence(Expression<Func<Fleet, string>> expression, string value)
        {
            IMongoQuery query = Query<Fleet>.EQ(expression, value.ToLower());
            Fleet result = context.Fleet.FindOne(query);
            if (result == null)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Update a Fleet
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static FleetResponse Update(Fleet data)
        {
            //initialize response data.
            FleetResponse response = new FleetResponse();

            //Check for existence of unique identifiers (engine number and plate number)
            if (string.IsNullOrWhiteSpace(data.Engine_Number))
            {
                response.Status = false;
                response.Message = Constants.Provide_Engine_Number;
                return response;
            }
            if (string.IsNullOrWhiteSpace(data.Plate_Number))
            {
                response.Status = false;
                response.Message = Constants.Provide_Plate_Number;
                return response;
            }

            //check if a guid is included in the data
            if (string.IsNullOrWhiteSpace(data.Guid))
            {
                response.Status = false;
                response.Message = Constants.Provide_Guid;
                return response;
            }

            //check if the fleet exists on the system via guid.
            if (!CheckExistence(f => f.Guid, data.Guid))
            {
                response.Status = false;
                response.Message = Constants.Non_Exist;
                return response;
            }

            //Update the Contact
            IMongoQuery query = Query<Fleet>.EQ(d => d.Guid, data.Guid);
            IMongoUpdate replacement = Update<Fleet>.Replace(data);
            context.Fleet.Update(query, replacement);

            //prepare response data
            response.Status = true;
            response.Message = Constants.Success;

            //return the newly inserted data from the database.
            response.Data = FetchOne(f => f.Engine_Number, data.Engine_Number);
            return response;
        }

        //Fetch all fleets
        public static FleetResponses FetchAll()
        {
            //prepare responses
            FleetResponses responses = new FleetResponses();
            MongoCursor<Fleet> results = context.Fleet.FindAll();

            //test for emptiness
            if (results.Count() == 0)
            {
                responses.Status = true;
                responses.Message = Constants.Empty_List;
                responses.Data = new List<Fleet>() { };
                return responses;
            }
            responses.Status = true;

            //return data
            responses.Data = results.ToList();
            return responses;
        }

        /// <summary>
        /// Fetch a fleet by guid
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public static FleetResponse FetchById(string guid)
        {
            //prepare response
            FleetResponse fleet = new FleetResponse();
            //check for existence
            if (!CheckExistence(f => f.Guid, guid))
            {
                fleet.Status = false;
                fleet.Message = Constants.Non_Exist;
                return fleet;
            }
            fleet.Data = FetchOne(f => f.Guid, guid);

            //send response
            fleet.Status = true;
            return fleet;
        }

        /// <summary>
        /// Fetch fleets by type
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static FleetResponses FetchByType(int type)
        {
            //initialize response
            FleetResponses responses = new FleetResponses();
            IMongoQuery query = Query<Fleet>.EQ(d => (int)d.Type, type);
            responses.Data = context.Fleet.Find(query).ToList();

            //prepare response
            responses.Status = true;
            return responses;
        }

        /// <summary>
        /// Delete a fleet by guid
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public static GeneralResponse Delete(string guid)
        {
            //prepare response
            GeneralResponse response = new GeneralResponse();

            //check if contact exists
            if (!CheckExistence(f => f.Guid, guid))
            {
                response.Status = false;
                response.Message = Constants.Non_Exist;
                return response;
            }
            //proceed to delete the Fleet
            IMongoQuery query = Query<Fleet>.EQ(d => d.Guid, guid);
            context.Fleet.Remove(query);

            //send response
            response.Status = true;
            response.Message = Constants.Success;
            return response;
        }


    }
}
