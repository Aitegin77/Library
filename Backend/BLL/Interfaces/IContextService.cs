using DAL.Entities.Identity;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IContextService
    {
        public Task<User?> GetCurrentUserAsync();
    }
}
