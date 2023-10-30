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
    public class ChordTypeRepository : IChordTypeRepository
    {
        private readonly YourChordsDbContext _context;

        public ChordTypeRepository(YourChordsDbContext context)
        {
            _context = context;
        }

        public async Task<ChordType> GetChordTypeByIdAsync(int chordTypeId)
        {
            return await _context.ChordTypes.FindAsync(chordTypeId);
        }

        public async Task<IEnumerable<ChordType>> GetAllChordTypesAsync()
        {
            return await _context.ChordTypes.ToListAsync();
        }

        public async Task AddChordTypeAsync(ChordType chordType)
        {
            _context.ChordTypes.Add(chordType);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateChordTypeAsync(ChordType chordType)
        {
            _context.Entry(chordType).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteChordTypeAsync(int chordTypeId)
        {
            var chordType = await _context.ChordTypes.FindAsync(chordTypeId);

            if (chordType != null)
            {
                _context.ChordTypes.Remove(chordType);
                await _context.SaveChangesAsync();
            }
        }
    }
}
