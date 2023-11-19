namespace AspNet_MVC_VPD111.Helpers
{
    public interface IFileService
    {
        Task<string> SaveFileAsync(IFormFile file);
    }
}
