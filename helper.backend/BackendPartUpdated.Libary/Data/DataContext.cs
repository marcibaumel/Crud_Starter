using BackendPartUpdated.DataManagment.Entities;
using Microsoft.EntityFrameworkCore;

namespace BackendPartUpdated.DataManagment.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<UserEntity> Users { get; set; }
    }
}
