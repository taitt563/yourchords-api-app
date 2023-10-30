using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Application.ArtistGenres.Queries.GetAllArtistGenres;

namespace YourChordsAPIApp.Application.ArtistGenres.Queries.GetArtistGenreById
{
    public class GetArtistGenreByIdQuery : IRequest<ArtistGenreVm>
    {
        public int ArtistGenreId { get; set; }
    }

}
