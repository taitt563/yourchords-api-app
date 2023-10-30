using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourChordsAPIApp.Application.ArtistGenres.Queries.GetIdByArtistId
{
    public class GetArtistGenreIdsByArtistIdQuery : IRequest<IEnumerable<int>>
    {
        public int ArtistId { get; set; }
    }


}
