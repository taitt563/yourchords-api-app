using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Domain.Common;
using YourChordsAPIApp.Domain.Entities;
using YourChordsAPIApp.Domain.Repositories;

namespace YourChordsAPIApp.Infrastructure.Repositories
{
    public class ChordRepository : IChordRepository
    {
        private readonly YourChordsDbContext _context;

        public ChordRepository(YourChordsDbContext context)
        {
            _context = context;
        }

        public async Task<Chord> GetChordByIdAsync(int chordId)
        {
            try
            {
                return await _context.Chords
                    .FindAsync(chordId);
            }
            catch (Exception ex)
            {
                // Handle or log the exception as needed
                throw new ApplicationException("An error occurred when getting the chord by ID.", ex);
            }
        }

        public async Task<IEnumerable<Chord>> GetAllAsync(int page, int pageSize, ChordFilter filter)
        {
            try
            {
                IQueryable<Chord> query = _context.Chords;

                // Apply filters
                if (!string.IsNullOrEmpty(filter.NameContains))
                {
                    query = query.Where(c => c.ChordName.Contains(filter.NameContains));
                }

                if (!string.IsNullOrEmpty(filter.Tone))
                {
                    query = query.Where(c => c.Tone == filter.Tone);
                }

                if (filter.TypeId.HasValue)
                {
                    query = query.Where(c => c.TypeId == filter.TypeId.Value);
                }

                if (filter.InstrumentId.HasValue)
                {
                    query = query.Where(c => c.InstrumentId == filter.InstrumentId.Value);
                }

                if (filter.CreatedAfter.HasValue)
                {
                    query = query.Where(c => c.CreatedAt >= filter.CreatedAfter.Value);
                }

                if (filter.CreatedBefore.HasValue)
                {
                    query = query.Where(c => c.CreatedAt <= filter.CreatedBefore.Value);
                }

                if (filter.CreatedBy.HasValue)
                {
                    query = query.Where(c => c.CreatedBy == filter.CreatedBy.Value);
                }

                if (filter.IsPrivate.HasValue)
                {
                    query = query.Where(c => c.IsPrivate == filter.IsPrivate.Value);
                }

                if (filter.IsVerified.HasValue)
                {
                    query = query.Where(c => c.IsVerified == filter.IsVerified.Value);
                }

                if (filter.IsDeleted.HasValue)
                {
                    query = query.Where(c => c.IsDeleted == filter.IsDeleted.Value);
                }
                var chords = await query
                    .Where(c => !c.IsDeleted) 
                    .OrderBy(c => c.Id) // Apply some sorting
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

                return chords;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred when getting all chords.", ex);
            }
        }


        public async Task<IEnumerable<Chord>> FindAsync(Expression<Func<Chord, bool>> predicate)
        {
            try
            {
                return await _context.Chords.Where(predicate).ToListAsync();
            }
            catch (Exception ex)
            {
                // Handle or log the exception as needed
                throw new ApplicationException("An error occurred when finding chords.", ex);
            }
        }

        public async Task<Chord> AddChordAsync(Chord chord)
        {
            try
            {
                _context.Chords.Add(chord);
                await _context.SaveChangesAsync();
                return chord;
            }
            catch (Exception ex)
            {
                // Handle or log the exception as needed
                throw new ApplicationException("An error occurred when adding a new chord.", ex);
            }
        }

        public async Task UpdateChordAsync(Chord chord)
        {
            try
            {
                _context.Entry(chord).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Handle or log the exception as needed
                throw new ApplicationException("An error occurred when updating the chord.", ex);
            }
        }

        public async Task<Chord> GetChordByIdForUpdateAsync(int chordId)
        {
            try
            {
                return await _context.Chords.SingleOrDefaultAsync(c => c.Id == chordId && !c.IsDeleted);
            }
            catch (Exception ex)
            {
                // Log the exception here if needed
                throw new ApplicationException($"An error occurred when trying to retrieve chord with ID {chordId}.", ex);
            }
        }

