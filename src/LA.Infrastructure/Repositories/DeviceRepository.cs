using LA.Core.Models;
using LA.Core.Repositories;
using LA.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace LA.Infrastructure.Repositories
{
    public class DeviceRepository : IDeviceRepository
    {
        private readonly DatabaseContext _context;

        public DeviceRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<Device> GetById(string id)
        {
            return await _context.Devices
                .FirstAsync(x => x.Id.ToString() == id);
        }

        public async Task Create(Device device)
        {
            await _context.Devices.AddAsync(device);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Device device)
        {
            _context.Devices.Update(device);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Device device)
        {
            _context.Devices.Remove(device);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Exist(string name)
        {
            return await _context.Devices.AnyAsync(x => x.Name == name);
        }

        public async Task<bool> ExistByPhoneId(string phoneId)
        {
            return await _context.Devices
                .AnyAsync(x => string.Equals(
                    x.Id.ToString(),
                    phoneId));
        }
    }
}