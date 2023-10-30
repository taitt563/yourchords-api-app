using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Application.Artists.Queries.GetArtists;

namespace YourChordsAPIApp.Application.Artists.Queries.GetArtistByName
{
    public class GetArtistByNameQuery : IRequest<ArtistVm>
    {
        public string ArtistName { get; set; }
    }

}
