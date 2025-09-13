using System.Threading.Tasks;

namespace SchoolManagementSystem.Services
{
    public class AIService
    {
        public AIService()
        {
            // In a real app, you would initialize the Google AI client here
            // using the credentials.
        }

        public async Task<string> GetChatResponseAsync(string message)
        {
            // Simulate a network delay
            await Task.Delay(500);

            // Mocked responses based on the user's message
            if (message.ToLower().Contains("hello"))
            {
                return "Hello! How can I assist you with the school management system today?";
            }
            if (message.ToLower().Contains("pending fees"))
            {
                return "There are 25 students with pending fees. Would you like to see a list?";
            }
            if (message.ToLower().Contains("assign subjects"))
            {
                return "It looks like you haven't assigned subjects to Grade 10, Section B. Would you like to do that now?";
            }

            return "I'm sorry, I don't understand that yet. I am still in training. You can ask me about pending fees or how to assign subjects.";
        }
    }
}
