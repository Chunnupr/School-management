using SQLite;
using SchoolManagementSystem.Models;
using System;
using System.IO;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Services
{
    public class DatabaseService
    {
        private const string DatabaseName = "School.db3";
        private const string DatabasePassword = "a_very_secret_password"; // This should be handled more securely

        private readonly Lazy<SQLiteAsyncConnection> _database;

        public DatabaseService()
        {
            var dbPath = Path.Combine(FileSystem.AppDataDirectory, DatabaseName);

            var connectionOptions = new SQLiteConnectionString(dbPath, true, key: DatabasePassword);

            _database = new Lazy<SQLiteAsyncConnection>(() => new SQLiteAsyncConnection(connectionOptions));

            InitAsync().SafeFireAndForget(false);
        }

        private async Task InitAsync()
        {
            await _database.Value.CreateTableAsync<SchoolInfo>();
            await _database.Value.CreateTableAsync<Role>();
            await _database.Value.CreateTableAsync<User>();
            await _database.Value.CreateTableAsync<LicenseInfo>();
            await _database.Value.CreateTableAsync<Student>();
            await _database.Value.CreateTableAsync<Class>();
            await _database.Value.CreateTableAsync<Section>();
            await _database.Value.CreateTableAsync<Subject>();
            await _database.Value.CreateTableAsync<FeeStructure>();
            await _database.Value.CreateTableAsync<FeePayment>();
            await _database.Value.CreateTableAsync<Invoice>();

            // Seed initial data
            await SeedRolesAsync();
        }

        private async Task SeedRolesAsync()
        {
            if (await _database.Value.Table<Role>().CountAsync() == 0)
            {
                var roles = new[]
                {
                    new Role { RoleName = "Management" },
                    new Role { RoleName = "Admin" },
                    new Role { RoleName = "Teacher" },
                    new Role { RoleName = "Cashier" }
                };
                await _database.Value.InsertAllAsync(roles);
            }
        }

        public SQLiteAsyncConnection GetConnection() => _database.Value;
    }

    // Helper to run async methods from constructor
    public static class TaskExtensions
    {
        public static void SafeFireAndForget(this Task task, bool returnToCallingContext, Action<Exception> onException = null)
        {
            task.ContinueWith(t =>
            {
                if (t.IsFaulted && onException != null)
                {
                    onException(t.Exception);
                }
            }, returnToCallingContext ? TaskScheduler.FromCurrentSynchronizationContext() : TaskScheduler.Default);
        }
    }
}
