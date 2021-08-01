using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LocationView.Core.Domain;
using LocationView.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace LocationView.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationViewController : ControllerBase

    {
        private readonly ILogger<LocationViewController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public LocationViewController(
            ILogger<LocationViewController> logger,
            IUnitOfWork unitOfWork
        )
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        

        

        [HttpGet]
        //[Route("[action]/{devices}")]
        [Route("[action]")]
        public async Task<IActionResult> GetDevices()
        {
            var devices = await _unitOfWork.Devices.All();

            return Ok(devices);
        }

        [HttpGet]
        //[Route("[action]/{locations}")]
        [Route("[action]")]
        public async Task<IActionResult> GetLocations()
        {
            var locations = await _unitOfWork.Locations.All();

            return Ok(locations);
        }


    }
}
