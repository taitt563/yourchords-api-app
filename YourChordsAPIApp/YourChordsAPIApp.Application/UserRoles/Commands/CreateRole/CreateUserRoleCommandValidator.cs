﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Application.UserRoles.Commands.CreateRole;

namespace YourChordsAPIApp.Application.UserRoles.Commands.CreateRole
{
    internal class CreateUserRoleCommandValidator : AbstractValidator<CreateUserRoleCommand>
    {
        public CreateUserRoleCommandValidator() 
        {
            RuleFor(v => v.Name).NotEmpty().WithMessage("Name is required.").MaximumLength(50).WithMessage("Name must not exceed 50 characters");
            RuleFor(v => v.Description).NotEmpty().WithMessage("Name is required.");
        }
    }
}