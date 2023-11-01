using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourChordsAPIApp.Application.UserAccounts.Commands.SetPrivateStatus
{
    public class SetPrivateStatusCommand : IRequest<bool>
    {
        public int UserId { get; set; }
        public bool IsPrivate { get; set; }
    }
}
