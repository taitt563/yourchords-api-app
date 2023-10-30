using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourChordsAPIApp.Application.Artists.Commands.DeleteArtist
{
    public class DeleteArtistCommand : IRequest<Unit>
    {
        public int ArtistId { get; set; }
    }

}
