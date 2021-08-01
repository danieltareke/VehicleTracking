using LocationView.Core.Domain;
using LocationView.Core.Interfaces;
using MassTransit;
using MessageModel;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationView.WebAPI.MassTransit
{
    internal class LocationConsumer : IConsumer<Location>
    {
        private readonly ILogger<LocationConsumer> logger;
        private readonly IUnitOfWork _unitOfWork;

        public LocationConsumer(ILogger<LocationConsumer> logger,
            IUnitOfWork unitOfWork)
        {
            this.logger = logger;
            this._unitOfWork = unitOfWork;
        }

        public async Task Consume(ConsumeContext<Location> context)
        {
            var device = await _unitOfWork.Devices.GetByDeviceId(context.Message.DeviceId);

            if (device != null)
            {
                DeviceLocation location = new DeviceLocation
                {
                    DeviceId = context.Message.DeviceId,
                    Device=device,
                    TimeStamp = DateTime.Now,
                    Latitude = context.Message.Latitude,
                    Longitude = context.Message.Longitude
                };

                await _unitOfWork.Locations.Add(location);
                await _unitOfWork.CompleteAsync();
            }          
            
            logger.LogInformation($"Device information not found {context.Message.DeviceId}");
        }
    }
}
