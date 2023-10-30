using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Domain.Entities;
using YourChordsAPIApp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace YourChordsAPIApp.Infrastructure.Repositories
{
    public class UserRoleRepository : IUserRoleRepository
    {
        private readonly YourChordsApiAppVer2DbContext _context;

        public UserRoleRepository(YourChordsApiAppVer2DbContext context) 
        {
            _context = context;
        }
        public async Task<UserRole> CreateAsync(UserRole role)
        {
            await _context.UserRoles.AddAsync(role);
            await _context.SaveChangesAsync();
            return role;
        }

        public async Task<int> DeleteAsync(int id)
        {
            var role = await _context.UserRoles.FirstOrDefaultAsync(model => model.Id == id);

            if (role != null)
            {
                _context.UserRoles.Remove(role);
                await _context.SaveChangesAsync();
                return 1; 
            }

            return 0;
        }

        public async Task<List<UserRole>> GetAllBlogAsync()
        {
            return await _context.UserRoles.ToListAsync();
        }

        public async Task<UserRole> GetByIdAsync(int id)
        {
            return await _context.UserRoles!.FindAsync(id);
        }

        public async Task<int> UpdateAsync(int id, UserRole role)
        {
            var existingRole = await _context.UserRoles.FirstOrDefaultAsync(r => r.Id == id);

            if (existingRole != null)
            {
                existingRole.RoleName = role.RoleName;
                existingRole.Description = role.Description;

                await _context.SaveChangesAsync();

                return 1; 
            }

            return 0;

        }
    }
}
