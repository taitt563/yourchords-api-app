using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Domain.Enums;

namespace YourChordsAPIApp.Application.UserAccounts.Commands.UpdateUserRole
{
    public class UpdateUserRoleCommand : IRequest<bool>
    {
        public int UserId { get; set; }
        public UserRole NewRole { get; set; }
    }
}
