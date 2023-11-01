using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourChordsAPIApp.Application.UserAccounts.Queries.IsEmailUnique
{
    public class IsEmailUniqueQuery : IRequest<bool>
    {
        public string Email { get; set; }
    }

}
