using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Application.Common.Mappings;
using YourChordsAPIApp.Domain.Entities;

namespace YourChordsAPIApp.Application.Roles.Queries.GetRoles
{
    public class RolesVm : IMapFrom<UserRole>
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }
    }
}
