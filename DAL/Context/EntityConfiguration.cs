using DAL.Entities;
using DAL.Entities.Identity;
using Microsoft.EntityFrameworkCore;

namespace DAL.Context
{
    public class EntityConfiguration
    {
        public static void ApplyConfigurations(ModelBuilder builder)
        {
            #region Identity
            builder.Entity<Admin>().ToTable("Admins");
            builder.Entity<Role>().ToTable("Roles");

            builder.Entity<RoleClaim>(rc =>
            {
                rc.ToTable("RoleClaims");
                rc.Property("ClaimType").HasMaxLength(50).IsRequired();
                rc.Property("ClaimValue").HasMaxLength(50).IsRequired();
            });

            builder.Entity<User>(u =>
            {
                u.ToTable("Users").HasIndex(u => u.UserName).IsUnique();
                u.Property("UserName").IsRequired();
                u.Property("Email").IsRequired();
                u.Property("PasswordHash").IsRequired();
            });

            builder.Entity<UserRole>(ur =>
            {
                ur.ToTable("UserRoles");

                ur.HasOne(ur => ur.User)
                      .WithMany(u => u.Roles)
                      .HasForeignKey(ur => ur.UserId)
                      .OnDelete(DeleteBehavior.Cascade);

                ur.HasOne(ur => ur.Role)
                      .WithMany(r => r.Users)
                      .HasForeignKey(ur => ur.RoleId)
                      .OnDelete(DeleteBehavior.Cascade);
            });
            #endregion

            builder.Entity<AlternativeTitle>(at =>
            {
                at.HasIndex(at => new { at.BookId, at.Title }).IsUnique();

                at.HasOne(at => at.Book)
                      .WithMany(b => b.AlternativeTitles)
                      .HasForeignKey(at => at.BookId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<Author>(a =>
            {
                a.HasIndex(a => new { a.FirstName, a.LastName, a.Patronymic, a.DateOfBirth }).IsUnique();

                a.HasOne(a => a.Country)
                      .WithMany(c => c.Authors)
                      .HasForeignKey(a => a.CountryId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<AuthorBook>(ab =>
            {
                ab.HasKey(ab => new { ab.BookId, ab.AuthorId });

                ab.HasOne(ab => ab.Author)
                      .WithMany(a => a.AuthorBooks)
                      .HasForeignKey(ab => ab.AuthorId)
                      .OnDelete(DeleteBehavior.Restrict);

                ab.HasOne(ab => ab.Book)
                      .WithMany(b => b.AuthorBooks)
                      .HasForeignKey(ab => ab.BookId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<Book>(b =>
            {
                b.HasIndex(b => b.ISBN).IsUnique();

                b.HasOne(b => b.Publisher)
                      .WithMany(p => p.Books)
                      .HasForeignKey(b => b.PublisherId)
                      .OnDelete(DeleteBehavior.Restrict);

                b.HasOne(b => b.BookType)
                      .WithMany(bt => bt.Books)
                      .HasForeignKey(b => b.BookTypeId)
                      .OnDelete(DeleteBehavior.Restrict);

                b.HasOne(b => b.UploaderUser)
                      .WithMany(u => u.UserBooks)
                      .HasForeignKey(b => b.UploaderUserId)
                      .OnDelete(DeleteBehavior.SetNull);
            });

            builder.Entity<BookCollection>(bc =>
            {
                bc.HasKey(bc => new { bc.CollectionId, bc.BookId });

                bc.HasOne(bc => bc.Collection)
                      .WithMany(c => c.BookCollections)
                      .HasForeignKey(bc => bc.CollectionId)
                      .OnDelete(DeleteBehavior.Restrict);

                bc.HasOne(bc => bc.Book)
                      .WithMany()
                      .HasForeignKey(bc => bc.BookId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<BookGenre>(bg =>
            {
                bg.HasKey(bg => new { bg.BookId, bg.GenreId });

                bg.HasOne(bg => bg.Genre)
                      .WithMany(g => g.BookGenres)
                      .HasForeignKey(bg => bg.GenreId)
                      .OnDelete(DeleteBehavior.Restrict);

                bg.HasOne(bg => bg.Book)
                      .WithMany(b => b.BookGenres)
                      .HasForeignKey(bg => bg.BookId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<Bookmark>(b =>
            {
                b.HasKey(b => new { b.UserId, b.BookId });

                b.HasOne(b => b.User)
                      .WithMany(u => u.Bookmarks)
                      .HasForeignKey(b => b.UserId)
                      .OnDelete(DeleteBehavior.Cascade);

                b.HasOne(b => b.Page)
                      .WithMany(p => p.Bookmarks)
                      .HasForeignKey(b => new { b.BookId, b.NumberPage })
                      .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<Collection>(c =>
            {
                c.HasIndex(c => new { c.UserId, c.Name }).IsUnique();

                c.HasOne(c => c.User)
                      .WithMany(u => u.Collections)
                      .HasForeignKey(c => c.UserId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<Comment>(c =>
            {
                c.HasOne(c => c.User)
                      .WithMany(u => u.Comments)
                      .HasForeignKey(c => c.UserId)
                      .OnDelete(DeleteBehavior.SetNull);

                c.HasOne(c => c.Book)
                      .WithMany(b => b.Comments)
                      .HasForeignKey(c => c.BookId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<Page>(p =>
            {
                p.HasKey(p => new { p.BookId, p.NumberPage });

                p.HasOne(p => p.Book)
                      .WithMany(b => b.Pages)
                      .HasForeignKey(p => p.BookId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<Publisher>(p =>
            {
                p.HasIndex(p => new { p.Name, p.CountryId }).IsUnique();

                p.HasOne(p => p.Country)
                      .WithMany(c => c.Publishers)
                      .HasForeignKey(p => p.CountryId)
                      .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
