using Microsoft.Extensions.Logging;
using PocketBucket.Core.IConfiguration;
using PocketBucket.Core.IRepositories;
using PocketBucket.Core.Repositories;
using System;
using System.Threading.Tasks;

namespace PocketBucket.Data
{
    public class UnitOfWork:IUnitOfWork, IDisposable
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger _logger;
     //   private readonly ILogger logger;
       
        public IUserRepository Users { get; private set; }

        public UnitOfWork(
            ApplicationDbContext context,
            ILoggerFactory loggerFactory
            )
        { 
            _context = context;
            _logger = loggerFactory.CreateLogger("logs");

            Users = new UserRepository(_context, _logger);
        }

        public async Task CompleteAsync()
        { 
            await _context.SaveChangesAsync();
        }

        public  void Dispose()
        { 
             _context.Dispose();
        }
       
    }
}
