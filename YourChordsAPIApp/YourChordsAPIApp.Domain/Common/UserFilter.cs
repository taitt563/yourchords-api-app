using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourChordsAPIApp.Domain.Common
{
    public class UserFilter
    {
        public string? Email { get; set; }
        public bool? IsDeleted { get; set; }
        public bool? IsPrivate { get; set; }
        public bool? IsVerified { get; set; }
        public string? Role { get; set; }
    }
}
