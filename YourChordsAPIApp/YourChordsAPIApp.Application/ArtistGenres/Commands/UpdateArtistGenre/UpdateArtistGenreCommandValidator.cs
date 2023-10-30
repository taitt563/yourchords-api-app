using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourChordsAPIApp.Application.ArtistGenres.Commands.UpdateArtistGenre
{
    public class UpdateArtistGenreCommandValidator : AbstractValidator<UpdateArtistGenreCommand>
    {
        public UpdateArtistGenreCommandValidator()
        {
            RuleFor(x => x.ArtistGenreId).NotEmpty();
            RuleFor(x => x.ArtistId).NotEmpty();
            RuleFor(x => x.GenreId).NotEmpty();
        }
    }

}
