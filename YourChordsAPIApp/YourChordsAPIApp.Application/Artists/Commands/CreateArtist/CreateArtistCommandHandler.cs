using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Application.Artists.Queries.GetArtists;
using YourChordsAPIApp.Domain.Entities;
using YourChordsAPIApp.Domain.Repositories;

namespace YourChordsAPIApp.Application.Artists.Commands.CreateArtist
{
    public class CreateArtistCommandHandler : IRequestHandler<CreateArtistCommand, ArtistVm>
    {
        private readonly IArtistRepository _artistRepository;
        private readonly IMapper _mapper;

        public CreateArtistCommandHandler(IArtistRepository artistRepository, IMapper mapper)
        {
            _artistRepository = artistRepository;
            _mapper = mapper;
        }

        public async Task<ArtistVm> Handle(CreateArtistCommand request, CancellationToken cancellationToken)
        {
            var artist = new Artist
            {
                Name = request.Name,
                Dob = request.Dob,
                Country = request.Country,
                Bio = request.Bio,
                ProfilePic = request.ProfilePic,
                ExternalLink = request.ExternalLink,
                Popularity = request.Popularity
            };

            await _artistRepository.AddArtistAsync(artist);

            return _mapper.Map<ArtistVm>(artist);
        }
    }

}
