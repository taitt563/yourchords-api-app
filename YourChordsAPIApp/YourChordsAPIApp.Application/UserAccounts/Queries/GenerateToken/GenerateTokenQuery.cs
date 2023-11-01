using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourChordsAPIApp.Application.UserAccounts.Queries.GenerateToken
{
    public class GenerateTokenQuery : IRequest<string>
    {
        public UserAccountVm UserAccount { get; set; }
    }

}
