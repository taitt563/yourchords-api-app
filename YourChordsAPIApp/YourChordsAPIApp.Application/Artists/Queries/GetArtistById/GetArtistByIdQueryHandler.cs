using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Application.Artists.Queries.GetArtists;
using YourChordsAPIApp.Domain.Repositories;

namespace YourChordsAPIApp.Application.Artists.Queries.GetArtistById
{
    public class GetArtistByIdQueryHandler : IRequestHandler<GetArtistByIdQuery, ArtistVm>
    {
        private readonly IArtistRepository _artistRepository;
        private readonly IMapper _mapper;

        public GetArtistByIdQueryHandler(IArtistRepository artistRepository, IMapper mapper)
        {
            _artistRepository = artistRepository;
            _mapper = mapper;
        }

        public async Task<ArtistVm> Handle(GetArtistByIdQuery request, CancellationToken cancellationToken)
        {
            var artist = await _artistRepository.GetArtistByIdAsync(request.ArtistId);

            return _mapper.Map<ArtistVm>(artist);
        }
    }

}
