using BLL.Interfaces;
using Common.Enums;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using DTO;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class BookService : IBookService
    {
        private IBookRepository BookRepository { get; }
        private IFileService FileService { get; }
        private IPageRepository PageRepository { get; }

        public BookService(IBookRepository bookRepository, IFileService fileService, IPageRepository pageRepository)
        {
            BookRepository = bookRepository;
            FileService = fileService;
            PageRepository = pageRepository;
        }

        public async Task<List<BookDto.List>> GetListAsync() =>
            await BookRepository.GetSet().ProjectToType<BookDto.List>().ToListAsync();

        public async Task UploadAsync(BookDto.Upload newBook)
        {
            Book book = newBook.Adapt<Book>();

            string fileName = $"{Guid.NewGuid()}";

            var pagesPath = await FileService.SavePdfAsync(newBook.Pages, fileName, FileType.Books);

            if (newBook.CoverImage != null)
                book.CoverImageUrl = await FileService.SaveAsync
                    (newBook.CoverImage, FileType.Covers, overwrite: false, fileName);
            else
                book.CoverImageUrl = await FileService.CopyAsync
                    (pagesPath[0], FileType.Covers, overwrite: false, fileName);

            await BookRepository.AddAsync(book);
            await BookRepository.SaveChangesAsync();

            await AddPagesAsync(pagesPath, book);
        }

        private async Task AddPagesAsync(List<string> pagesPath, Book book)
        {
            var pages = new List<Page>();

            for (int i = 0; i < pagesPath.Count; i++)
            {
                pages.Add(new Page()
                {
                    Book = book,
                    FileUrl = pagesPath[i],
                    NumberPage = i + 1
                });
            }

            await PageRepository.AddRangeAsync(pages);
            await PageRepository.SaveChangesAsync();
        }

        public async Task UpdateAsync(BookDto.Edit book)
        {
            BookRepository.Update(book.Adapt<Book>());

            await BookRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var book = await BookRepository.GetByIdAsync(id);

            BookRepository.Delete(book!);

            await BookRepository.SaveChangesAsync();
        }
    }
}