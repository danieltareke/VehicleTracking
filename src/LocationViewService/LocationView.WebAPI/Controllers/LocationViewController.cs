using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LocationView.Core.Domain;
using LocationView.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;

namespace LocationView.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class LocationViewController : ControllerBase

    {
        private readonly ILogger<LocationViewController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;

        public LocationViewController(
            ILogger<LocationViewController> logger,
            IUnitOfWork unitOfWork,
            IConfiguration iConfig
        )
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _configuration = iConfig;
        }
                      

        [HttpGet]
        [Route("[action]/{device_id}")]        
        public async Task<IActionResult> GetCurrentLocation( string device_id)
        {
            var currentLocation = await _unitOfWork.Locations.GetDeviceCurrentLocation(device_id);

            return Ok(currentLocation);
        }

        [HttpGet]
        [Route("[action]/{device_id}/{from}/{to}")]
        public async Task<IActionResult> GetLocations(string device_id,DateTime from,DateTime to)
        {
            var locationRange = await _unitOfWork.Locations.GetDeviceLocationOverCertainTime(device_id,from,to);

            return Ok(locationRange);
        }

        //bonus
        [HttpGet]
        [Route("[action]/{device_id}")]
        public async Task<IActionResult> GetDeviceLocality(string device_id)
        {
            var currentLocation = await _unitOfWork.Locations.GetDeviceCurrentLocation(device_id);

            //actual key but needs billing to retrun result, didn't add billing due to credit card issue
            string api_key = _configuration.GetSection("MySettings").GetSection("Google_API_Key").Value; //"IzaSyD2UMGQIV_9c0B6Wk19iziNGFl4v-QNlwI";
            string google_api_URL = $"https://maps.googleapis.com/maps/api/geocode/json?latlng={0},{1} & key={api_key}";

            string url = string.Format(google_api_URL,currentLocation.Latitude,currentLocation.Longitude);
            var locality = new WebClient().DownloadString(url);                

            return Ok(locality);
        }


    }
}
