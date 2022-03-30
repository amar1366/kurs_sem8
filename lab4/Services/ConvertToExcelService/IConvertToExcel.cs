using System.Threading.Tasks;

namespace lab4.Services
{
    public interface IConvertToExcel
    { 
        public Task<byte[]> ConvertDbToExcel();
    }
}
