using System.Threading.Tasks;

namespace SchoolManagementSystem.Core.Interfaces
{
    public interface IAiAssistantService
    {
        Task<string> GetContextualHelpAsync(string context);
    }
}
