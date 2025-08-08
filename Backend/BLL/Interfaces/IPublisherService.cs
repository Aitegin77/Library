using DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IPublisherService
    {
        Task<List<PublisherDto.List>> GetListAsync();
        Task<List<PublisherDto.List>> GetFilteredListAsync(string filter);
        Task AddAsync(PublisherDto.Create newPublisher);
        Task UpdateAsync(PublisherDto.Edit publisher);
        Task DeleteAsync(int id);
    }
}
