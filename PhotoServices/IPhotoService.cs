using Microsoft.AspNetCore.Http;
using PhotoServices.ResultEnums;

namespace PhotoServices
{
    public interface IPhotoService
    {
        Task<UploadResult> AddPhotoAsync(IFormFile file);

        Task<DeleteResult> DeletePhotoAsync(string publicUrl);
    }
}