using BLL.Interfaces;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using DTO;
using Mapster;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AlternativeTitleService : IAlternativeTitleService
    {
        public IAlternativeTitleRepository AlternativeTitleRepository { get; }

        public AlternativeTitleService(IAlternativeTitleRepository alternativeTitleRepository) =>
            AlternativeTitleRepository = alternativeTitleRepository;

        public async Task AddAsync(AlternativeTitleDto.Create title)
        {
            await AlternativeTitleRepository.AddAsync(title.Adapt<AlternativeTitle>());

            await AlternativeTitleRepository.SaveChangesAsync();
        }

        public async Task UpdateAsync(AlternativeTitleDto.Edit title)
        {
            AlternativeTitleRepository.Update(title.Adapt<AlternativeTitle>());

            await AlternativeTitleRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var title = await AlternativeTitleRepository.GetByIdAsync(id);

            AlternativeTitleRepository.Delete(title!);

            await AlternativeTitleRepository.SaveChangesAsync();
        }
    }
}
