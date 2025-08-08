using DAL.Entities.Identity;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(250)]
        public string Title { get; set; }
        public ICollection<AlternativeTitle>? AlternativeTitles { get; set; }
        public DateOnly PublishedDate { get; set; }
        [MaxLength(13)]
        public string? ISBN { get; set; }
        public ICollection<AuthorBook> AuthorBooks { get; set; }
        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }
        public ICollection<BookGenre> BookGenres { get; set; }
        public int BookTypeId { get; set; }
        public BookType BookType { get; set; }
        [MaxLength(250)]
        public string CoverImageUrl { get; set; }
        public float Rating { get; set; }
        [Required, MaxLength(500)]
        public string Description { get; set; }
        public ICollection<Page> Pages { get; set; }
        public ICollection<Comment> Comments { get; set; }

        #region Audit
        public bool IsDeleted { get; set; }
        public DateTime UploadedDateTime { get; set; }
        public int? UploaderUserId { get; set; }
        public User? UploaderUser { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
        public int? UpdaterUserId { get; set; }
        public DateTime? DeletedDateTime { get; set; }
        public int? DeleterAdminId { get; set; }
        #endregion
    }
}
