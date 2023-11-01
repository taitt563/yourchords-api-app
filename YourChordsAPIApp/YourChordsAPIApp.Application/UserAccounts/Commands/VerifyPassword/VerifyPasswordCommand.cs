using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Domain.Entities;

namespace YourChordsAPIApp.Application.UserAccounts.Commands.VerifyPassword
{
    public class VerifyPasswordCommand : IRequest<bool>
    {
        public UserAccount UserAccount { get; set; }
        public string Password { get; set; }
    }

}
