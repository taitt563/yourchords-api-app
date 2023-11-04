using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Application.Artists.Queries.GetArtists;
using YourChordsAPIApp.Domain.Entities;
using YourChordsAPIApp.Domain.Repositories;

namespace YourChordsAPIApp.Infrastructure.Repositories
{
    public class ArtistRepository : IArtistRepository
    {
        private readonly YourChordsDbContext _context;

        public ArtistRepository(YourChordsDbContext context)
        {
            _context = context;
        }

        public async Task<Artist> GetArtistByIdAsync(int artistId)
        {
            // Fetch the artist including related genres
            var artist = await _context.Artists
                .Include(a => a.ArtistGenres)
                .ThenInclude(ag => ag.Genre)
                .SingleOrDefaultAsync(a => a.Id == artistId);


            return artist;
        }

        public async Task<Artist> GetArtistByNameAsync(string artistName)
        {
            return await _context.Artists
                .FirstOrDefaultAsync(a => a.Name == artistName);
        }

        public async Task<IEnumerable<Artist>> GetAllArtistsAsync()
        {
            return await _context.Artists.ToListAsync();
        }

        public async Task AddArtistAsync(Artist artist)
        {
            _context.Artists.Add(artist);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateArtistAsync(Artist artist)
        {
            _context.Entry(artist).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteArtistAsync(int artistId)
        {
            var artist = await _context.Artists.FindAsync(artistId);

            if (artist != null)
            {
                _context.Artists.Remove(artist);
                await _context.SaveChangesAsync();
            }
        }
    }

}
