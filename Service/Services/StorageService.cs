using Microsoft.AspNetCore.Hosting;
using Service.IServices;
using System;
using System.Collections.Generic;
using System.IO;

namespace Service.Services
{
    public class StorageService : IStorageService
    {
        private readonly string _userContentFolder;
        private const string ContentRootFolder = "assets";
        private readonly IWebHostEnvironment _env;

        public StorageService(IWebHostEnvironment env)
        {
            _env = env;
            _userContentFolder = Path.Combine(env.ContentRootPath, ContentRootFolder);
        }

        public void SaveFile(Stream stream, string path)
        {
            var fullPath = _userContentFolder + path;
            using (var output = new FileStream(fullPath, FileMode.Create))
            {
                stream.CopyToAsync(output);
            }
        }

        public string GetFilePath(string path)
        {
            return $"/{ContentRootFolder}/{path}";
        }

        public bool DeleteFile(string path)
        {
            var filePath = string.Concat(_env.ContentRootPath, path);
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                return true;
            }
            return false;
        }
    }
}
