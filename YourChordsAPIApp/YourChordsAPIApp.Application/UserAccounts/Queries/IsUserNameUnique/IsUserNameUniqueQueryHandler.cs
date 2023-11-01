using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Domain.Repositories;

namespace YourChordsAPIApp.Application.UserAccounts.Queries.IsUserNameUnique
{
    public class IsUserNameUniqueQueryHandler : IRequestHandler<IsUserNameUniqueQuery, bool>
    {
        private readonly IUserAccountRepository _userAccountRepository;

        public IsUserNameUniqueQueryHandler(IUserAccountRepository userAccountRepository)
        {
            _userAccountRepository = userAccountRepository;
        }

        public async Task<bool> Handle(IsUserNameUniqueQuery request, CancellationToken cancellationToken)
        {
            return await _userAccountRepository.IsUserNameUniqueAsync(request.UserName);
        }
    }

}
