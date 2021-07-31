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

        [HttpPost]
        public async Task<IActionResult> CreateUser(DeviceInfo device)
        {
            if (ModelState.IsValid)
            {          
                await _unitOfWork.Devices.Add(device);
                await _unitOfWork.CompleteAsync();

                return Ok(device);
                //return CreatedAtAction("GetItem", new { device.DeviceId }, device);
            }

            return new JsonResult("Something went wrong") { StatusCode = 500 };
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetItem(Guid id)
        {
            var user = await _unitOfWork.Devices.GetById(id);

            if (user == null)
                return NotFound(); // 404 http status code 

            return Ok(user);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _unitOfWork.Devices.All();

            return Ok(users);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateItem(DeviceInfo device)
        {
            await _unitOfWork.Devices.Upsert(device);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(Guid id)
        {
            var item = await _unitOfWork.Devices.GetById(id);

            if (item == null)
                return BadRequest();

            await _unitOfWork.Devices.Delete(id);
            await _unitOfWork.CompleteAsync();

            return Ok(item);
        }
    }
}
