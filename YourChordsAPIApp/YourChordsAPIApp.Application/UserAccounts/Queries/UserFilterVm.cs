using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Application.Common.Mappings;
using YourChordsAPIApp.Domain.Common;

namespace YourChordsAPIApp.Application.UserAccounts.Queries
{
    public class UserFilterVm : IMapFrom<UserFilter>
    {
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public bool? IsDeleted { get; set; }
        public bool? IsPrivate { get; set; }
        public bool? IsVerified { get; set; }
        public int? RoleId { get; set; }
    }

}
