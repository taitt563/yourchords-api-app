using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Application.Common.Mappings;
using YourChordsAPIApp.Domain.Entities;

namespace YourChordsAPIApp.Application.UserAccounts.Queries
{
    public class UserAccountVm : IMapFrom<UserAccount>
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; } = null!;
        public string? Token { get; set; }
        public string? Bio { get; set; }
        public DateTime? Dob { get; set; }
        public string? PhoneNumber { get; set; }
        public bool? Gender { get; set; }
        public string? Image { get; set; }
        public DateTime? DateJoined { get; set; }
        public bool? IsVerified { get; set; }
        public bool? IsPrivate { get; set; }
        public bool? IsDeleted { get; set; }
        public string Role { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<UserAccount, UserAccountVm>()
                .ForMember(dest => dest.Dob, opt => opt.MapFrom(src => src.Dob != null ? src.Dob.Value.ToString("yyyy-MM-dd") : null)
)
                .ForMember(dest => dest.DateJoined, opt => opt.MapFrom(src => DateTime.Today.ToString("yyyy-MM-dd")));
        }
    }
}
