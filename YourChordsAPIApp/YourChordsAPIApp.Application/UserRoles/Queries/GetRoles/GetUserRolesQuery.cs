using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourChordsAPIApp.Application.UserRoles.Queries.GetRoles
{
    public class GetUserRolesQuery : IRequest<List<UserRoleVm>>
    {
    }

    //public record GetRolesQuery : IRequest<List<RolesVm>>
    //{
    //}

}