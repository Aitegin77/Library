using BLL.Interfaces;
using DAL.Repositories.Interfaces;
using DTO;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class CountryService : ICountryService
    {
        private ICountryRepository CountryRepository { get; }

        public CountryService(ICountryRepository countryRepository) =>
            CountryRepository = countryRepository;

        public async Task<List<CountryDto.List>> GetListAsync() =>
            await CountryRepository.GetSet()
                    .ProjectToType<CountryDto.List>()
                    .OrderBy(c => c.Name)
                    .ToListAsync();

        public async Task<List<CountryDto.List>> GetFilteredListAsync(string filter)
        {
            if (string.IsNullOrWhiteSpace(filter))
                return new List<CountryDto.List>();

            return await CountryRepository
                .GetByFilter(c => c.Name.Contains(filter) ||
                             c.EnglishName.Contains(filter) ||
                             c.ShortName.Contains(filter))
                .ProjectToType<CountryDto.List>()
                .ToListAsync();
        }
    }
}