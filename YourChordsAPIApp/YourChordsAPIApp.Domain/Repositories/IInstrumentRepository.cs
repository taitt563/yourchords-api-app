using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Domain.Entities;

namespace YourChordsAPIApp.Domain.Repositories
{
    public interface IInstrumentRepository
    {
        Task<Instrument> GetByIdAsync(int id);
        Task<IEnumerable<Instrument>> GetAllAsync();
        Task<IEnumerable<Instrument>> FindAsync(Expression<Func<Instrument, bool>> predicate);
        Task<Instrument> AddAsync(Instrument instrument);
        Task UpdateAsync(Instrument instrument);
        Task DeleteAsync(Instrument instrument);
        Task<IEnumerable<Instrument>> GetInstrumentsByStatusAsync(bool status);
        Task<IEnumerable<Instrument>> SearchInstrumentsByNameAsync(string name);
        // More methods for business rules, like getting popular instruments or instruments with the most beats, etc.
    }
}
