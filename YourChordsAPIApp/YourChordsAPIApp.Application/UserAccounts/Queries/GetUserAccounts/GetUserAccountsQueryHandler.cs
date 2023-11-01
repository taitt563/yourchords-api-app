using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Application.UserAccounts.Vms;
using YourChordsAPIApp.Domain.Repositories;

namespace YourChordsAPIApp.Application.UserAccounts.Queries.GetUserAccounts
{
    public class GetUserAccountsQueryHandler : IRequestHandler<GetUserAccountsQuery, IEnumerable<UserAccountVm>>
    {
        private readonly IUserAccountRepository _userAccountRepository;
        private readonly IMapper _mapper;

        public GetUserAccountsQueryHandler(IUserAccountRepository userAccountRepository, IMapper mapper)
        {
            _userAccountRepository = userAccountRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserAccountVm>> Handle(GetUserAccountsQuery request, CancellationToken cancellationToken)
        {
            var userAccounts = await _userAccountRepository.GetUserAccountsAsync(request.Page, request.PageSize, request.Filter);
            return _mapper.Map<IEnumerable<UserAccountVm>>(userAccounts);
        }
    }

}
