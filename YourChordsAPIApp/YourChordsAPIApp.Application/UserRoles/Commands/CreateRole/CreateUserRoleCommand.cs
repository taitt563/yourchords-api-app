using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Application.UserRoles.Queries.GetRoles;

namespace YourChordsAPIApp.Application.UserRoles.Commands.CreateRole
{
    public class CreateUserRoleCommand : IRequest<UserRoleVm>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
