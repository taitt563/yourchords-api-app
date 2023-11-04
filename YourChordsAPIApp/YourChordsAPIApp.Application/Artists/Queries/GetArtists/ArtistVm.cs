using AutoMapper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Application.Common.Mappings;
using YourChordsAPIApp.Domain.Entities;

namespace YourChordsAPIApp.Application.Artists.Queries.GetArtists
{
    public class ArtistVm : IMapFrom<Artist>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Dob { get; set; }
        public string? Country { get; set; }
        public string? Bio { get; set; }
        public string? ProfilePic { get; set; }
        public string? ExternalLink { get; set; }
        public int? Popularity { get; set; }
        public List<string>? Genres { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Artist, ArtistVm>()
                .ForMember(dest => dest.Dob, opt => opt.MapFrom(src => src.Dob.HasValue ? src.Dob.Value.ToString("yyyy-MM-dd") : ""))
                .ForMember(dest => dest.Genres, opt => opt.MapFrom(src => src.ArtistGenres.Select(ag => ag.Genre.GenreName)));

        }
    }
}
