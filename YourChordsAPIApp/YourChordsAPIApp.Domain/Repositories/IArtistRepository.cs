using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Domain.Entities;

namespace YourChordsAPIApp.Domain.Repositories
{
    public interface IArtistRepository
    {
        Task<Artist> GetArtistByIdAsync(int artistId);
        Task<Artist> GetArtistByNameAsync(string artistName);
        Task<IEnumerable<Artist>> GetAllArtistsAsync();
        Task AddArtistAsync(Artist artist);
        Task UpdateArtistAsync(Artist artist);
        Task DeleteArtistAsync(int artistId);
    }
}
