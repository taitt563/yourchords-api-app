using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Application.Roles.Commands.CreateRole;

namespace YourChordsAPIApp.Application.Role.Commands.CreateRole
{
    internal class CreateRoleCommandValidator : AbstractValidator<CreateRoleCommand>
    {
        public CreateRoleCommandValidator() 
        {
            RuleFor(v => v.Name).NotEmpty().WithMessage("Name is required.").MaximumLength(50).WithMessage("Name must not exceed 50 characters");
            RuleFor(v => v.Description).NotEmpty().WithMessage("Name is required.");
        }
    }
}
