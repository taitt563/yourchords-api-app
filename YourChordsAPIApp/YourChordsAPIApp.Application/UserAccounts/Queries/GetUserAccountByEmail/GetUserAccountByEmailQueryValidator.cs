using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourChordsAPIApp.Application.UserAccounts.Queries.GetUserAccountByEmail
{
    public class GetUserAccountByEmailQueryValidator : AbstractValidator<GetUserAccountByEmailQuery>
    {
        public GetUserAccountByEmailQueryValidator()
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
        }
    }

}
