using DAL.Context;
using DAL.Entities;
using DAL.Repositories.Interfaces;

namespace DAL.Repositories.Repositories
{
    public class BookTypeRepository : Repository<BookType>, IBookTypeRepository
    {
        public BookTypeRepository(LibraryDbContext libraryDbContext) : base(libraryDbContext) { }
    }
}
