using KP_ManageUsers.Shared;
using Microsoft.EntityFrameworkCore;

namespace KP_ManageUsers.Server
{
    public class ManageUsersService : IManageUsersService
    {
        private readonly ApplicationDbContext context;

        public ManageUsersService(ApplicationDbContext _context)
        {
            context = _context;
        }

        public async Task<List<AccessGroup>> GetAccessGroups()
        {
            return await context.AccessGroups.AsNoTracking().ToListAsync();
        }
        
        public async Task<List<UserGroup>> GetUserGroups()
        {
            return await context.UserGroups
                .AsNoTracking()
                .Include(x => x.AccessGroup)
                .Include(x => x.User)
                .ToListAsync();
        }

        public async Task<List<User>> GetUsers()
        {
            return await context.Users.AsNoTracking().ToListAsync();
        }

        public async Task<ServerErrorDto> CreateUser(User model)
        {
            var response = new ServerErrorDto { Success = true, Error = "" };

            if (!context.Users.Any(r => r.Email == model.Email))
            {
                await context.Users.AddAsync(model);
                await context.SaveChangesAsync();
            }
            else
            {
                response.Success = false;
                response.Error = "The user already exist.";
            }

            return response;
        }

        public async Task<ServerErrorDto> CreateUserGroup(UserGroup model)
        {
            var response = new ServerErrorDto { Success = true, Error = "" };

            if (!context.UserGroups.Any(x => x.AccessGroupID == model.AccessGroupID && x.UserID == model.UserID))
            {
                await context.UserGroups.AddAsync(model);
                await context.SaveChangesAsync();
            }
            else
            {
                response.Success = false;
                response.Error = "The user already exists in this group";
            }

            return response;
        }

        public async Task<ServerErrorDto> UpdateUser(User model)
        {
            var response = new ServerErrorDto { Success = true, Error = "" };

            context.Entry(model).State = EntityState.Modified;

            await context.SaveChangesAsync();

            return response;
        }

        public async Task<ServerErrorDto> UpdateUserGroup(UserGroup model)
        {
            var response = new ServerErrorDto { Success = true, Error = "" };

            if (!context.UserGroups.Any(x => x.AccessGroupID == model.AccessGroupID && x.UserID == model.UserID))
            {
                context.Entry(model).State = EntityState.Modified;

                await context.SaveChangesAsync();
            }
            else
            {
                response.Success = false;
                response.Error = "The user already exists in this group";
            }

            return response;
        }

        public async Task DeleteUser(int id)
        {
            var existing = await context.Users.FindAsync(id);

            context.Users.Remove(existing);

            await context.SaveChangesAsync();
        }

        public async Task DeleteUserGroup(int id)
        {
            var existing = await context.UserGroups.FindAsync(id);

            context.UserGroups.Remove(existing);

            await context.SaveChangesAsync();
        }
    }
}
