using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourChordsAPIApp.Application.ArtistGenres.Commands.DeleteArtistGenre
{
    public class DeleteArtistGenreCommandValidator : AbstractValidator<DeleteArtistGenreCommand>
    {
        public DeleteArtistGenreCommandValidator()
        {
            RuleFor(x => x.ArtistGenreId).NotEmpty();
        }
    }

}
