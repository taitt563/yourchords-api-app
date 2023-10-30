using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourChordsAPIApp.Application.ArtistGenres.Queries.GetAllArtistGenres
{
    public class GetAllArtistGenresQuery : IRequest<IEnumerable<ArtistGenreVm>>
    {
    }

}
