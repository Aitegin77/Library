using Azure.Core;
using BLL.Interfaces;
using Common.Enums;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Net.Http.Headers;
using PdfSharpCore.Pdf;
using PdfSharpCore.Pdf.IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Helpers
{
    public class FileService : IFileService
    {
        private IWebHostEnvironment Env { get; }

        public FileService(IWebHostEnvironment environment) => Env = environment;

        public async Task<Stream> GetStreamFromRequestAsync(HttpRequest request, string fieldName)
        {
            if (!MediaTypeHeaderValue.TryParse(request.ContentType, out var mediaTypeHeader))
                throw new InvalidOperationException("Некорректный Content-Type");

            var boundary = HeaderUtilities.RemoveQuotes(mediaTypeHeader.Boundary).Value;

            if (string.IsNullOrEmpty(boundary))
                throw new InvalidOperationException("Не найден boundary в заголовке Content-Type");

            var reader = new MultipartReader(boundary, request.Body);

            MultipartSection? section;

            while ((section = await reader.ReadNextSectionAsync()) != null)
            {
                var contentDisposition = section.GetContentDispositionHeader();
                if (contentDisposition == null)
                    continue;

                if (contentDisposition.IsFileDisposition() &&
                    contentDisposition.Name.Value == fieldName)
                {
                    return section.Body;
                }
            }

            throw new ArgumentException("Файл не найден либо не может быть обработан.");
        }

        public async Task<string> CopyAsync(string filePath, WwwRootType wwwRootType, bool overwrite, string? newFileName = null)
        {
            newFileName = ValidateAndGetFileName(filePath, newFileName);

            using var file = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read, 8192, useAsync: true);

            return await CopyAsync(file, newFileName, GetOrCreateDirectory(wwwRootType), overwrite);
        }

        public async Task<string> CopyAsync(string filePath, FileType fileType, bool overwrite, string? newFileName = null)
        {
            newFileName = ValidateAndGetFileName(filePath, newFileName);

            using var file = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read, 8192, useAsync: true);

            return await CopyAsync(file, newFileName, GetOrCreateDirectory(fileType), overwrite);
        }

        private async Task<string> CopyAsync(Stream file, string fileName, string directory, bool overwrite)
        {
            Directory.CreateDirectory(directory);
            var path = Path.Combine(directory, fileName);

            ValidateOverwrite(path, overwrite);

            using var destStream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None, 8192, useAsync: true);
            await file.CopyToAsync(destStream);

            return path;
        }

        private async Task<string> CopyAsync(IFormFile file, string directory, bool overwrite, string? newFileName = null)
        {
            newFileName = ValidateAndGetFileName(file, newFileName);

            Directory.CreateDirectory(directory);
            var path = Path.Combine(directory, newFileName);

            ValidateOverwrite(path, overwrite);

            using var destStream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None, 8192, useAsync: true);
            await file.CopyToAsync(destStream);

            return path;
        }

        public async Task<string> SaveAsync(IFormFile file, FileType fileType, bool overwrite, string? newFileName = null)
        {
            var extension = Path.GetExtension(file.FileName);

            if (newFileName == null)
                newFileName = $"{Guid.NewGuid()}{extension}";
            else
                newFileName = $"{newFileName}{extension}";

            return await CopyAsync(file, GetOrCreateDirectory(fileType), overwrite, newFileName);
        }

        public async Task<List<string>> SavePdfAsync(Stream file, string fileName, FileType fileType)
        {
            var pdf = PdfReader.Open(file, PdfDocumentOpenMode.Import);

            var pagesPath = new List<string>();

            for (int i = 0; i < pdf.PageCount; i++)
            {
                using var page = new PdfDocument();
                page.AddPage(pdf.Pages[i]);

                using var ms = new MemoryStream();
                page.Save(ms);
                ms.Position = 0;

                var filePath = await CopyAsync(ms, $"{fileName}_p{i + 1}.pdf", GetOrCreateDirectory(fileType), overwrite: false);
                pagesPath.Add(filePath);
            }

            return pagesPath;
        }

        private string GetOrCreateDirectory(FileType fileType)
        {
            var path = Path.Combine(Env.ContentRootPath, "Files", fileType.ToString());
            Directory.CreateDirectory(path);
            return path;
        }

        private string GetOrCreateDirectory(WwwRootType wwwRootType)
        {
            var path = Path.Combine(Env.WebRootPath, wwwRootType.ToString().ToLower());
            Directory.CreateDirectory(path);
            return path;
        }

        private void ValidateOverwrite(string path, bool overwrite)
        {
            if (File.Exists(path) && !overwrite)
                throw new IOException($"File already exists: {path}");
        }

        private string ValidateAndGetFileName(string filePath, string? newFileName = null)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException($"Source file not found: {filePath}");

            if (newFileName == null)
                newFileName = Path.GetFileName(filePath);

            return newFileName;
        }

        private string ValidateAndGetFileName(IFormFile file, string? newFileName = null)
        {
            if (file == null || file.Length == 0)
                throw new ArgumentException($"File is null or empty.");

            if (newFileName == null)
                newFileName = file.FileName;

            return newFileName;
        }
    }
}
