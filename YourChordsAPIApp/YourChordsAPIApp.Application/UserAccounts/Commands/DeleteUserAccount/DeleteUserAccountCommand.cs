using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourChordsAPIApp.Application.UserAccounts.Commands.DeleteUserAccount
{
    public class DeleteUserAccountCommand : IRequest<bool>
    {
        public int UserId { get; set; }
    }

}
