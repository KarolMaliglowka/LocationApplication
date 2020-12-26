using System;
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
    }
}