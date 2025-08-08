using Microsoft.AspNetCore.Identity;

namespace DAL.Entities.Identity
{
    public class Role : IdentityRole<int>
    {
        public ICollection<UserRole> Users { get; set; }
    }
}
