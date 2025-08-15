namespace CustomChatbot.Interfaces
{
    public interface IChatBotService
    {
        Task<string> AskBotAsync(string message);
    }
}
