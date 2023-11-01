using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Application.UserAccounts.Vms;
using YourChordsAPIApp.Domain.Repositories;

namespace YourChordsAPIApp.Application.UserAccounts.Queries.GetUserAccountByEmail
{
    public class GetUserAccountByEmailQueryHandler : IRequestHandler<GetUserAccountByEmailQuery, UserAccountVm>
    {
        private readonly IUserAccountRepository _userAccountRepository;
        private readonly IMapper _mapper;

        public GetUserAccountByEmailQueryHandler(IUserAccountRepository userAccountRepository, IMapper mapper)
        {
            _userAccountRepository = userAccountRepository;
            _mapper = mapper;
        }

        public async Task<UserAccountVm> Handle(GetUserAccountByEmailQuery request, CancellationToken cancellationToken)
        {
            var userAccount = await _userAccountRepository.GetUserAccountByEmailAsync(request.Email);
            return _mapper.Map<UserAccountVm>(userAccount);
        }
    }

}
