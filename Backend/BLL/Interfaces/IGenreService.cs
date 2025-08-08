using DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IGenreService
    {
        Task<List<GenreDto.List>> GetListAsync();
        Task<List<GenreDto.List>> GetFilteredListAsync(string filter);
        Task AddAsync(GenreDto.Create newGenre);
        Task UpdateAsync(GenreDto.Edit genre);
        Task DeleteAsync(int id);
    }
}
