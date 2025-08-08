using DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IBookService
    {
        Task<List<BookDto.List>> GetListAsync();
        Task UploadAsync(BookDto.Upload newBook);
        Task UpdateAsync(BookDto.Edit book);
        Task DeleteAsync(int id);
    }
}
