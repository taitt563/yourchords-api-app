using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourChordsAPIApp.Application.UserAccounts.Queries.GetUserAccountById
{
    public class GetUserAccountByIdQueryValidator : AbstractValidator<GetUserAccountByIdQuery>
    {
        public GetUserAccountByIdQueryValidator()
        {
            RuleFor(x => x.UserId).GreaterThan(0).WithMessage("UserId must be greater than 0");
        }
    }

}
