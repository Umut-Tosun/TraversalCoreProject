using Microsoft.AspNetCore.Http;
using System.IO;
using System;

namespace TraversalCoreProject.Methods
{
    public class FileService
    {
        public static string CreateToIFormFile(IFormFile formFile)
        {
            string returnPath;
            try
            {
                string imageExtension = Path.GetExtension(formFile.FileName);
                string imageName = Guid.NewGuid() + imageExtension;
                string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/Content/{imageName}");
                using var stream = new FileStream(path, FileMode.Create);
                formFile.CopyTo(stream);
                return returnPath = "/Content/" + imageName;
            }
            catch (Exception)
            {
                return returnPath = null;
            }
        }
    }
}
