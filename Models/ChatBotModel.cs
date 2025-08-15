namespace CustomChatbot.Models
{
    public class ChatMessage
    {
        public string Message { get; set; }
        public bool IsUser { get; set; }
    }

    public class ChatBotModel
    {
        public string? UserMessage { get; set; }
        public List<ChatMessage> ChatHistory { get; set; } = new List<ChatMessage>();
    }
}
