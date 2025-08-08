using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities.Identity
{
    public class User : IdentityUser<int>
    {
        [Required, MaxLength(35)]
        public string NickName { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime LastLogIn { get; set; }
        [MaxLength(250)]
        public string? ProfilePictureUrl { get; set; }
        public ICollection<Book>? UserBooks { get; set; }
        public ICollection<Bookmark> Bookmarks { get; set; }
        public ICollection<Collection> Collections { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<UserRole> Roles { get; set; }
    }
}
