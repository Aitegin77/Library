using DAL.Context;
using DAL.Entities;
using DAL.Repositories.Interfaces;

namespace DAL.Repositories.Repositories
{
    public class PageRepository : Repository<Page>, IPageRepository
    {
        public PageRepository(LibraryDbContext dbContext) : base(dbContext) { }
    }
}
