using CustomChatbot.Configuration;
using CustomChatbot.Interfaces;
using CustomChatbot.Services;

var builder = WebApplication.CreateBuilder(args);

// Configure OpenRouter settings
builder.Services.Configure<OpenRouterConfiguration>(
    builder.Configuration.GetSection("OpenRouter")
);
builder.Services.AddScoped<IOpenRouterService, OpenRouterService>();
builder.Services.AddScoped<IChatBotService, ChatBotService>();

builder.Services.AddControllersWithViews();

// Add session services
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Session expires after 30 min
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Enable Session middleware (must be before Authorization)
app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=ChatBot}/{action=Index}/{id?}");

app.Run();
