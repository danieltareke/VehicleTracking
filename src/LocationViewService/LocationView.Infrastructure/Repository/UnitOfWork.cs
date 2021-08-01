using LocationView.Core.Interfaces;
using LocationView.Core.Interfaces.Repository;
using LocationView.Infrastructure.Data;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationView.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly LocationViewDbContext _context;
        private readonly ILogger _logger;

        public IDeviceInfoRepository Devices { get; private set; }
        public IDeviceLocationRepository Locations { get; private set; }

        public UnitOfWork(
            LocationViewDbContext context,
            ILoggerFactory loggerFactory
        )
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("logs");

            Devices = new DeviceInfoRepository(_context, _logger);
            Locations = new DeviceLocationRepository(_context, _logger);
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
