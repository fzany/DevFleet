using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevFleet.Helpers;
using DevFleet.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevFleet.Controllers
{
    [Produces("application/json")]
    [ApiController]
    public class FleetController : ControllerBase
    {
        /// <summary>
        /// API to add a fleet.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("fleet/add")]
        public FleetResponse Add([FromBody]Fleet data)
        {
            FleetResponse fleet = new FleetResponse();
            try
            {
                fleet = Store.Add(data);
                return fleet;
            }
            catch (Exception ex)
            {
                Log.LogError(ex);
                fleet.Message = Constants.Error;
                fleet.Status = false;
                return fleet;
            }
        }

        /// <summary>
        /// API to update a fleet 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("fleet/update")]
        public FleetResponse Update([FromBody]Fleet data)
        {
            FleetResponse fleet = new FleetResponse();
            try
            {
                fleet = Store.Update(data);
                return fleet;
            }
            catch (Exception ex)
            {
                Log.LogError(ex);
                fleet.Message = Constants.Error;
                fleet.Status = false;
                return fleet;
            }
        }

        /// <summary>
        /// API to fetch all fleets
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("fleet/fetch")]
        public FleetResponses FetchAll()
        {
            FleetResponses fleets = new FleetResponses();
            try
            {
                fleets = Store.FetchAll();
                return fleets;
            }
            catch (Exception ex)
            {
                Log.LogError(ex);
                fleets.Message = Constants.Error;
                fleets.Status = false;
                return fleets;
            }
        }

        /// <summary>
        /// API to fetch fleet bu guid
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("fleet/fetch/{guid}")]
        public ActionResult<FleetResponse> FetchById(string guid)
        {
            FleetResponse fleet = new FleetResponse();
            try
            {
                fleet = Store.FetchById(guid);
                return fleet;
            }
            catch (Exception ex)
            {
                Log.LogError(ex);
                fleet.Message = Constants.Error;
                fleet.Status = false;
                return fleet;
            }
        }

        /// <summary>
        /// API to fetch fleets by 
        /// </summary>
        /// <param name="cat"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("fleet/fetch/cat/{category}")]
        public ActionResult<FleetResponses> FetchByCategory(int cat)
        {
            FleetResponses fleets = new FleetResponses();
            try
            {
                fleets = Store.FetchByCategory(cat);
                return fleets;
            }
            catch (Exception ex)
            {
                Log.LogError(ex);
                fleets.Message = Constants.Error;
                fleets.Status = false;
                return fleets;
            }
        }

        /// <summary>
        /// API to delete a fleet by guid
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("fleet/delete/{guid}")]
        public ActionResult<FleetResponse> Delete(string guid)
        {
            FleetResponse fleet = new FleetResponse();
            try
            {
                fleet = Store.Delete(guid);
                return fleet;
            }
            catch (Exception ex)
            {
                Log.LogError(ex);
                fleet.Message = Constants.Error;
                fleet.Status = false;
                return fleet;
            }
        }
    }
}