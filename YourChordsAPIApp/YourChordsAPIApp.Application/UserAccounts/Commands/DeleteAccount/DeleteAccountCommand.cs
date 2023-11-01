using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourChordsAPIApp.Application.UserAccounts.Commands.DeleteAccount
{
    public class DeleteAccountCommand : IRequest<bool>
    {
        public int UserId { get; set; }
    }
}
