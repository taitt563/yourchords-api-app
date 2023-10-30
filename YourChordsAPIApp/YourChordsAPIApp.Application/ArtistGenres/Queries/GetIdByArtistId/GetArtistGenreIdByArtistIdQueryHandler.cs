using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Domain.Repositories;

namespace YourChordsAPIApp.Application.ArtistGenres.Queries.GetIdByArtistId
{
    public class GetArtistGenreIdsByArtistIdQueryHandler : IRequestHandler<GetArtistGenreIdsByArtistIdQuery, IEnumerable<int>>
    {
        private readonly IArtistGenreRepository _artistGenreRepository;

        public GetArtistGenreIdsByArtistIdQueryHandler(IArtistGenreRepository artistGenreRepository)
        {
            _artistGenreRepository = artistGenreRepository;
        }

        public async Task<IEnumerable<int>> Handle(GetArtistGenreIdsByArtistIdQuery request, CancellationToken cancellationToken)
        {
            return await _artistGenreRepository.GetArtistGenreIdsByArtistIdAsync(request.ArtistId);
        }
    }


}
