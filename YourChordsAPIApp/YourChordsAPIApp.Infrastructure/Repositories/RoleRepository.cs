using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Domain.Entities;
using YourChordsAPIApp.Domain.Repositories;
using YourChordsAPIApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace YourChordsAPIApp.Infrastructure.Repositories
{
    public class RoleRepository : IRolesRepository
    {
        private readonly Data.yourchordsdbContext _context;

        public RoleRepository(Data.yourchordsdbContext context) 
        {
            _context = context;
        }
        public async Task<Role> CreateAsync(Role role)
        {
            await _context.Roles.AddAsync(role);
            await _context.SaveChangesAsync();
            return role;
        }

        public async Task<int> DeleteAsync(int id)
        {
            var role = await _context.Roles.FirstOrDefaultAsync(model => model.Id == id);

            if (role != null)
            {
                _context.Roles.Remove(role);
                await _context.SaveChangesAsync();
                return 1; 
            }

            return 0;
        }

        public async Task<List<Role>> GetAllBlogAsync()
        {
            return await _context.Roles.ToListAsync();
        }

        public async Task<Role> GetByIdAsync(int id)
        {
            return await _context.Roles!.FindAsync(id);
        }

        public async Task<int> UpdateAsync(int id, Role role)
        {
            var existingRole = await _context.Roles.FirstOrDefaultAsync(r => r.Id == id);

            if (existingRole != null)
            {
                existingRole.Name = role.Name;
                existingRole.Description = role.Description;

                await _context.SaveChangesAsync();

                return 1; 
            }

            return 0;

        }
    }
}
