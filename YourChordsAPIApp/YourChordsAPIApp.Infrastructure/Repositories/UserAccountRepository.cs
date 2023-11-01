using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Domain.Common;
using YourChordsAPIApp.Domain.Entities;
using YourChordsAPIApp.Domain.Repositories;

namespace YourChordsAPIApp.Infrastructure.Repositories
{
    public class UserAccountRepository : IUserAccountRepository
    {
        private readonly YourChordsDbContext _context;
        private readonly IConfiguration _configuration;

        public UserAccountRepository(YourChordsDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<UserAccount> GetUserAccountByIdAsync(int id)
        {
            return await _context.UserAccounts.FindAsync(id);
        }

        public async Task<UserAccount> GetUserAccountByEmailAsync(string email)
        {
            return await _context.UserAccounts.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<UserAccount> GetUserAccountByUserNameAsync(string userName)
        {
            return await _context.UserAccounts.FirstOrDefaultAsync(u => u.UserName == userName);
        }

        public async Task<IEnumerable<UserAccount>> GetUserAccountsAsync(int page, int pageSize, UserFilter filter)
        {
            var query = _context.UserAccounts.AsQueryable();

            if (!string.IsNullOrEmpty(filter.UserName))
            {
                query = query.Where(u => u.UserName.Contains(filter.UserName));
            }

            if (!string.IsNullOrEmpty(filter.Email))
            {
                query = query.Where(u => u.Email.Contains(filter.Email));
            }

            if (filter.IsDeleted.HasValue)
            {
                query = query.Where(u => u.IsDeleted == filter.IsDeleted.Value);
            }

            if (filter.IsPrivate.HasValue)
            {
                query = query.Where(u => u.IsPrivate == filter.IsPrivate.Value);
            }

            if (filter.IsVerified.HasValue)
            {
                query = query.Where(u => u.IsVerified == filter.IsVerified.Value);
            }

            if (!string.IsNullOrEmpty(filter.Role))
            {
                query = query.Where(u => u.Role.Contains(filter.Role));
            }

            return await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
        }


        public async Task<int> GetUserAccountsCountAsync(UserFilter filter)
        {
            var query = _context.UserAccounts.AsQueryable();

            if (!string.IsNullOrEmpty(filter.UserName))
            {
                query = query.Where(u => u.UserName.Contains(filter.UserName));
            }

            if (!string.IsNullOrEmpty(filter.Email))
            {
                query = query.Where(u => u.Email.Contains(filter.Email));
            }

            if (filter.IsDeleted.HasValue)
            {
                query = query.Where(u => u.IsDeleted == filter.IsDeleted.Value);
            }

            if (filter.IsPrivate.HasValue)
            {
                query = query.Where(u => u.IsPrivate == filter.IsPrivate.Value);
            }

            if (filter.IsVerified.HasValue)
            {
                query = query.Where(u => u.IsVerified == filter.IsVerified.Value);
            }

            if (!string.IsNullOrEmpty(filter.Role))
            {
                query = query.Where(u => u.Role.Contains(filter.Role));
            }

            return await query.CountAsync();
        }


        public async Task<UserAccount> CreateUserAccountAsync(UserAccount userAccount)
        {
            _context.UserAccounts.Add(userAccount);
            await _context.SaveChangesAsync();
            return userAccount;
        }

        public async Task UpdateUserAccountAsync(UserAccount userAccount)
        {
            _context.UserAccounts.Update(userAccount);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserAccountAsync(int id)
        {
            var userAccount = await _context.UserAccounts.FindAsync(id);
            if (userAccount != null)
            {
                _context.UserAccounts.Remove(userAccount);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> VerifyPasswordAsync(UserAccount userAccount, string password)
        {
            // Lấy hash mật khẩu từ cơ sở dữ liệu
            string hashedPasswordFromDatabase = userAccount.PasswordHash;

            // Xác thực mật khẩu
            return BCrypt.Net.BCrypt.Verify(password, hashedPasswordFromDatabase);
        }

        public async Task<string> GenerateTokenAsync(UserAccount userAccount)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
    {
        new Claim(ClaimTypes.Name, userAccount.UserName),
        new Claim(ClaimTypes.Email, userAccount.Email),
        new Claim(ClaimTypes.Role, userAccount.Role),
    };

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(1), // Thời gian hết hạn của token
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<bool> IsEmailUniqueAsync(string email)
        {
            return await _context.UserAccounts.AllAsync(u => u.Email != email);
        }

        public async Task<bool> IsUserNameUniqueAsync(string userName)
        {
            return await _context.UserAccounts.AllAsync(u => u.UserName != userName);
        }

        public async Task<UserAccount> SignInAsync(string email, string password)
        {
            // Tìm người dùng theo địa chỉ email
            var user = await _context.UserAccounts.SingleOrDefaultAsync(u => u.Email == email);

            // Kiểm tra người dùng có tồn tại và mật khẩu khớp hay không
            if (user != null && BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
            {
                return user;
            }

            return null;
        }


        public async Task<UserAccount> SignUpAsync(string email, string password)
        {
            try 
            {
                // Hash mật khẩu
                var passwordHash = BCrypt.Net.BCrypt.HashPassword(password);

                // Tạo một đối tượng UserAccount
                var newUserAccount = new UserAccount
                {
                    Email = email,
                    PasswordHash = passwordHash
                    
                };

                // Thêm userAccount vào cơ sở dữ liệu
                _context.UserAccounts.Add(newUserAccount);
                await _context.SaveChangesAsync();

                return newUserAccount;
            }
            catch (Exception ex)
            {
                var errorMessage = ex.InnerException?.Message;
                throw new Exception($"Error occurred while saving changes: {errorMessage}", ex);
            }
        }



        public async Task<bool> ChangePasswordAsync(int userId, string oldPassword, string newPassword)
        {
            // Lấy thông tin người dùng từ cơ sở dữ liệu
            var user = await _context.UserAccounts.FindAsync(userId);

            // Kiểm tra mật khẩu cũ
            if (BCrypt.Net.BCrypt.Verify(oldPassword, user.PasswordHash))
            {
                // Hash mật khẩu mới
                var newPasswordHash = BCrypt.Net.BCrypt.HashPassword(newPassword);

                // Cập nhật mật khẩu trong cơ sở dữ liệu
                user.PasswordHash = newPasswordHash;

                // Lưu thay đổi
                await _context.SaveChangesAsync();

                return true;
            }

            return false;
        }
    }

}
