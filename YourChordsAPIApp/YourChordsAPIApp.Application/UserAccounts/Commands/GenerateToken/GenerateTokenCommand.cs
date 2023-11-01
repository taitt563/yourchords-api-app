using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Domain.Entities;

namespace YourChordsAPIApp.Application.UserAccounts.Commands.GenerateToken
{
    public class GenerateTokenCommand : IRequest<string>
    {
        public UserAccount UserAccount { get; }

        public GenerateTokenCommand(UserAccount userAccount)
        {
            UserAccount = userAccount;
        }
    }

}
