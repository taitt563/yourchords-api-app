using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Domain.Entities;
using YourChordsAPIApp.Domain.Repositories;

namespace YourChordsAPIApp.Infrastructure.Repositories
{
    public class InstrumentRepository : IInstrumentRepository
    {
        private readonly YourChordsDbContext _context;

        public InstrumentRepository(YourChordsDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Instrument> GetByIdAsync(int id)
        {
            return await _context.Instruments.FindAsync(id);
        }

        public async Task<IEnumerable<Instrument>> GetAllAsync()
        {
            return await _context.Instruments.ToListAsync();
        }

        public async Task<IEnumerable<Instrument>> FindAsync(Expression<Func<Instrument, bool>> predicate)
        {
            return await _context.Instruments.Where(predicate).ToListAsync();
        }

        public async Task<Instrument> AddAsync(Instrument instrument)
        {
            _context.Instruments.Add(instrument);
            await _context.SaveChangesAsync();
            return instrument;
        }

        public async Task UpdateAsync(Instrument instrument)
        {
            _context.Entry(instrument).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Instrument instrument)
        {
            _context.Instruments.Remove(instrument);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Instrument>> GetInstrumentsByStatusAsync(bool status)
        {
            return await _context.Instruments
                                 .Where(i => i.Status == status)
                                 .ToListAsync();
        }

        public async Task<IEnumerable<Instrument>> SearchInstrumentsByNameAsync(string name)
        {
            return await _context.Instruments
                                 .Where(i => i.InstrumentName.Contains(name))
                                 .ToListAsync();
        }

        // Implement additional methods as needed...
    }
}
