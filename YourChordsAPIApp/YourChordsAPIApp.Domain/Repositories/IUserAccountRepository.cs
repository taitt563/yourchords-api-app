using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Domain.Common;
using YourChordsAPIApp.Domain.Entities;
using YourChordsAPIApp.Domain.Enums;

namespace YourChordsAPIApp.Domain.Repositories
{
    public interface IUserAccountRepository
    {
        Task<UserAccount> RegisterAsync(string email, string password, string confirmPassword);
        Task<UserAccount> LoginAsync(string email, string password);
        Task<bool> ChangePasswordAsync(int userId, string currentPassword, string newPassword);
        Task<bool> UpdateProfileAsync(int userId, string firstName, string lastName, string bio, DateTime? dob, string phoneNumber, bool? gender, string image);
        Task<bool> VerifyEmailAsync(int userId);
        Task<bool> SetPrivateStatusAsync(int userId, bool isPrivate);
        Task<bool> DeleteAccountAsync(int userId);
        Task<bool> UpdateUserRoleAsync(int userId, UserRole newRole);
        Task<UserAccount> GetUserAccountByIdAsync(int userId);
        Task<UserAccount> GetUserAccountByEmailAsync(string email);
        Task<IEnumerable<UserAccount>> GetUserAccountsAsync(int page, int pageSize, UserFilter filter);
        Task<int> GetUserAccountsCountAsync(UserFilter filter);
        Task<bool> VerifyPasswordAsync(UserAccount userAccount, string password);
        Task<string> GenerateTokenAsync(UserAccount userAccount);
        Task<bool> IsEmailUniqueAsync(string email);
    }
}
