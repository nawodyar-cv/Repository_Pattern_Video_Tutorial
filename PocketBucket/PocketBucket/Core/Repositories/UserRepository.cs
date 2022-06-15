using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PocketBucket.Core.IRepositories;
using PocketBucket.Data;
using PocketBucket.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PocketBucket.Core.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(
            ApplicationDbContext context,
            ILogger logger
            ) : base(context, logger)
        { 
            
        }

        public override async Task<IEnumerable<User>> All()
        {
            try
            {
                return await dbSet.ToListAsync();
            }
            catch (Exception ex)
            { 
                _logger.LogError(ex, "{Repo} All Method error",typeof(UserRepository));
                return new List<User>();
            }
        }

        public override async Task<bool> Upsert(User entity)
        {
        
            try
            {

                var existinUser = await dbSet.Where(x => x.Id == entity.Id)
               .FirstOrDefaultAsync();

                if (existinUser == null)
                    return await Add(entity);
                existinUser.FirstName = entity.FirstName;
                existinUser.LastName = entity.LastName;
                existinUser.Email = entity.Email;

                return true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Upsert Method error", typeof(UserRepository));
                return false;
            }
        }

        public override async Task<bool> Delete(Guid id)
        {
            try
            {
                var exist = await dbSet.Where(x => x.Id == id)
                    .FirstOrDefaultAsync();
                if (exist != null)
                {
                    dbSet.Remove(exist);
                    return true;
                }

                return false;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Delete Method error", typeof(UserRepository));
                return false;
            }
        }
        
    }
}
