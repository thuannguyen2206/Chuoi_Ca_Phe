using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Service.IServices
{
    public interface IStorageService
    {
        void SaveFile(Stream stream, string path);

        string GetFilePath(string path);

        bool DeleteFile(string path);
    }
}
