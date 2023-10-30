using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourChordsAPIApp.Application.ChordTypes.Commands.CreateChordType
{
    public class CreateChordTypeCommandValidator : AbstractValidator<CreateChordTypeCommand>
    {
        public CreateChordTypeCommandValidator()
        {
            RuleFor(x => x.TypeName).NotEmpty().MaximumLength(50);
        }
    }
}
