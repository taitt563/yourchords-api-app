using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Application.Common.Mappings;
using YourChordsAPIApp.Domain.Entities;

namespace YourChordsAPIApp.Application.ArtistGenres.Queries.GetAllArtistGenres
{
    public class ArtistGenreVm : IMapFrom<ArtistGenre>
    {
        public int Id { get; set; }
        public int ArtistId { get; set; }
        public int GenreId { get; set; }

        // Implement IMapFrom interface
        public void Mapping(Profile profile)
        {
            profile.CreateMap<ArtistGenre, ArtistGenreVm>();
        }
    }

}
