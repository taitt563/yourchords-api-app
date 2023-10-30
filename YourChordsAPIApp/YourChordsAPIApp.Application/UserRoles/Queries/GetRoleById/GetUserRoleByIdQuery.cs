using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Application.UserRoles.Queries.GetRoles;

namespace YourChordsAPIApp.Application.UserRoles.Queries.GetRoleById
{
    public class GetUserRoleByIdQuery : IRequest<UserRoleVm>
    {
        public int RoleId {  get; set; }

    }
}
