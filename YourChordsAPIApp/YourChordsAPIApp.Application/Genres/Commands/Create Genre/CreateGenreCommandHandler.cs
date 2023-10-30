using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Application.Genres.Queries.GetAllGenres;
using YourChordsAPIApp.Domain.Entities;
using YourChordsAPIApp.Domain.Repositories;

namespace YourChordsAPIApp.Application.Genres.Commands.Create_Genre
{
    public class CreateGenreCommandHandler : IRequestHandler<CreateGenreCommand, GenreVm>
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;

        public CreateGenreCommandHandler(IGenreRepository genreRepository, IMapper mapper)
        {
            _genreRepository = genreRepository;
            _mapper = mapper;
        }

        public async Task<GenreVm> Handle(CreateGenreCommand request, CancellationToken cancellationToken)
        {
            var genre = new Genre
            {
                GenreName = request.GenreName
            };

            await _genreRepository.AddGenreAsync(genre);

            return _mapper.Map<GenreVm>(genre);
        }
    }

}
