using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Application.ArtistGenres.Queries.GetAllArtistGenres;

namespace YourChordsAPIApp.Application.ArtistGenres.Queries.GetArtistGenreByGenreId
{
    public class GetArtistGenresByGenreIdQuery : IRequest<IEnumerable<ArtistGenreVm>>
    {
        public int GenreId { get; set; }
    }

}
