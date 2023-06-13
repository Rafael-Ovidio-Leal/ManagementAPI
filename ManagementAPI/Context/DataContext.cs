using ManagementAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ManagementAPI.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Area> Area { get; set; }
        public DbSet<Process> Process { get; set; }
        public DbSet<Subprocess> Subprocess { get; set; }

    }
}
