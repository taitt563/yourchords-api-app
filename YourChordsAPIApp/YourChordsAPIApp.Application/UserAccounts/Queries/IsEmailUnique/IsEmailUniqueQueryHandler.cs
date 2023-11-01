using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Domain.Repositories;

namespace YourChordsAPIApp.Application.UserAccounts.Queries.IsEmailUnique
{
    public class IsEmailUniqueQueryHandler : IRequestHandler<IsEmailUniqueQuery, bool>
    {
        private readonly IUserAccountRepository _userAccountRepository;

        public IsEmailUniqueQueryHandler(IUserAccountRepository userAccountRepository)
        {
            _userAccountRepository = userAccountRepository;
        }

        public async Task<bool> Handle(IsEmailUniqueQuery request, CancellationToken cancellationToken)
        {
            return await _userAccountRepository.IsEmailUniqueAsync(request.Email);
        }
    }

}
