using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Application.ArtistGenres.Queries.GetAllArtistGenres;
using YourChordsAPIApp.Domain.Entities;
using YourChordsAPIApp.Domain.Repositories;

namespace YourChordsAPIApp.Application.ArtistGenres.Commands.CreateArtistGenre
{
    public class CreateArtistGenreCommandHandler : IRequestHandler<CreateArtistGenreCommand, ArtistGenreVm>
    {
        private readonly IArtistGenreRepository _artistGenreRepository;
        private readonly IMapper _mapper;

        public CreateArtistGenreCommandHandler(IArtistGenreRepository artistGenreRepository, IMapper mapper)
        {
            _artistGenreRepository = artistGenreRepository;
            _mapper = mapper;
        }

        public async Task<ArtistGenreVm> Handle(CreateArtistGenreCommand request, CancellationToken cancellationToken)
        {
            var artistGenre = new ArtistGenre
            {
                ArtistId = request.ArtistId,
                GenreId = request.GenreId
            };

            await _artistGenreRepository.AddArtistGenreAsync(artistGenre);

            return _mapper.Map<ArtistGenreVm>(artistGenre);
        }
    }

}
