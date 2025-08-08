using DAL.Context;
using DAL.Entities;
using DAL.Repositories.Interfaces;

namespace DAL.Repositories.Repositories
{
    public class AlternativeTitleRepository : Repository<AlternativeTitle>, IAlternativeTitleRepository
    {
        public AlternativeTitleRepository(LibraryDbContext dbContext) : base(dbContext) { }
    }
}
