using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourChordsAPIApp.Application.ArtistGenres.Commands.CreateArtistGenre
{
    public class CreateArtistGenreCommandValidator : AbstractValidator<CreateArtistGenreCommand>
    {
        public CreateArtistGenreCommandValidator()
        {
            RuleFor(x => x.ArtistId).NotEmpty();
            RuleFor(x => x.GenreId).NotEmpty();
        }
    }

}
