using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Application.Artists.Queries.GetArtists;

namespace YourChordsAPIApp.Application.Artists.Commands.UpdateArtist
{
    public class UpdateArtistCommand : IRequest<ArtistVm>
    {
        public int ArtistId { get; set; }
        public string Name { get; set; }
        public DateTime? Dob { get; set; }
        public string Country { get; set; }
        public string Bio { get; set; }
        public string ProfilePic { get; set; }
        public string ExternalLink { get; set; }
        public int Popularity { get; set; }
    }

}
