using KP_ManageUsers.Shared;

namespace KP_ManageUsers.Server
{
    public interface IManageUsersService
    {
        Task<List<AccessGroup>> GetAccessGroups();
        Task<List<UserGroup>> GetUserGroups();
        Task<List<User>> GetUsers();
        Task<ServerErrorDto> CreateUser(User model);
        Task<ServerErrorDto> CreateUserGroup(UserGroup model);
        Task<ServerErrorDto> UpdateUser(User model);
        Task<ServerErrorDto> UpdateUserGroup(UserGroup model);
        Task DeleteUser(int id);
        Task DeleteUserGroup(int id);
    }
}
