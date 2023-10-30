using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Domain.Repositories;

namespace YourChordsAPIApp.Application.ArtistGenres.Queries.GetAllArtistGenres
{
    public class GetAllArtistGenresQueryHandler : IRequestHandler<GetAllArtistGenresQuery, IEnumerable<ArtistGenreVm>>
    {
        private readonly IArtistGenreRepository _artistGenreRepository;
        private readonly IMapper _mapper;

        public GetAllArtistGenresQueryHandler(IArtistGenreRepository artistGenreRepository, IMapper mapper)
        {
            _artistGenreRepository = artistGenreRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ArtistGenreVm>> Handle(GetAllArtistGenresQuery request, CancellationToken cancellationToken)
        {
            var artistGenres = await _artistGenreRepository.GetAllArtistGenresAsync();

            return _mapper.Map<IEnumerable<ArtistGenreVm>>(artistGenres);
        }
    }

}
