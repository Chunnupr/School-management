using SchoolManagementSystem.Core.Models;

namespace SchoolManagementSystem.Core.Interfaces
{
    public interface IUserService
    {
        Task<User> GetUserByIdAsync(int id);
        Task<User> GetUserByUsernameAsync(string username);
        Task<User> CreateUserAsync(User user, string password);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(int id);
        Task<bool> IsUserInRoleAsync(int userId, Role role);
    }
}
