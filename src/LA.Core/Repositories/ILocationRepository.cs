using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LA.Core.Models;

namespace LA.Core.Repositories
{
    public interface ILocationRepository
    {
        Task<Location> GetById(Guid id);
        Task Create(Location location);
        Task Update(Location location);
        Task Delete(Location location);
        Task<List<Location>> GetDeviceLocationsByDate(DateTime dateTime, Guid deviceId);
        Task<List<Location>> GetAllDevicesLocationsByDate(DateTime dateTime);
        Task<List<Location>> GetDeviceLocationsByDateRange(DateTime startDateTime, DateTime endDateTime, Guid deviceId);
        Task<List<Location>> GetAllDevicesLocationsByDateRange(DateTime startDateTime, DateTime endDateTime);
    }
}