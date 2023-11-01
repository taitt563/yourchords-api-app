using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Application.UserAccounts.Vms;

namespace YourChordsAPIApp.Application.UserAccounts.Commands.LoginUser
{
    public class LoginUserCommand : IRequest<UserAccountVm>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
