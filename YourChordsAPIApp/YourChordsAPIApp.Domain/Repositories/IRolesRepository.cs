using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Domain.Entities;

namespace YourChordsAPIApp.Domain.Repositories
{
    public interface IRolesRepository
    {
        Task<List<Role>> GetAllBlogAsync();
        Task<Role> GetByIdAsync(int id);
        Task<Role> CreateAsync(Role role);
        Task<int> UpdateAsync(int id, Role role);
        Task<int> DeleteAsync(int id);

    }
}
