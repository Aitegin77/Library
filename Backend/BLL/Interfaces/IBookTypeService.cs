using DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IBookTypeService
    {
        Task<List<BookTypeDto.List>> GetListAsync();
        Task<List<BookTypeDto.List>> GetFilteredListAsync(string filter);
        Task AddAsync(BookTypeDto.Create newBookType);
        Task UpdateAsync(BookTypeDto.Edit bookType);
        Task DeleteAsync(int id);
    }
}
