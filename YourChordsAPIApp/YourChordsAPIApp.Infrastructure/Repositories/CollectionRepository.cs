using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Domain.Entities;
using YourChordsAPIApp.Domain.Repositories;

namespace YourChordsAPIApp.Infrastructure.Repositories
{
    public class CollectionRepository : ICollectionRepository
    {
        private readonly YourChordsDbContext _context;

        public CollectionRepository(YourChordsDbContext context)
        {
            _context = context;
        }

        public async Task<Collection> GetByIdAsync(int id)
        {
            return await _context.Collections
                .Include(c => c.CollectionSongs)
                .Include(c => c.User)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Collection>> GetAllAsync()
        {
            return await _context.Collections
                .Include(c => c.CollectionSongs)
                .Include(c => c.User)
                .ToListAsync();
        }

        public async Task<IEnumerable<Collection>> GetByUserIdAsync(int userId)
        {
            return await _context.Collections
                .Include(c => c.CollectionSongs)
                .Include(c => c.User)
                .Where(c => c.UserId == userId)
                .ToListAsync();
        }

        public async Task<Collection> AddAsync(Collection collection)
        {
            _context.Collections.Add(collection);
            await _context.SaveChangesAsync();
            return collection;
        }

        public async Task UpdateAsync(Collection collection)
        {
            _context.Collections.Update(collection);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Collection collection)
        {
            _context.Collections.Remove(collection);
            await _context.SaveChangesAsync();
        }
    }
}
