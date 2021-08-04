using LocationUpdate.Core.Domain;
using MassTransit;
using MessageModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LocationUpdate.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationUpdateController : ControllerBase
    {
        private readonly IPublishEndpoint _publishEndpoint;
        public LocationUpdateController(IPublishEndpoint publishEndpoint)
        {
            this._publishEndpoint = publishEndpoint;
        }
        

        // POST api/<LocationUpdateController>
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> UpdateLocation([FromBody] Location location)
        {
            //set timestampe
            location.TimeStamp = System.DateTime.UtcNow;

            if (ModelState.IsValid)
            {

                await _publishEndpoint.Publish<Location>(location);

                return Ok();
            }
            return new JsonResult("Data is not complete") { StatusCode = 500 };
        }

        
    }
}
