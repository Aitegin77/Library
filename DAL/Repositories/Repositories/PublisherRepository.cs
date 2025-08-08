using DAL.Context;
using DAL.Entities;
using DAL.Repositories.Interfaces;

namespace DAL.Repositories.Repositories
{
    public class PublisherRepository : Repository<Publisher>, IPublisherRepository
    {
        public PublisherRepository(LibraryDbContext dbContext) : base(dbContext) { }
    }
}
