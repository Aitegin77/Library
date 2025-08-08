using DAL.Entities;
using DAL.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAL.Context
{
    public class LibraryDbContext : IdentityDbContext<User, Role, int, IdentityUserClaim<int>,
            UserRole, UserLogin, RoleClaim, IdentityUserToken<int>>
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options) { }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<AlternativeTitle> AlternativeTitles { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<AuthorBook> AuthorBooks { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookCollection> BookCollections { get; set; }
        public DbSet<BookGenre> BookGenres { get; set; }
        public DbSet<Bookmark> Bookmarks { get; set; }
        public DbSet<BookType> BookTypes { get; set; }
        public DbSet<Collection> Collections { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<Publisher> Publishers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //builder.ApplyConfigurationsFromAssembly(typeof(LibraryDbContext).Assembly);

            EntityConfiguration.ApplyConfigurations(builder);
        }
    }
}