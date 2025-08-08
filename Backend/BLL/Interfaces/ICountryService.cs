using DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ICountryService
    {
        Task<List<CountryDto.List>> GetListAsync();
        Task<List<CountryDto.List>> GetFilteredListAsync(string filter);
    }
}
