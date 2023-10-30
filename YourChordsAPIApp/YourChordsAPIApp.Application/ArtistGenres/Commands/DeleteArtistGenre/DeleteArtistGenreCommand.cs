using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourChordsAPIApp.Application.ArtistGenres.Commands.DeleteArtistGenre
{
    public class DeleteArtistGenreCommand : IRequest<Unit>
    {
        public int ArtistGenreId { get; set; }
    }

}
