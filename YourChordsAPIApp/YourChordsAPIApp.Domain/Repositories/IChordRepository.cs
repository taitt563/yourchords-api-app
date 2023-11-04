using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Domain.Common;
using YourChordsAPIApp.Domain.Entities;

namespace YourChordsAPIApp.Domain.Repositories
{
    public interface IChordRepository
    {
        // Basic CRUD operations
        Task<Chord> GetChordByIdAsync(int chordId);
        Task<IEnumerable<Chord>> GetAllAsync(int page, int pageSize, ChordFilter filter);
        Task<IEnumerable<Chord>> FindAsync(Expression<Func<Chord, bool>> predicate);
        Task<Chord> AddChordAsync(Chord chord);
        Task UpdateChordAsync(Chord chord);
        Task<Chord> GetChordByIdForUpdateAsync(int chordId);
        Task DeleteChordAsync(Chord chord);
        Task DeleteChordByIdAsync(int chordId);

        // Batch operations
        Task AddRangeAsync(IEnumerable<Chord> chords);
        Task UpdateRangeAsync(IEnumerable<Chord> chords);
        Task DeleteRangeAsync(IEnumerable<Chord> chords);

        // Retrieval with conditions
        Task<IEnumerable<Chord>> GetByInstrumentIdAsync(int instrumentId);
        Task<IEnumerable<Chord>> GetByTypeIdAsync(int typeId);
        Task<IEnumerable<Chord>> GetChordsWithDetailsAsync(); // Includes related entities
        Task<IEnumerable<Chord>> GetChordsCreatedByUserAsync(int userId);
        Task<IEnumerable<Chord>> GetPrivateChordsAsync();
        Task<IEnumerable<Chord>> GetPublicVerifiedChordsAsync();

        // Search and filtering
        Task<IEnumerable<Chord>> SearchChordsAsync(string searchTerm);
        Task<IEnumerable<Chord>> FilterChordsByToneAsync(string tone);
        Task<IEnumerable<Chord>> FilterChordsByComplexityAsync(int complexityLevel);

        // Advanced operations
        Task<bool> IsChordInUseAsync(int chordId);

        // Auditing
        Task<IEnumerable<Chord>> GetRecentlyAddedChordsAsync();
        Task<IEnumerable<Chord>> GetRecentlyModifiedChordsAsync();
        Task<IEnumerable<Chord>> GetChordsAddedByDateAsync(DateTime date);

        // Authorization and access control
        Task<bool> CanUserModifyChordAsync(int userId, int chordId);
    }
}
