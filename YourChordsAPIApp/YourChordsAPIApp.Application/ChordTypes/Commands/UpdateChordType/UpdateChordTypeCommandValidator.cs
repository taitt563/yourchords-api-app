using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourChordsAPIApp.Application.ChordTypes.Commands.UpdateChordType
{
    public class UpdateChordTypeCommandValidator : AbstractValidator<UpdateChordTypeCommand>
    {
        public UpdateChordTypeCommandValidator()
        {
            RuleFor(x => x.TypeName).NotEmpty().MaximumLength(50);
        }
    }

}
