using PocketBucket.Core.IRepositories;
using System.Threading.Tasks;

namespace PocketBucket.Core.IConfiguration
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }

        Task CompleteAsync();
    }
}
