using BLL.Interfaces;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using DAL.Repositories.Repositories;
using DTO;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AuthorService : IAuthorService
    {
        private IAuthorRepository AuthorRepository { get; }

        public AuthorService(IAuthorRepository authorRepository) =>
            AuthorRepository = authorRepository;

        public async Task<List<AuthorDto.List>> GetListAsync() =>
            await AuthorRepository.GetSet().ProjectToType<AuthorDto.List>().ToListAsync();

        public async Task<List<AuthorDto.List>> GetFilteredListAsync(string filter)
        {
            if (string.IsNullOrWhiteSpace(filter))
                return new List<AuthorDto.List>();

            return await AuthorRepository
                .GetByFilter(a => a.FirstName.Contains(filter) ||
                             a.LastName.Contains(filter) ||
                             a.Patronymic.Contains(filter))
                .ProjectToType<AuthorDto.List>()
                .ToListAsync();
        }

        public async Task AddAsync(AuthorDto.Create newAuthor)
        {
            await AuthorRepository.AddAsync(newAuthor.Adapt<Author>());

            await AuthorRepository.SaveChangesAsync();
        }

        public async Task UpdateAsync(AuthorDto.Edit author)
        {
            AuthorRepository.Update(author.Adapt<Author>());

            await AuthorRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var author = await AuthorRepository.GetByIdAsync(id);

            AuthorRepository.Delete(author!);

            await AuthorRepository.SaveChangesAsync();
        }
    }
}
