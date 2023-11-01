using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Domain.Common;
using YourChordsAPIApp.Domain.Entities;

namespace YourChordsAPIApp.Domain.Repositories
{
    public interface IUserAccountRepository
    {
        Task<UserAccount> GetUserAccountByIdAsync(int id);
        Task<UserAccount> GetUserAccountByEmailAsync(string email);
        Task<UserAccount> GetUserAccountByUserNameAsync(string userName);
        Task<IEnumerable<UserAccount>> GetUserAccountsAsync(int page, int pageSize, UserFilter filter);
        Task<int> GetUserAccountsCountAsync(UserFilter filter);
        Task<UserAccount> CreateUserAccountAsync(UserAccount userAccount);
        Task UpdateUserAccountAsync(UserAccount userAccount);
        Task DeleteUserAccountAsync(int id);

        Task<bool> VerifyPasswordAsync(UserAccount userAccount, string password);
        Task<string> GenerateTokenAsync(UserAccount userAccount);
        Task<bool> IsEmailUniqueAsync(string email);
        Task<bool> IsUserNameUniqueAsync(string userName);

        Task<UserAccount> SignInAsync(string email, string password);
        Task<UserAccount> SignUpAsync(string email, string password);
        Task<bool> ChangePasswordAsync(int userId, string oldPassword, string newPassword);
    }
}
