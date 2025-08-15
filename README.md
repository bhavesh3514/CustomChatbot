# CustomChatbot

A personal AI-powered chatbot built for interactive and intelligent conversations. Developed and maintained by [Your Name].

---

## Demo

💬 Try asking anything! Chatbot responds intelligently using the Mistral model via OpenRouter API.

---

## Features

- AI-powered responses using Mistral-7B Instruct model.
- Real-time chat interface with typing indicator.
- Auto-resizing input box for smooth typing experience.
- Responsive design, works on desktop and mobile.
- Easy to extend for custom functionality.

---

## Screenshots

<img width="1920" height="871" alt="image" src="https://github.com/user-attachments/assets/c57627bd-59d3-4ca6-9645-99ce71f17be8" />

---

## Setup & Installation

### Prerequisites

- .NET 8 SDK
- Internet connection for API requests
- OpenRouter API Key (Sign up at https://openrouter.ai/)

### Steps

1. Clone the repository:

   git clone https://github.com/yourusername/CustomChatbot.git
   cd CustomChatbot

2. Configure API Key in appsettings.json:

   "OpenRouter": {
     "ApiUrl": "https://openrouter.ai/api/v1/chat/completions",
     "ApiKey": "YOUR_OPENROUTER_API_KEY",
     "Model": "mistralai/mistral-7b-instruct"
   }

   ⚠️ Do not commit your real API key to GitHub.

3. Alternatively, use .NET User Secrets for security:

   dotnet user-secrets set "OpenRouter:ApiKey" "your_real_api_key"

4. Run the application:

   dotnet run

5. Open your browser:

   https://localhost:5001

Start chatting with your AI chatbot!

---

## Usage

- Type a message in the input box and press Send.
- AI responses appear in real-time with typing indicator.
- Messages automatically wrap and adjust to content length.
- Send button disables while waiting for response to prevent multiple requests.

---

## Contributing

Feel free to fork the repo and create pull requests.  
Suggestions, bug reports, and feature requests are welcome!

---

## Acknowledgements

- OpenRouter for API access
- Mistral AI for the Mistral-7B model
- Bootstrap for responsive UI components
