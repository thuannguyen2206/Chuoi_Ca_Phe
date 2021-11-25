using Common.Constants;
using Common.Helper;
using Microsoft.AspNetCore.Http;
using Service.IServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Service.Services
{
    public class UtilityService : IUtilityService
    {
        public readonly IStorageService _storageService;

        public UtilityService(IStorageService storageService)
        {
            _storageService = storageService;
        }

        public string ReadEmailContent(string username, string confirmLink)
        {
            string directory = Directory.GetCurrentDirectory();
            var fullPath = string.Format("{0}{1}", directory, "\\Pages\\confirm-email.html");
            string htmlContent = File.ReadAllText(fullPath);
            htmlContent = htmlContent.Replace("{{Username}}", username);
            htmlContent = htmlContent.Replace("{{ConfirmLink}}", confirmLink);
            htmlContent = htmlContent.Replace("{{TimeConfirm}}", SystemConstants.ExpireTimeConfirmEmail.ToString());
            return htmlContent;
        }

        public string ReadEmailContent(string username)
        {
            string directory = Directory.GetCurrentDirectory();
            var fullPath = string.Format("{0}{1}", directory, "\\Pages\\confirm-email.html");
            string htmlContent = File.ReadAllText(fullPath);
            htmlContent = htmlContent.Replace("{{Username}}", username);
            htmlContent = htmlContent.Replace("{{ConfirmLink}}", "");
            htmlContent = htmlContent.Replace("{{TimeConfirm}}", SystemConstants.ExpireTimeConfirmEmail.ToString());
            return htmlContent;
        }

        public bool RemoveFile(string path)
        {
            return _storageService.DeleteFile(path);
        }

        public string SaveFile(IFormFile file, string path)
        {
            string uniqueFileName = DateTime.Now.ToString("yyyyMMddHHmmss") + "_" + file.FileName.Trim();
            _storageService.SaveFile(file.OpenReadStream(), string.Concat("/", path, uniqueFileName));
            return _storageService.GetFilePath(string.Concat(path + uniqueFileName));
        }

    }
}
