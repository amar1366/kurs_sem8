using Microsoft.AspNetCore.Http;
using lab4.Storage.Entity;
using System.Threading.Tasks;

namespace lab4.Services
{
    public interface ISettingEDSFileService
    {
        public Task<MyFileInfo> CreateСertificateAsync(int months);
        public Task<MyFileInfo> SignFileAsync(IFormFile uploadedFile, IFormFile privateKey, string password);
        public Task<MyFileInfo> GetOriginalFileAsync(IFormFile uploadedFile);
        public Task<bool> CheckSignFileAsync(IFormFile uploadedFile, IFormFile publicKey, string password);
    }
}
