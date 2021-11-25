using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.IServices
{
    public interface IUtilityService
    {
        /// <summary>
        /// Save file and return this file path
        /// </summary>
        /// <param name="file"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        string SaveFile(IFormFile file, string path);

        /// <summary>
        /// Read email confirm
        /// </summary>
        /// <param name="username"></param>
        /// <param name="confirmLink"></param>
        /// <returns></returns>
        string ReadEmailContent(string username, string confirmLink);

        /// <summary>
        /// Read email for order
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        string ReadEmailContent(string username);

        bool RemoveFile(string path);
    }
}
