using Microsoft.Extensions.Logging;
using Registration.Core.Interfaces;
using Registration.Core.Interfaces.Repository;
using Registration.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly RegistrationDbContext _context;
        private readonly ILogger _logger;

        public IDeviceRegistrationRepository Devices { get; private set; }

        public UnitOfWork(
            RegistrationDbContext context,
            ILoggerFactory loggerFactory
        )
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("logs");

            Devices = new DeviceRegistrationRepository(_context, _logger);
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
