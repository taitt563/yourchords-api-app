using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Domain.Repositories;

namespace YourChordsAPIApp.Application.UserAccounts.Queries.GetUserAccountByUserName
{
    public class GetUserAccountByUserNameQueryHandler : IRequestHandler<GetUserAccountByUserNameQuery, UserAccountVm>
    {
        private readonly IUserAccountRepository _userAccountRepository;

        public GetUserAccountByUserNameQueryHandler(IUserAccountRepository userAccountRepository)
        {
            _userAccountRepository = userAccountRepository;
        }

        public async Task<UserAccountVm> Handle(GetUserAccountByUserNameQuery request, CancellationToken cancellationToken)
        {
            var userAccount = await _userAccountRepository.GetUserAccountByUserNameAsync(request.UserName);

            return userAccount != null ? new UserAccountVm
            {
                Id = userAccount.Id,
                UserName = userAccount.UserName,
                Email = userAccount.Email,
                Token = userAccount.Token,
                Bio = userAccount.Bio,
                Dob = (DateTime)userAccount.Dob,
                PhoneNumber = userAccount.PhoneNumber,
                Gender = (bool)userAccount.Gender,
                Image = userAccount.Image,
                DateJoined = (DateTime)userAccount.DateJoined,
                IsVerified = (bool)userAccount.IsVerified,
                IsPrivate = (bool)userAccount.IsPrivate,
                IsDeleted = (bool)userAccount.IsDeleted,
                Role = userAccount.Role
            } : null;
        }
    }

}
