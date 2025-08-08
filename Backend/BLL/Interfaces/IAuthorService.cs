using DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IAuthorService
    {
        Task<List<AuthorDto.List>> GetListAsync();
        Task<List<AuthorDto.List>> GetFilteredListAsync(string filter);
        Task AddAsync(AuthorDto.Create newAuthor);
        Task UpdateAsync(AuthorDto.Edit author);
        Task DeleteAsync(int id);
    }
}
