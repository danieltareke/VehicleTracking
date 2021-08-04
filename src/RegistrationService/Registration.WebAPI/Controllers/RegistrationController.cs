using MassTransit;
using MessageModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Registration.Core.Domain;
using Registration.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Registration.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase

    {
        private readonly ILogger<RegistrationController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPublishEndpoint _publishEndpoint;

        public RegistrationController(
            ILogger<RegistrationController> logger,
            IUnitOfWork unitOfWork,
            IPublishEndpoint publishEndpoint
        )
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _publishEndpoint = publishEndpoint;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> RegisterDevice(DeviceRegistration registration)
        {
            //set registration time of devices
            registration.RegistrationTime = DateTime.Now;

            if (ModelState.IsValid)
            {
                //check to avoid duplicate registration
                var deviceExisits = await _unitOfWork.Devices.GetByDeviceId(registration.DeviceId);
                if(deviceExisits!=null)
                    return Ok(registration);

                await _unitOfWork.Devices.Add(registration);
                await _unitOfWork.CompleteAsync();

                //publish to mass transit
                Device device = new Device
                {
                    DeviceId = registration.DeviceId,
                    VehiclePlateNo = "",
                    RegistrationTime=registration.RegistrationTime

                };

                await _publishEndpoint.Publish<Device>(device);

                return Ok(registration);
            }

            return new JsonResult("Data is not complete") { StatusCode = 500 };
        }

       
    }
}
