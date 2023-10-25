using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Application.Roles.Queries.GetRoles;

namespace YourChordsAPIApp.Application.Roles.Queries.GetRoleById
{
    public class GetRoleByIdQuery : IRequest<RolesVm>
    {
        public int RoleId {  get; set; }

    }
}
