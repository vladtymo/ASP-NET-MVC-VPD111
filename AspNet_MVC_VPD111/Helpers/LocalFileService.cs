using System;

namespace AspNet_MVC_VPD111.Helpers
{
    public class LocalFileService : IFileService
    {
        private readonly IWebHostEnvironment environment;
        private string imageFolder = "images";
       
        public LocalFileService(IWebHostEnvironment environment)
        {
            this.environment = environment;
        }

        public async Task<string> SaveFileAsync(IFormFile file)
        {
            // get image destination path
            string root = environment.WebRootPath;      // wwwroot
            string name = Guid.NewGuid().ToString();    // random name
            string extension = Path.GetExtension(file.FileName); // get original extension
            string fileName = name + extension;         // full name: name.ext

            // create destination image file path
            string imagePath = Path.Combine(imageFolder, fileName);
            string imageFullPath = Path.Combine(root, imagePath);

            // save image on the folder
            using (FileStream fs = new FileStream(imageFullPath, FileMode.Create))
            {
                await file.CopyToAsync(fs);
            }

            // return image file path
            return imagePath;
        }
    }
}
