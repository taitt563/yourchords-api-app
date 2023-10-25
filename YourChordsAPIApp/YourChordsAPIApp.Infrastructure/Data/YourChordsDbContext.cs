using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourChordsAPIApp.Domain.Entities;

namespace YourChordsAPIApp.Infrastructure.Data
{
    public class YourChordsDbContext : DbContext
    {
        public YourChordsDbContext(DbContextOptions<YourChordsDbContext> dbContextOptions) : base(dbContextOptions) 
        {
            
        }

        public DbSet<Role>? Role { get; set; }
    }
}
