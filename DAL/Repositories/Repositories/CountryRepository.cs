using DAL.Context;
using DAL.Entities;
using DAL.Repositories.Interfaces;

namespace DAL.Repositories.Repositories
{
    public class CountryRepository : Repository<Country>, ICountryRepository
    {
        public CountryRepository(LibraryDbContext dbContext) : base(dbContext) { }
    }
}