        public async Task DeleteChordAsync(Chord chord)
        {
            try
            {
                chord.IsDeleted = true;
                _context.Entry(chord).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new ApplicationException("A concurrency error happened while attempting to delete a chord.", ex);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred when deleting the chord.", ex);
            }
        }
        public async Task DeleteChordByIdAsync(int chordId)
        {
            try
            {
                Chord chordToDelete = await GetChordByIdForUpdateAsync(chordId);
                if (chordToDelete != null)
                {
                    await DeleteChordAsync(chordToDelete);
                }
                else
                {
                    throw new KeyNotFoundException($"A chord with the ID {chordId} was not found or is already deleted.");
                }
            }
            catch (KeyNotFoundException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred when trying to delete the chord.", ex);
            }
        }
        // Batch operations
        public async Task AddRangeAsync(IEnumerable<Chord> chords)
        {
            _context.Chords.AddRange(chords);
            await _context.SaveChangesAsync();
        }

        // Note: You'll need to implement the below methods according to your actual entity relationships and logic.

        public async Task<IEnumerable<Chord>> GetChordsWithDetailsAsync()
        {
            // You should adjust the Include methods according to your actual related entities.
            return await _context.Chords
                .Include(chord => chord.Instrument)
                .Include(chord => chord.ChordProgressions)
                .ToListAsync();
        }

        public async Task<IEnumerable<Chord>> GetByInstrumentIdAsync(int instrumentId)
        {
            return await _context.Chords
                .Where(chord => chord.InstrumentId == instrumentId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Chord>> GetByTypeIdAsync(int typeId)
        {
            return await _context.Chords
                .Where(chord => chord.TypeId == typeId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Chord>> GetPrivateChordsAsync()
        {
            return await _context.Chords
                .Where(chord => chord.IsPrivate)
                .ToListAsync();
        }

        public async Task<IEnumerable<Chord>> GetPublicVerifiedChordsAsync()
        {
            return await _context.Chords
                .Where(chord => !chord.IsPrivate && chord.IsVerified)
                .ToListAsync();
        }

        public async Task<IEnumerable<Chord>> SearchChordsAsync(string searchTerm)
        {
            return await _context.Chords
                .Where(chord => EF.Functions.Like(chord.ChordName, $"%{searchTerm}%") ||
                                EF.Functions.Like(chord.Description, $"%{searchTerm}%"))
                .ToListAsync();
        }

        public async Task<IEnumerable<Chord>> FilterChordsByToneAsync(string tone)
        {
            return await _context.Chords
                .Where(chord => chord.Tone == tone)
                .ToListAsync();
        }

        // Complexity and popularity methods would depend on your business logic and how these are defined.
        // For example, complexity might be a property you need to add to your Chords, 
        // or you might calculate it based on some criteria.

        public async Task<bool> IsChordInUseAsync(int chordId)
        {
            // This method would check if the chord is being used in chord progressions or elsewhere.
            return await _context.ChordProgressions.AnyAsync(cp => cp.ChordId == chordId);
        }

        public async Task<IEnumerable<Chord>> GetRecentlyAddedChordsAsync()
        {
            return await _context.Chords
                .OrderByDescending(chord => chord.CreatedAt)
                .ToListAsync();
        }

        public async Task<IEnumerable<Chord>> GetRecentlyModifiedChordsAsync()
        {
            return await _context.Chords
                .Where(chord => chord.LastModified.HasValue)
                .OrderByDescending(chord => chord.LastModified)
                .ToListAsync();
        }

        public async Task<IEnumerable<Chord>> GetChordsAddedByDateAsync(DateTime date)
        {
            return await _context.Chords
                .Where(chord => chord.CreatedAt.Date == date.Date)
                .ToListAsync();
        }

        public async Task<bool> CanUserModifyChordAsync(int userId, int chordId)
        {
            var chord = await _context.Chords.FindAsync(chordId);
            return chord != null && chord.CreatedBy == userId;
        }

        public async Task UpdateRangeAsync(IEnumerable<Chord> chords)
        {
            _context.Chords.UpdateRange(chords);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRangeAsync(IEnumerable<Chord> chords)
        {
            _context.Chords.RemoveRange(chords);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Chord>> GetChordsCreatedByUserAsync(int userId)
        {
            return await _context.Chords
                .Where(chord => chord.CreatedBy == userId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Chord>> FilterChordsByComplexityAsync(int complexityLevel)
        {
            // Here's an example where complexity is calculated.
            // Let's assume complexity is based on the number of components in the chord.
            // The more components, the higher the complexity.
            return await _context.Chords
                .Where(chord => chord.Components.Split(new[] { ',' }, StringSplitOptions.None).Length == complexityLevel) // Assuming Components are stored as a comma-separated string.
                .ToListAsync();
        }

        // Etc...
    }
}
