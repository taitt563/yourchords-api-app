using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Application.Roles.Queries.GetRoles;

namespace YourChordsAPIApp.Application.Roles.Commands.CreateRole
{
    public class CreateRoleCommand : IRequest<RolesVm>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
