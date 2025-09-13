using SchoolManagementSystem.Models;
using SchoolManagementSystem.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace SchoolManagementSystem.ViewModels
{
    public class ChatPanelViewModel : BaseViewModel
    {
        private readonly AIService _aiService;
        private string _newMessageText;

        public ObservableCollection<ChatMessage> Messages { get; } = new();

        public string NewMessageText
        {
            get => _newMessageText;
            set
            {
                _newMessageText = value;
                OnPropertyChanged();
            }
        }

        public ICommand SendMessageCommand { get; }

        public ChatPanelViewModel(AIService aiService)
        {
            _aiService = aiService;
            SendMessageCommand = new Command(async () => await OnSendMessage());
        }

        private async Task OnSendMessage()
        {
            if (string.IsNullOrWhiteSpace(NewMessageText))
                return;

            var userMessage = new ChatMessage { Text = NewMessageText, IsFromUser = true };
            Messages.Add(userMessage);

            var aiResponseText = await _aiService.GetChatResponseAsync(NewMessageText);
            var aiMessage = new ChatMessage { Text = aiResponseText, IsFromUser = false };
            Messages.Add(aiMessage);

            NewMessageText = string.Empty;
        }
    }
}
