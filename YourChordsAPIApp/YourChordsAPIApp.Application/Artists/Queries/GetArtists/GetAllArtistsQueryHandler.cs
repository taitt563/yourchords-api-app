using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Domain.Repositories;

namespace YourChordsAPIApp.Application.Artists.Queries.GetArtists
{
    public class GetAllArtistsQueryHandler : IRequestHandler<GetAllArtistsQuery, IEnumerable<ArtistVm>>
    {
        private readonly IArtistRepository _artistRepository;
        private readonly IMapper _mapper;

        public GetAllArtistsQueryHandler(IArtistRepository artistRepository, IMapper mapper)
        {
            _artistRepository = artistRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ArtistVm>> Handle(GetAllArtistsQuery request, CancellationToken cancellationToken)
        {
            var artists = await _artistRepository.GetAllArtistsAsync();

            return _mapper.Map<IEnumerable<ArtistVm>>(artists);
        }
    }

}
