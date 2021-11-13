using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace Core.Utilities.Helpers
{
    public class FileHelper
    {
        public static string Add(IFormFile file)
        {
            var sourcepath = Path.GetTempFileName();
            if (file.Length > 0)
            {
                using (var stream = new FileStream(sourcepath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }

            FileInfo fileInfo = new FileInfo(file.FileName);
            string fileExtension = fileInfo.Extension;
            var path = Guid.NewGuid().ToString() + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + "_" + DateTime.Now.Year + fileExtension;


            var result = NewPath(path);
            File.Move(sourcepath, result);
            return path;
        }
        public static void Delete(string path)
        {
            File.Delete(path);
        }
        public static string Update(string oldPath, IFormFile file)
        {
            Delete(oldPath);
            return Add(file);
        }
        public static string NewPath(string file)
        {
            string path = Environment.CurrentDirectory + @"\wwwroot\images\";

            string result = $@"{path}\{file}";
            return result;
        }

    }
}