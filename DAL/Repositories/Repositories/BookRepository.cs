using DAL.Context;
using DAL.Entities;
using DAL.Repositories.Interfaces;

namespace DAL.Repositories.Repositories
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(LibraryDbContext dbContext) : base(dbContext) { }
    }
}
