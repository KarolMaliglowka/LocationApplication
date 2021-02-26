using LA.Core.Models;
using System;
using System.Threading.Tasks;

namespace LA.Core.Repositories
{
    public interface IDeviceRepository
    {
        Task<Device> GetById(Guid id);
        Task Create(Device device);
        Task Update(Device device);
        Task Delete(Device device);
        Task<bool> ExistByPhoneId(string phoneId);
    }
}