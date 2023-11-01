using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Domain.Repositories;

namespace YourChordsAPIApp.Application.UserAccounts.Queries.GetUserAccounts
{
    public class GetUserAccountsQueryHandler : IRequestHandler<GetUserAccountsQuery, IEnumerable<UserAccountVm>>
    {
        private readonly IUserAccountRepository _userAccountRepository;

        public GetUserAccountsQueryHandler(IUserAccountRepository userAccountRepository)
        {
            _userAccountRepository = userAccountRepository;
        }

        public async Task<IEnumerable<UserAccountVm>> Handle(GetUserAccountsQuery request, CancellationToken cancellationToken)
        {
            var userAccounts = await _userAccountRepository.GetUserAccountsAsync(request.Page, request.PageSize, request.Filter);

            return userAccounts.Select(userAccount => new UserAccountVm
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
            });
        }
    }

}
