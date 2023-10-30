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
    public class ArtistGenreRepository : IArtistGenreRepository
    {
        private readonly YourChordsDbContext _context;

        public ArtistGenreRepository(YourChordsDbContext context)
        {
            _context = context;
        }

        public async Task<ArtistGenre> GetArtistGenreByIdAsync(int artistGenreId)
        {
            return await _context.ArtistGenres.FindAsync(artistGenreId);
        }

        public async Task<IEnumerable<ArtistGenre>> GetAllArtistGenresAsync()
        {
            return await _context.ArtistGenres.ToListAsync();
        }

        public async Task<IEnumerable<ArtistGenre>> GetArtistGenresByArtistIdAsync(int artistId)
        {
            return await _context.ArtistGenres.Where(ag => ag.ArtistId == artistId).ToListAsync();
        }

        public async Task<IEnumerable<ArtistGenre>> GetArtistGenresByGenreIdAsync(int genreId)
        {
            return await _context.ArtistGenres.Where(ag => ag.GenreId == genreId).ToListAsync();
        }

        public async Task AddArtistGenreAsync(ArtistGenre artistGenre)
        {
            _context.ArtistGenres.Add(artistGenre);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateArtistGenreAsync(ArtistGenre artistGenre)
        {
            _context.Entry(artistGenre).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteArtistGenreAsync(int artistGenreId)
        {
            var artistGenre = await _context.ArtistGenres.FindAsync(artistGenreId);

            if (artistGenre != null)
            {
                _context.ArtistGenres.Remove(artistGenre);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<int>> GetArtistGenreIdsByArtistIdAsync(int artistId)
        {
            var artistGenres = await _context.ArtistGenres
                .Where(ag => ag.ArtistId == artistId)
                .Select(ag => ag.Id)
                .ToListAsync();

            return artistGenres;
        }
    }

}
