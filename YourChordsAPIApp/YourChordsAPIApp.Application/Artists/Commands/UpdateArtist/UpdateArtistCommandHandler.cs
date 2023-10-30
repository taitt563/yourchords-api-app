using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Application.Artists.Queries.GetArtists;
using YourChordsAPIApp.Domain.Repositories;

namespace YourChordsAPIApp.Application.Artists.Commands.UpdateArtist
{
    public class UpdateArtistCommandHandler : IRequestHandler<UpdateArtistCommand, ArtistVm>
    {
        private readonly IArtistRepository _artistRepository;
        private readonly IMapper _mapper;

        public UpdateArtistCommandHandler(IArtistRepository artistRepository, IMapper mapper)
        {
            _artistRepository = artistRepository;
            _mapper = mapper;
        }

        public async Task<ArtistVm> Handle(UpdateArtistCommand request, CancellationToken cancellationToken)
        {
            var existingArtist = await _artistRepository.GetArtistByIdAsync(request.ArtistId);

            if (existingArtist == null)
            {
                // Handle the case where the artist with the provided ID is not found
                // You can throw an exception or return an appropriate response
            }

            existingArtist.Name = request.Name;
            existingArtist.Dob = request.Dob;
            existingArtist.Country = request.Country;
            existingArtist.Bio = request.Bio;
            existingArtist.ProfilePic = request.ProfilePic;
            existingArtist.ExternalLink = request.ExternalLink;
            existingArtist.Popularity = request.Popularity;

            await _artistRepository.UpdateArtistAsync(existingArtist);

            return _mapper.Map<ArtistVm>(existingArtist);
        }
    }

}
