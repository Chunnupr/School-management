using Google.GenerativeAI;
using SchoolManagementSystem.Core.Interfaces;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Core.Services
{
    public class AiAssistantService : IAiAssistantService
    {
        private readonly GenerativeModel _model;

        public AiAssistantService()
        {
            // IMPORTANT: Replace "YOUR_API_KEY" with your actual Google AI API key.
            var apiKey = "YOUR_API_KEY";
            _model = new GenerativeModel(apiKey, Model.Gemini15Flash);
        }

        public async Task<string> GetContextualHelpAsync(string context)
        {
            var prompt = $"Provide help for the following context in a school management system: {context}";
            var response = await _model.GenerateContentAsync(prompt);
            return response.Text;
        }
    }
}
