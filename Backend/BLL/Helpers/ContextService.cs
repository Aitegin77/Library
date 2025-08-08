using BLL.Interfaces;
using DAL.Entities.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace BLL.Helpers
{
    public class ContextService : IContextService
    {
        private IHttpContextAccessor HttpContextAccessor { get; }
        private UserManager<User> UserManager { get; }

        public ContextService(IHttpContextAccessor httpContextAccessor, UserManager<User> userManager)
        {
            HttpContextAccessor = httpContextAccessor;
            UserManager = userManager;
        }

        public async Task<User?> GetCurrentUserAsync()
        {
            var user = HttpContextAccessor.HttpContext?.User;

            if (user == null || !user.Identity?.IsAuthenticated == true)
                return null;

            return await UserManager.GetUserAsync(user);
        }
    }
}
