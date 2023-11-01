using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Application.UserAccounts.Vms;
using YourChordsAPIApp.Domain.Common;

namespace YourChordsAPIApp.Application.UserAccounts.Queries.GetUserAccounts
{
    public class GetUserAccountsQuery : IRequest<IEnumerable<UserAccountVm>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public UserFilter Filter { get; set; }
    }

}
