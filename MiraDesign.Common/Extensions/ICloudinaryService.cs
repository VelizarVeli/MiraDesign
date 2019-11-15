using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace MiraDesign.Common.Extensions
{
   public interface ICloudinaryService
    {
        Task<string> UploadPictureAsync(IFormFile pictureFile, string fileName);
    }
}
