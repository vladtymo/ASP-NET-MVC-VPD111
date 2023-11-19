using Azure.Storage.Blobs;

namespace AspNet_MVC_VPD111.Helpers
{
    public class AzureFileService : IFileService
    {
        private string connectionString;
        private string containerName = "images";
        public AzureFileService(IConfiguration configuration)
        {
            this.connectionString = configuration.GetConnectionString("AzureStorage");
        }
        public async Task<string> SaveFileAsync(IFormFile file)
        {
            var client = new BlobContainerClient(connectionString, containerName);

            await client.CreateIfNotExistsAsync();
            await client.SetAccessPolicyAsync(Azure.Storage.Blobs.Models.PublicAccessType.Blob);

            // custom file name
            string name = Guid.NewGuid().ToString();    // random name
            string extension = Path.GetExtension(file.FileName); // get original extension
            string fileName = name + extension;         // full name: name.ext

            BlobClient blob = client.GetBlobClient(fileName);
            await blob.UploadAsync(file.OpenReadStream());
            return blob.Uri.ToString();
        }
    }
}
