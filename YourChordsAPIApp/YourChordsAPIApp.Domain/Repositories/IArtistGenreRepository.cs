using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Domain.Entities;

namespace YourChordsAPIApp.Domain.Repositories
{
    public interface IArtistGenreRepository
    {
        Task<ArtistGenre> GetArtistGenreByIdAsync(int artistGenreId);
        Task<IEnumerable<ArtistGenre>> GetAllArtistGenresAsync();
        Task<IEnumerable<ArtistGenre>> GetArtistGenresByArtistIdAsync(int artistId);
        Task<IEnumerable<ArtistGenre>> GetArtistGenresByGenreIdAsync(int genreId);
        Task AddArtistGenreAsync(ArtistGenre artistGenre);
        Task UpdateArtistGenreAsync(ArtistGenre artistGenre);
        Task DeleteArtistGenreAsync(int artistGenreId);
        Task<IEnumerable<int>> GetArtistGenreIdsByArtistIdAsync(int artistId);
    }

}
