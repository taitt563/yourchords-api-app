using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Application.ArtistGenres.Queries.GetAllArtistGenres;
using YourChordsAPIApp.Domain.Repositories;

namespace YourChordsAPIApp.Application.ArtistGenres.Queries.GetArtistGenreByArtistId
{
    public class GetArtistGenresByArtistIdQueryHandler : IRequestHandler<GetArtistGenresByArtistIdQuery, IEnumerable<ArtistGenreVm>>
    {
        private readonly IArtistGenreRepository _artistGenreRepository;
        private readonly IMapper _mapper;

        public GetArtistGenresByArtistIdQueryHandler(IArtistGenreRepository artistGenreRepository, IMapper mapper)
        {
            _artistGenreRepository = artistGenreRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ArtistGenreVm>> Handle(GetArtistGenresByArtistIdQuery request, CancellationToken cancellationToken)
        {
            var artistGenres = await _artistGenreRepository.GetArtistGenresByArtistIdAsync(request.ArtistId);

            return _mapper.Map<IEnumerable<ArtistGenreVm>>(artistGenres);
        }
    }

}
