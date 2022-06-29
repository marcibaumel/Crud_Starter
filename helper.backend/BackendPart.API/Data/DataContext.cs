using BackendPart.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace BackendPart.API.Data
{
    
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options): base(options) { }

        public DbSet<UserEntity> Users { get; set; }
    }
}
