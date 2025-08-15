using CustomChatbot.Interfaces;
using CustomChatbot.Models;
using Microsoft.AspNetCore.Mvc;
using CustomChatbot.Helpers;

namespace CustomChatbot.Controllers
{
    public class ChatBotController : Controller
    {
        private readonly IChatBotService _chatBotService;
        private const string ChatSessionKey = "ChatHistory";

        public ChatBotController(IChatBotService chatBotService)
        {
            _chatBotService = chatBotService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var chatHistory = HttpContext.Session.GetObjectFromJson<List<ChatMessage>>(ChatSessionKey) ?? new List<ChatMessage>();
            return View(new ChatBotModel { ChatHistory = chatHistory });
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(string userMessage)
        {
            var chatHistory = HttpContext.Session.GetObjectFromJson<List<ChatMessage>>("ChatHistory") ?? new List<ChatMessage>();

            chatHistory.Add(new ChatMessage { Message = userMessage, IsUser = true });
            var botReply = await _chatBotService.AskBotAsync(userMessage);
            chatHistory.Add(new ChatMessage { Message = botReply, IsUser = false });

            HttpContext.Session.SetObjectAsJson("ChatHistory", chatHistory);

            return Content(botReply);
        }
    }
}
