using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourChordsAPIApp.Application.UserAccounts.Queries.GetUserAccounts
{
    public class GetUserAccountsQueryValidator : AbstractValidator<GetUserAccountsQuery>
    {
        public GetUserAccountsQueryValidator()
        {
            RuleFor(x => x.Page).GreaterThan(0).WithMessage("Page must be greater than 0");
            RuleFor(x => x.PageSize).GreaterThan(0).WithMessage("PageSize must be greater than 0");
        }
    }

}
