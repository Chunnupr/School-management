using SchoolManagementSystem.Models;
using System.Threading.Tasks;
using BCrypt.Net;
using System;

namespace SchoolManagementSystem.Services
{
    public class AuthenticationService
    {
        private readonly DatabaseService _dbService;

        public AuthenticationService(DatabaseService dbService)
        {
            _dbService = dbService;
            EnsureManagementUserExistsAsync().SafeFireAndForget(false);
        }

        public async Task<Tuple<User, string>> LoginAsync(string username, string password)
        {
            var conn = _dbService.GetConnection();
            var user = await conn.Table<User>().Where(u => u.Username == username).FirstOrDefaultAsync();

            if (user != null && BCrypt.Verify(password, user.PasswordHash))
            {
                var role = await conn.Table<Role>().Where(r => r.Id == user.RoleId).FirstOrDefaultAsync();
                return new Tuple<User, string>(user, role?.RoleName);
            }

            return null;
        }

        private async Task EnsureManagementUserExistsAsync()
        {
            var conn = _dbService.GetConnection();
            if (await conn.Table<User>().CountAsync() == 0)
            {
                var managementRole = await conn.Table<Role>().Where(r => r.RoleName == "Management").FirstOrDefaultAsync();
                if (managementRole != null)
                {
                    var managementUser = new User
                    {
                        Username = "management",
                        PasswordHash = BCrypt.HashPassword("password"),
                        RoleId = managementRole.Id
                    };
                    await conn.InsertAsync(managementUser);
                }
            }
        }
    }
}
