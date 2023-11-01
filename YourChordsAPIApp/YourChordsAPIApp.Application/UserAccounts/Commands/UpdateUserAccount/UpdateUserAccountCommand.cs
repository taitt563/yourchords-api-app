using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Application.UserAccounts.Queries;

namespace YourChordsAPIApp.Application.UserAccounts.Commands.UpdateUserAccount
{
    public class UpdateUserAccountCommand : IRequest<bool>
    {
        public UserAccountVm UserAccount { get; set; }
    }

}
