using BackendPartUpdated.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace BackendPartUpdated.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<UserEntity> Users { get; set; }
    }
}
