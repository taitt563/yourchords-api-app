using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Application.Artists.Queries.GetArtists;

namespace YourChordsAPIApp.Application.Artists.Queries.GetArtistById
{
    public class GetArtistByIdQuery : IRequest<ArtistVm>
    {
        public int ArtistId { get; set; }
    }

}
