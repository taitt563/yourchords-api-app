using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Application.ArtistGenres.Queries.GetAllArtistGenres;

namespace YourChordsAPIApp.Application.ArtistGenres.Commands.UpdateArtistGenre
{
    public class UpdateArtistGenreCommand : IRequest<ArtistGenreVm>
    {
        public int ArtistGenreId { get; set; }
        public int ArtistId { get; set; }
        public int GenreId { get; set; }
    }

}
