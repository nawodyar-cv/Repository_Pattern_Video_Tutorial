using Microsoft.EntityFrameworkCore;
using PocketBucket.Model;

namespace PocketBucket.Data
{
    public class ApplicationDbContext :DbContext
    {
        //the dbset property will tell ef core that we have 
        // a table that needs to be creted if doesnt exist 
        public virtual DbSet<User> Users { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options)
             :base(options)
        { 
        
        }
    }
}
