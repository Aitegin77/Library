using BLL.Interfaces;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using DTO;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class PublisherService : IPublisherService
    {
        private IPublisherRepository PublisherRepository { get; }

        public PublisherService(IPublisherRepository publisherRepository) =>
            PublisherRepository = publisherRepository;

        public async Task<List<PublisherDto.List>> GetListAsync() =>
            await PublisherRepository.GetSet().ProjectToType<PublisherDto.List>().ToListAsync();

        public async Task<List<PublisherDto.List>> GetFilteredListAsync(string filter)
        {
            if (string.IsNullOrWhiteSpace(filter))
                return new List<PublisherDto.List>();

            return await PublisherRepository
                .GetByFilter(p => p.Name.Contains(filter))
                .ProjectToType<PublisherDto.List>()
                .ToListAsync();
        }

        public async Task AddAsync(PublisherDto.Create newPublisher)
        {
            await PublisherRepository.AddAsync(newPublisher.Adapt<Publisher>());

            await PublisherRepository.SaveChangesAsync();
        }

        public async Task UpdateAsync(PublisherDto.Edit publisher)
        {
            PublisherRepository.Update(publisher.Adapt<Publisher>());

            await PublisherRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var publisher = await PublisherRepository.GetByIdAsync(id);

            PublisherRepository.Delete(publisher!);

            await PublisherRepository.SaveChangesAsync();
        }
    }
}
