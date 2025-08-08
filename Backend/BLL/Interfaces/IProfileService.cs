using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IProfileService
    {
        public Task<string?> GetProfileIconAsync();
    }
}
