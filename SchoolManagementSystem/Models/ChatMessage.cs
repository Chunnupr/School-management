namespace SchoolManagementSystem.Models
{
    public class ChatMessage
    {
        public string Text { get; set; }
        public bool IsFromUser { get; set; }
        public HorizontalOptions Alignment => IsFromUser ? HorizontalOptions.End : HorizontalOptions.Start;
        public Color Background => IsFromUser ? Color.FromRgb(0, 122, 255) : Color.FromRgb(230, 230, 230);
        public Color TextColor => IsFromUser ? Colors.White : Colors.Black;
    }
}
