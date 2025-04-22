using System;
using System.Collections.Generic;

//Name: ASCII Figgle App
//Author: fb-shaik
//Link: https://github.com/fb-shaik/PROG6221-Group2-2025/tree/main/ASCII_Figgle_App
//Date accessed: 15 April 2025

//Name: Create a bot with the Bot Framework SDK
//Author: Microsoft
//Link: https://learn.microsoft.com/en-us/azure/bot-service/bot-service-quickstart-create-bot?view=azure-bot-service-4.0&tabs=csharp%2Cvs
//Date accessed: 15 April 2025

//Name: 
//Author:
//Link:
//Date accessed:

//Name: 
//Author:
//Link:
//Date accessed:

//Name: 
//Author:
//Link:
//Date accessed:

namespace Chatbot
{
    public class ChatbotKnowledgeBase
    {
        // Dictionary questions
        protected Dictionary<string, string> Responses = new(StringComparer.OrdinalIgnoreCase)
        {
            { "how are you?", "I’m thriving in the matrix! Thanks for asking, human." },
            { "what is your purpose?", "To help South Africans stay protected from cyber threats like phishing and scams." },
            { "what can i ask you about?", "You can ask about password attacks, ransomware, phishing, safe browsing, social engineering." },
            { "password attack", "A password attack is any attempt by a malicious actor to gain unauthorized access by cracking passwords. Passwords should be like your toothbrush: long, unique, and never shared. 🪥" },
            { "phishing", "Phishing is when someone tricks you into revealing sensitive info using fake emails or messages. 🐟" },
            { "safe browsing", "Safe browsing means staying away from shady websites and always checking for HTTPS 🔒." },
            { "ransomware", "Ransomware locks your files and asks for money. It's like cyber-kidnapping for data! 💸" },
            { "social engineering", "This is when hackers use charm and manipulation instead of code to trick people. Think of it as hacking humans. 🧠" }
        };

        
        public bool TryGetResponse(string input, out string response)
        {
            return Responses.TryGetValue(input, out response);
        }
    }
}
