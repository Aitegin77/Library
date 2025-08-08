using BLL.Interfaces;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using DAL.Repositories.Repositories;
using DTO;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class BookTypeService : IBookTypeService
    {
        private IBookTypeRepository BookTypeRepository { get; }

        public BookTypeService(IBookTypeRepository bookTypeRepository) =>
            BookTypeRepository = bookTypeRepository;

        public async Task<List<BookTypeDto.List>> GetListAsync() =>
            await BookTypeRepository.GetSet().ProjectToType<BookTypeDto.List>().ToListAsync();

        public async Task<List<BookTypeDto.List>> GetFilteredListAsync(string filter)
        {
            if (string.IsNullOrWhiteSpace(filter))
                return new List<BookTypeDto.List>();

            return await BookTypeRepository
                .GetByFilter(bt => bt.Name.Contains(filter))
                .ProjectToType<BookTypeDto.List>()
                .ToListAsync();
        }

        public async Task AddAsync(BookTypeDto.Create newBookType)
        {
            await BookTypeRepository.AddAsync(newBookType.Adapt<BookType>());

            await BookTypeRepository.SaveChangesAsync();
        }

        public async Task UpdateAsync(BookTypeDto.Edit bookType)
        {
            BookTypeRepository.Update(bookType.Adapt<BookType>());

            await BookTypeRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var bookType = await BookTypeRepository.GetByIdAsync(id);

            BookTypeRepository.Delete(bookType!);

            await BookTypeRepository.SaveChangesAsync();
        }
    }
}
