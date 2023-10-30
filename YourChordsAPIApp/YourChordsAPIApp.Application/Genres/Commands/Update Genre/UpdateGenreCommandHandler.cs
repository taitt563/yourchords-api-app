using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Application.Genres.Queries.GetAllGenres;
using YourChordsAPIApp.Domain.Repositories;

namespace YourChordsAPIApp.Application.Genres.Commands.Update_Genre
{
    public class UpdateGenreCommandHandler : IRequestHandler<UpdateGenreCommand, GenreVm>
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;

        public UpdateGenreCommandHandler(IGenreRepository genreRepository, IMapper mapper)
        {
            _genreRepository = genreRepository;
            _mapper = mapper;
        }

        public async Task<GenreVm> Handle(UpdateGenreCommand request, CancellationToken cancellationToken)
        {
            var existingGenre = await _genreRepository.GetGenreByIdAsync(request.GenreId);

            if (existingGenre == null)
            {
                // Handle the case where the genre with the provided ID is not found
                // You can throw an exception or return an appropriate response
            }

            existingGenre.GenreName = request.GenreName;

            await _genreRepository.UpdateGenreAsync(existingGenre);

            return _mapper.Map<GenreVm>(existingGenre);
        }
    }

}
