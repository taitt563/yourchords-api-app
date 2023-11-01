using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourChordsAPIApp.Application.UserAccounts.Queries.IsUserNameUnique
{
    public class IsUserNameUniqueQuery : IRequest<bool>
    {
        public string UserName { get; set; }
    }

}
