﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Application.UserAccounts.Vms;

namespace YourChordsAPIApp.Application.UserAccounts.Queries.GetUserAccountByEmail
{
    public class GetUserAccountByEmailQuery : IRequest<UserAccountVm>
    {
        public string Email { get; set; }
    }

}
