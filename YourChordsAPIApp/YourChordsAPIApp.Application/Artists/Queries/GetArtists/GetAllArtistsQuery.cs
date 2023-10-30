using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourChordsAPIApp.Application.Artists.Queries.GetArtists
{
    public class GetAllArtistsQuery : IRequest<IEnumerable<ArtistVm>>
    {
    }
}
