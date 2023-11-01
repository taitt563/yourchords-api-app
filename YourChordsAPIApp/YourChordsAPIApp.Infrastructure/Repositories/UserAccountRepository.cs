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
using YourChordsAPIApp.Application.UserAccounts.Vms;
using YourChordsAPIApp.Domain.Common;
using YourChordsAPIApp.Domain.Entities;
using YourChordsAPIApp.Domain.Enums;
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

        public async Task<UserAccount> RegisterAsync(string email, string password, string confirmPassword)
        {
            var existingUser = await _context.UserAccounts.SingleOrDefaultAsync(u => u.Email == email);

            if (existingUser != null)
            {
                throw new Exception("Email already exists.");
            }
            var userAccount = new UserAccount
            {
                Email = email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(password),
                DateJoined = DateTime.Now,
                IsVerified = false,
                IsPrivate = false,
                IsDeleted = false,
                Role = UserRole.Customer.ToString() // Set default role here
            };

            _context.UserAccounts.Add(userAccount);
            await _context.SaveChangesAsync();
            return userAccount;
        }

        public async Task<UserAccount> LoginAsync(string email, string password)
        {
            try
            {
                var userAccount = await GetUserAccountByEmailAsync(email);

                if (userAccount == null || !BCrypt.Net.BCrypt.Verify(password, userAccount.PasswordHash))
                {
                    throw new Exception("Invalid email or password.");
                }

                var token = await GenerateTokenAsync(userAccount);

                userAccount.Token = token;
                
                await _context.SaveChangesAsync();

                return userAccount;
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ (ví dụ: ghi log, đưa ra thông báo, ...)
                throw new Exception("An error occurred while logging in.", ex);
            }
        }


        public async Task<bool> ChangePasswordAsync(int userId, string currentPassword, string newPassword)
        {
            var userAccount = await GetUserAccountByIdAsync(userId);

            if (userAccount == null)
            {
                throw new Exception("User not found.");
            }

            if (!BCrypt.Net.BCrypt.Verify(currentPassword, userAccount.PasswordHash))
            {
                throw new Exception("Invalid current password.");
            }

            userAccount.PasswordHash = BCrypt.Net.BCrypt.HashPassword(newPassword);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateProfileAsync(int userId, string firstName, string lastName, string bio, DateTime? dob, string phoneNumber, bool? gender, string image)
        {
            var userAccount = await _context.UserAccounts.FindAsync(userId);

            if (userAccount == null)
            {
                throw new Exception("User not found.");
            }

            userAccount.FirstName = firstName;
            userAccount.LastName = lastName;
            userAccount.Bio = bio;
            userAccount.Dob = dob;
            userAccount.PhoneNumber = phoneNumber;
            userAccount.Gender = gender;
            userAccount.Image = image;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> VerifyEmailAsync(int userId)
        {
            var userAccount = await _context.UserAccounts.FindAsync(userId);

            if (userAccount == null)
            {
                throw new Exception("User not found.");
            }

            userAccount.IsVerified = true;
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> SetPrivateStatusAsync(int userId, bool isPrivate)
        {
            var userAccount = await GetUserAccountByIdAsync(userId);

            if (userAccount == null)
            {
                throw new Exception("User not found.");
            }

            userAccount.IsPrivate = isPrivate;
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAccountAsync(int userId)
        {
            var userAccount = await GetUserAccountByIdAsync(userId);

            if (userAccount == null)
            {
                throw new Exception("User not found.");
            }

            userAccount.IsDeleted = true;
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateUserRoleAsync(int userId, UserRole newRole)
        {
            var userAccount = await GetUserAccountByIdAsync(userId);

            if (userAccount == null)
            {
                throw new Exception("User not found.");
            }

            userAccount.Role = newRole.ToString();
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<UserAccount> GetUserAccountByIdAsync(int userId)
        {
            try
            {
                var userAccount = await _context.UserAccounts.FindAsync(userId);
                return userAccount;
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ (ví dụ: ghi log, đưa ra thông báo, ...)
                throw new Exception("An error occurred while getting user account by ID.", ex);
            }
        }


        public async Task<UserAccount> GetUserAccountByEmailAsync(string email)
        {
            try
            {
                var userAccount = await _context.UserAccounts.SingleOrDefaultAsync(u => u.Email == email);
                return userAccount;
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ (ví dụ: ghi log, đưa ra thông báo, ...)
                throw new Exception("An error occurred while getting user account by email.", ex);
            }
        }


        public async Task<IEnumerable<UserAccount>> GetUserAccountsAsync(int page, int pageSize, UserFilter filter)
        {
            try
            {
                var query = _context.UserAccounts.AsQueryable();

                if (!string.IsNullOrEmpty(filter.Email))
                {
                    query = query.Where(u => u.Email.Contains(filter.Email));
                }

                if (filter.IsVerified.HasValue)
                {
                    query = query.Where(u => u.IsVerified == filter.IsVerified);
                }

                if (filter.IsPrivate.HasValue)
                {
                    query = query.Where(u => u.IsPrivate == filter.IsPrivate);
                }

                if (filter.IsDeleted.HasValue)
                {
                    query = query.Where(u => u.IsDeleted == filter.IsDeleted);
                }

                if (!string.IsNullOrEmpty(filter.Role))
                {
                    query = query.Where(u => u.Role == filter.Role);
                }   
                // Thêm các điều kiện lọc khác tùy theo yêu cầu

                return await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ (ví dụ: ghi log, đưa ra thông báo, ...)
                throw new Exception("An error occurred while getting user accounts.", ex);
            }
        }


        public async Task<int> GetUserAccountsCountAsync(UserFilter filter)
        {
            try
            {
                var query = _context.UserAccounts.AsQueryable();

                if (!string.IsNullOrEmpty(filter.Email))
                {
                    query = query.Where(u => u.Email.Contains(filter.Email));
                }

                if (!string.IsNullOrEmpty(filter.Role))
                {
                    query = query.Where(u => u.Role.Contains(filter.Role));
                }
                return await query.CountAsync();
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ (ví dụ: ghi log, đưa ra thông báo, ...)
                throw new Exception("An error occurred while getting user accounts count.", ex);
            }
        }


        public async Task<bool> VerifyPasswordAsync(UserAccount userAccount, string password)
        {
            try
            {
                if (userAccount == null)
                {
                    throw new ArgumentNullException(nameof(userAccount), "User account cannot be null.");
                }

                if (string.IsNullOrWhiteSpace(password))
                {
                    throw new ArgumentException("Password cannot be null or empty.", nameof(password));
                }

                // Thực hiện việc xác thực mật khẩu ở đây
                bool isPasswordValid = BCrypt.Net.BCrypt.Verify(password, userAccount.PasswordHash);
                return isPasswordValid;
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ (ví dụ: ghi log, đưa ra thông báo, ...)
                throw new Exception("An error occurred while verifying the password.", ex);
            }
        }


        public async Task<string> GenerateTokenAsync(UserAccount userAccount)
        {
            try
            {
                if (userAccount == null)
                {
                    throw new ArgumentNullException(nameof(userAccount), "User account cannot be null.");
                }

                // Thực hiện việc tạo token ở đây
                var jwtSettings = _configuration.GetSection("JwtSettings");
                var secretKey = jwtSettings.GetValue<string>("SecretKey");
                //var issuer = jwtSettings.GetValue<string>("Issuer");
                //var audience = jwtSettings.GetValue<string>("Audience");

                var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, userAccount.Id.ToString()),
            new Claim(ClaimTypes.Email, userAccount.Email),
            new Claim(ClaimTypes.Role, userAccount.Role)
            // Thêm các claims khác nếu cần
        };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
                var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var expiration = DateTime.UtcNow.AddDays(1); // Thời hạn của token

                var token = new JwtSecurityToken(
                    //issuer: issuer,
                    //audience: audience,
                    claims: claims,
                    expires: expiration,
                    signingCredentials: credentials
                );

                var tokenHandler = new JwtSecurityTokenHandler();
                string tokenString = tokenHandler.WriteToken(token);

                return tokenString;
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ (ví dụ: ghi log, đưa ra thông báo, ...)
                throw new Exception("An error occurred while generating the token.", ex);
            }
        }


        public async Task<bool> IsEmailUniqueAsync(string email)
        {
            try
            {
                if (string.IsNullOrEmpty(email))
                {
                    throw new ArgumentNullException(nameof(email), "Email cannot be null or empty.");
                }

                // Thực hiện kiểm tra tính duy nhất của email ở đây
                var isUnique = await _context.UserAccounts.AllAsync(u => u.Email != email);

                return isUnique;
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ (ví dụ: ghi log, đưa ra thông báo, ...)
                throw new Exception("An error occurred while checking email uniqueness.", ex);
            }
        }


        //    public async Task<string> GenerateJwtToken(UserAccount userAccount)
        //    {
        //        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:SecretKey"]));
        //        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        //        var claims = new[]
        //        {
        //    new Claim(ClaimTypes.Email, userAccount.Email),
        //    new Claim(ClaimTypes.Role, userAccount.Role) // Assuming userAccount contains Role information
        //    // Add more claims as needed
        //};

        //        var token = new JwtSecurityToken(
        //            issuer: _configuration["JwtSettings:ValidIssuer"],
        //            audience: _configuration["JwtSettings:ValidAudience"],
        //            claims: claims,
        //            expires: DateTime.UtcNow.AddMinutes(30), // Set the expiration time as needed
        //            signingCredentials: credentials
        //        );

        //        return new JwtSecurityTokenHandler().WriteToken(token);
        //    }
    }

}
