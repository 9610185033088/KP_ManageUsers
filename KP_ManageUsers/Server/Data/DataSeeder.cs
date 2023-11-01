using KP_ManageUsers.Shared;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Globalization;

namespace KP_ManageUsers.Server
{
    public static class DataSeeder
    {
        public static async Task SeedData(ApplicationDbContext context)
        {
            var accessGroupList = new List<AccessGroup>
            {
                new AccessGroup { Name = "Big Boss", Level = 1 },
                new AccessGroup { Name = "Admin", Level = 2 },
                new AccessGroup { Name = "Basic", Level = 3 },
            };

            foreach (AccessGroup item in accessGroupList)
            {
                if (!context.AccessGroups.Any(x => x.Name == item.Name))
                {
                    await context.AccessGroups.AddAsync(new AccessGroup { Name = item.Name, Level = item.Level });
                }
            }

            await context.SaveChangesAsync();
        }
    }
}
