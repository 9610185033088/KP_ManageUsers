using KP_ManageUsers.Shared;
using Microsoft.EntityFrameworkCore;

namespace KP_ManageUsers.Server
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        //protected override async void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    await DataSeeder.SeedData(this);
        //}

        public DbSet<User> Users { get; set; }
        public DbSet<AccessGroup> AccessGroups { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }
    }
}
