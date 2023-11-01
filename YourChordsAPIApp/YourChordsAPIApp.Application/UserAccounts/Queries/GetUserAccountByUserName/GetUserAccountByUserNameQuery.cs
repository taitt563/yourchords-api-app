using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourChordsAPIApp.Application.UserAccounts.Queries.GetUserAccountByUserName
{
    public class GetUserAccountByUserNameQuery : IRequest<UserAccountVm>
    {
        public string UserName { get; set; }
    }

}
