using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Application.ArtistGenres.Queries.GetAllArtistGenres;
using YourChordsAPIApp.Domain.Repositories;

namespace YourChordsAPIApp.Application.ArtistGenres.Queries.GetArtistGenreById
{
    public class GetArtistGenreByIdQueryHandler : IRequestHandler<GetArtistGenreByIdQuery, ArtistGenreVm>
    {
        private readonly IArtistGenreRepository _artistGenreRepository;
        private readonly IMapper _mapper;

        public GetArtistGenreByIdQueryHandler(IArtistGenreRepository artistGenreRepository, IMapper mapper)
        {
            _artistGenreRepository = artistGenreRepository;
            _mapper = mapper;
        }

        public async Task<ArtistGenreVm> Handle(GetArtistGenreByIdQuery request, CancellationToken cancellationToken)
        {
            var artistGenre = await _artistGenreRepository.GetArtistGenreByIdAsync(request.ArtistGenreId);

            return _mapper.Map<ArtistGenreVm>(artistGenre);
        }
    }

}
