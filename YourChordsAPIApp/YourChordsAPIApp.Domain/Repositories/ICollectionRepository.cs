using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Domain.Entities;

namespace YourChordsAPIApp.Domain.Repositories
{
    public interface ICollectionRepository
    {
        Task<Collection> GetByIdAsync(int id);
        Task<IEnumerable<Collection>> GetAllAsync();
        Task<IEnumerable<Collection>> GetByUserIdAsync(int userId);
        Task<Collection> AddAsync(Collection collection);
        Task UpdateAsync(Collection collection);
        Task DeleteAsync(Collection collection);
        // Any additional operations specific to the Collection entity
    }
}
