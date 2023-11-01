using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourChordsAPIApp.Application.UserAccounts.Queries.GetUserAccountById
{
    public class GetUserAccountByIdQuery : IRequest<UserAccountVm>
    {
        public int UserId { get; set; }
    }

}
