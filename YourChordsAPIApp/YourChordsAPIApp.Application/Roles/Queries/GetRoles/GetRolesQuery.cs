using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourChordsAPIApp.Application.Roles.Queries.GetRoles
{
    public class GetRolesQuery : IRequest<List<RolesVm>>
    {
    }

    //public record GetRolesQuery : IRequest<List<RolesVm>>
    //{
    //}

}