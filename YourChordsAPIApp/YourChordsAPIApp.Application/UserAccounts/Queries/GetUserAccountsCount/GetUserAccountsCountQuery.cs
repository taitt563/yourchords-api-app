using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Domain.Common;

namespace YourChordsAPIApp.Application.UserAccounts.Queries.GetUserAccountsCount
{
    public class GetUserAccountsCountQuery : IRequest<int>
    {
        public UserFilter Filter { get; set; }
    }

}
