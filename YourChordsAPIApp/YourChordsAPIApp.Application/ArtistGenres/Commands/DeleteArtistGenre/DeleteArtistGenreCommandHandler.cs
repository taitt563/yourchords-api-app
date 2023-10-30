using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Domain.Repositories;

namespace YourChordsAPIApp.Application.ArtistGenres.Commands.DeleteArtistGenre
{
    public class DeleteArtistGenreCommandHandler : IRequestHandler<DeleteArtistGenreCommand, Unit>
    {
        private readonly IArtistGenreRepository _artistGenreRepository;

        public DeleteArtistGenreCommandHandler(IArtistGenreRepository artistGenreRepository)
        {
            _artistGenreRepository = artistGenreRepository;
        }

        public async Task<Unit> Handle(DeleteArtistGenreCommand request, CancellationToken cancellationToken)
        {
            await _artistGenreRepository.DeleteArtistGenreAsync(request.ArtistGenreId);
            return Unit.Value;
        }
    }

}
