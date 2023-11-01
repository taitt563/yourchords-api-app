using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourChordsAPIApp.Application.UserAccounts.Queries.VerifyPassword
{
    public class VerifyPasswordQuery : IRequest<bool>
    {
        public UserAccountVm UserAccount { get; set; }
    }

}
