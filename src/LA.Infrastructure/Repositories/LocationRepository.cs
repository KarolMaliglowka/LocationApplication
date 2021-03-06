﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LA.Core.Models;
using LA.Core.Repositories;
using LA.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LA.Infrastructure.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        private readonly DatabaseContext _context;

        public LocationRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<Location> GetById(Guid id)
        {
            return await _context.Localizations
                .FirstAsync(x => x.Id == id);
        }

        public async Task Create(Location location)
        {
            await _context.Localizations.AddAsync(location);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Location location)
        {
            _context.Localizations.Update(location);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Location location)
        {
            _context.Localizations.Remove(location);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Location>> GetAllDevicesLocationsByDate(DateTime dateTime)
        {
            return await _context.Localizations
                .Where(x => x.CreatedAt == dateTime)
                .ToListAsync();
        }

        public async Task<List<Location>> GetDeviceLocationsByDate(DateTime dateTime, Guid deviceId)
        {
            return await _context.Localizations
                .Where(x => x.CreatedAt == dateTime && x.DeviceId == deviceId)
                .ToListAsync();
        }

        public async Task<List<Location>> GetDeviceLocationsByDateRange(DateTime startDateTime, DateTime endDateTime,
            Guid deviceId)
        {
            return await _context.Localizations
                .Where(x => x.CreatedAt > startDateTime
                            && x.CreatedAt < endDateTime
                            && x.DeviceId == deviceId)
                .ToListAsync();
        }

        public async Task<List<Location>> GetAllDevicesLocationsByDateRange(DateTime startDateTime,
            DateTime endDateTime)
        {
            return await _context.Localizations
                .Where(x => x.CreatedAt > startDateTime
                            && x.CreatedAt < endDateTime)
                .ToListAsync();
        }
    }
}