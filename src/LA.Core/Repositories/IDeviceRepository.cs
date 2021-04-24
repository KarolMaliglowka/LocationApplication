using LA.Core.Models;
using System.Threading.Tasks;

namespace LA.Core.Repositories
{
    public interface IDeviceRepository
    {
        Task<Device> GetById(string id);
        Task Create(Device device);
        Task Update(Device device);
        Task Delete(Device device);
        Task<bool> ExistByPhoneId(string phoneId);
    }
}