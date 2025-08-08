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
    public class GenreService : IGenreService
    {
        private IGenreRepository GenreRepository { get; }

        public GenreService(IGenreRepository genreRepository) =>
            GenreRepository = genreRepository;

        public async Task<List<GenreDto.List>> GetListAsync() =>
            await GenreRepository.GetSet().ProjectToType<GenreDto.List>().ToListAsync();

        public async Task<List<GenreDto.List>> GetFilteredListAsync(string filter)
        {
            if (string.IsNullOrWhiteSpace(filter))
                return new List<GenreDto.List>();

            return await GenreRepository
                .GetByFilter(g => g.Name.Contains(filter))
                .ProjectToType<GenreDto.List>()
                .ToListAsync();
        }

        public async Task AddAsync(GenreDto.Create newGenre)
        {
            await GenreRepository.AddAsync(newGenre.Adapt<Genre>());

            await GenreRepository.SaveChangesAsync();
        }

        public async Task UpdateAsync(GenreDto.Edit genre)
        {
            GenreRepository.Update(genre.Adapt<Genre>());

            await GenreRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var genre = await GenreRepository.GetByIdAsync(id);

            GenreRepository.Delete(genre!);

            await GenreRepository.SaveChangesAsync();
        }
    }
}
