using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Domain.Repositories;

namespace YourChordsAPIApp.Application.UserAccounts.Queries.GetUserAccountsCount
{
    public class GetUserAccountsCountQueryHandler : IRequestHandler<GetUserAccountsCountQuery, int>
    {
        private readonly IUserAccountRepository _userAccountRepository;

        public GetUserAccountsCountQueryHandler(IUserAccountRepository userAccountRepository)
        {
            _userAccountRepository = userAccountRepository;
        }

        public async Task<int> Handle(GetUserAccountsCountQuery request, CancellationToken cancellationToken)
        {
            return await _userAccountRepository.GetUserAccountsCountAsync(request.Filter);
        }
    }

}
