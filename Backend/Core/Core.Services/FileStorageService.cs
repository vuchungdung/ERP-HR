using Core.Services.InterfaceService;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;


namespace Core.Services
{
    public class FileStorageService : IStorageService
    {
        private readonly string _cadidateContentFolder;
        private const string CADIDATE_CONTENT_FOLDER_NAME = "cadidate-cv";

        public FileStorageService(IHostingEnvironment webHostEnvironment)
        {
            _cadidateContentFolder = Path.Combine(webHostEnvironment.WebRootPath, CADIDATE_CONTENT_FOLDER_NAME);
        }

        public string GetFileUrl(string fileName)
        {
            return $"/{CADIDATE_CONTENT_FOLDER_NAME}/{fileName}";
        }

        public async Task SaveFileAsync(Stream mediaBinaryStream, string fileName)
        {
            if (!Directory.Exists(_cadidateContentFolder))
                Directory.CreateDirectory(_cadidateContentFolder);

            var filePath = Path.Combine(_cadidateContentFolder, fileName);
            using var output = new FileStream(filePath, FileMode.Create);
            await mediaBinaryStream.CopyToAsync(output);
        }

        public async Task DeleteFileAsync(string fileName)
        {
            var filePath = Path.Combine(_cadidateContentFolder, fileName);
            if (File.Exists(filePath))
            {
                await Task.Run(() => File.Delete(filePath));
            }
        }
    }
}
