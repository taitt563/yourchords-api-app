using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Application.ArtistGenres.Queries.GetAllArtistGenres;
using YourChordsAPIApp.Domain.Repositories;

namespace YourChordsAPIApp.Application.ArtistGenres.Queries.GetArtistGenreByGenreId
{
    public class GetArtistGenresByGenreIdQueryHandler : IRequestHandler<GetArtistGenresByGenreIdQuery, IEnumerable<ArtistGenreVm>>
    {
        private readonly IArtistGenreRepository _artistGenreRepository;
        private readonly IMapper _mapper;

        public GetArtistGenresByGenreIdQueryHandler(IArtistGenreRepository artistGenreRepository, IMapper mapper)
        {
            _artistGenreRepository = artistGenreRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ArtistGenreVm>> Handle(GetArtistGenresByGenreIdQuery request, CancellationToken cancellationToken)
        {
            var artistGenres = await _artistGenreRepository.GetArtistGenresByGenreIdAsync(request.GenreId);

            return _mapper.Map<IEnumerable<ArtistGenreVm>>(artistGenres);
        }
    }

}
