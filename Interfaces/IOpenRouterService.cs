namespace CustomChatbot.Interfaces
{
    public interface IOpenRouterService
    {
        Task<string> GetChatResponseAsync(string prompt);
    }
}
