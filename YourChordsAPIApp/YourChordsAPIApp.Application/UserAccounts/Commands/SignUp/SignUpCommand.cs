using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Application.UserAccounts.Queries;
using YourChordsAPIApp.Domain.Entities;

namespace YourChordsAPIApp.Application.UserAccounts.Commands.SignUp
{
    //public class SignUpCommand : IRequest<UserAccountVm>
    //{
    //    public UserAccountVm UserAccount { get; set; }
    //    public string Password { get; set; }
    //}
    public record SignUpCommand(string Email, string Password) : IRequest<UserAccountVm>;

}
