using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Application.ArtistGenres.Queries.GetAllArtistGenres;

namespace YourChordsAPIApp.Application.ArtistGenres.Commands.CreateArtistGenre
{
    public class CreateArtistGenreCommand : IRequest<ArtistGenreVm>
    {
        public int ArtistId { get; set; }
        public int GenreId { get; set; }
    }

}
