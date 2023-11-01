using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourChordsAPIApp.Application.UserAccounts.Queries.GetUserAccountByUserName
{
    public class GetUserAccountByUserNameQueryValidator : AbstractValidator<GetUserAccountByUserNameQuery>
    {
        public GetUserAccountByUserNameQueryValidator()
        {
            RuleFor(x => x.UserName).NotEmpty();
        }
    }

}
