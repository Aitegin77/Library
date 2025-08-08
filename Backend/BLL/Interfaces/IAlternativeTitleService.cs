using DTO;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IAlternativeTitleService
    {
        Task AddAsync(AlternativeTitleDto.Create title);
        Task UpdateAsync(AlternativeTitleDto.Edit title);
        Task DeleteAsync(int id);
    }
}
