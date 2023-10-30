using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Domain.Entities;

namespace YourChordsAPIApp.Domain.Repositories
{
    public interface IChordTypeRepository
    {
        Task<ChordType> GetChordTypeByIdAsync(int chordTypeId);
        Task<IEnumerable<ChordType>> GetAllChordTypesAsync();
        Task AddChordTypeAsync(ChordType chordType);
        Task UpdateChordTypeAsync(ChordType chordType);
        Task DeleteChordTypeAsync(int chordTypeId);
    }
}
