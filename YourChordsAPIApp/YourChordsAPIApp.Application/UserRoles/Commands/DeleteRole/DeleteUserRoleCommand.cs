using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourChordsAPIApp.Application.UserRoles.Commands.DeleteRole
{
    public class DeleteUserRoleCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
