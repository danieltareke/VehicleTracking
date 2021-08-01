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
    internal class RegistrationConsumer : IConsumer<Device>
    {
        private readonly ILogger<RegistrationConsumer> logger;
        private readonly IUnitOfWork _unitOfWork;

        public RegistrationConsumer(ILogger<RegistrationConsumer> logger,
            IUnitOfWork unitOfWork)
        {
            this.logger = logger;
            this._unitOfWork = unitOfWork;
        }

        public async Task Consume(ConsumeContext<Device> context)
        {
            DeviceInfo device = new DeviceInfo
            {
                DeviceId = context.Message.DeviceId,
                RegistrationTime = context.Message.RegistrationTime,
                VehiclePlateNo = context.Message.VehiclePlateNo
            };

            await _unitOfWork.Devices.Add(device);
            await _unitOfWork.CompleteAsync();
           
            // await Console.Out.WriteLineAsync(context.Message.DeviceId);
            //logger.LogInformation($"Got new message {context.Message.DeviceId}");
        }
    }
}
