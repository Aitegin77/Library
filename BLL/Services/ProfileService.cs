using BLL.Interfaces;
using Common.Enums;
using Common.Helpers;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ProfileService : IProfileService
    {
        private IContextService Context { get; }
        private IFileService FileService { get; }

        public ProfileService(IContextService context, IFileService fileService)
        {
            Context = context;
            FileService = fileService;
        }

        public async Task<string?> GetProfileIconAsync()
        {
            var user = await Context.GetCurrentUserAsync();

            if (user == null) return null;

            var profileIcon = user.ProfilePictureUrl;

            if (profileIcon != null)
                return await FileService.CopyAsync(profileIcon, WwwRootType.Icons, overwrite: true);
            else
                return Constants.DefaultProfileIconPath;
        }
    }
}