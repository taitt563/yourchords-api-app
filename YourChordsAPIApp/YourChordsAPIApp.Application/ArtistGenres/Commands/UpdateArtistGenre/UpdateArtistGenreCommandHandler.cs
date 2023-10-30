using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Application.ArtistGenres.Queries.GetAllArtistGenres;
using YourChordsAPIApp.Domain.Repositories;

namespace YourChordsAPIApp.Application.ArtistGenres.Commands.UpdateArtistGenre
{
    public class UpdateArtistGenreCommandHandler : IRequestHandler<UpdateArtistGenreCommand, ArtistGenreVm>
    {
        private readonly IArtistGenreRepository _artistGenreRepository;
        private readonly IMapper _mapper;

        public UpdateArtistGenreCommandHandler(IArtistGenreRepository artistGenreRepository, IMapper mapper)
        {
            _artistGenreRepository = artistGenreRepository;
            _mapper = mapper;
        }

        public async Task<ArtistGenreVm> Handle(UpdateArtistGenreCommand request, CancellationToken cancellationToken)
        {
            var existingArtistGenre = await _artistGenreRepository.GetArtistGenreByIdAsync(request.ArtistGenreId);

            if (existingArtistGenre == null)
            {
                // Handle the case where the ArtistGenre with the provided ID is not found
                // You can throw an exception or return an appropriate response
            }

            existingArtistGenre.ArtistId = request.ArtistId;
            existingArtistGenre.GenreId = request.GenreId;

            await _artistGenreRepository.UpdateArtistGenreAsync(existingArtistGenre);

            return _mapper.Map<ArtistGenreVm>(existingArtistGenre);
        }
    }

}
