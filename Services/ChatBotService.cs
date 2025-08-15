using CustomChatbot.Interfaces;

namespace CustomChatbot.Services
{
    public class ChatBotService : IChatBotService
    {
        private readonly IOpenRouterService _openRouterService;

        public ChatBotService(IOpenRouterService openRouterService)
        {
            _openRouterService = openRouterService;
        }

        public async Task<string> AskBotAsync(string message)
        {
            return await _openRouterService.GetChatResponseAsync(message);
        }
    }
}
