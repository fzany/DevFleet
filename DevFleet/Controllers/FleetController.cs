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

        [HttpGet]
        [Route("fleet/fetch/{id}")]
        public ActionResult<FleetResponse> FetchById(int id)
        {
            FleetResponse fleet = new FleetResponse();
            try
            {
                fleet = Store.FetchById(id);
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

        [HttpDelete]
        [Route("fleet/delete/{id}")]
        public ActionResult<FleetResponse> Delete(int id)
        {
            FleetResponse fleet = new FleetResponse();
            try
            {
                fleet = Store.Delete(id);
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