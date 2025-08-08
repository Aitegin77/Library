using Common.Enums;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IFileService
    {
        Task<Stream> GetStreamFromRequestAsync(HttpRequest request, string fieldName);
        Task<string> CopyAsync(string filePath, WwwRootType wwwRootType, bool overwrite, string? newFileName = null);
        Task<string> CopyAsync(string filePath, FileType fileType, bool overwrite, string? newFileName = null);
        Task<List<string>> SavePdfAsync(Stream file, string fileName, FileType fileType);
        Task<string> SaveAsync(IFormFile file, FileType fileType, bool overwrite, string? newFileName = null);
    }
}
