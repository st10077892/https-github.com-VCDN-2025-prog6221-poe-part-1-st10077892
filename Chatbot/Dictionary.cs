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

//Name: C# Inheritance
//Author: W3Schools
//Link:https://www.w3schools.com/cs/cs_inheritance.php
//Date accessed: 15 April 2025

//Name: Types of Cyber Attacks
//Author: Check Point
//Link: https://www.checkpoint.com/cyber-hub/cyber-security/what-is-cyber-attack/types-of-cyber-attacks/
//Date accessed: 15 April 2025

//Name: SoundPlayer Class
//Author: Microsoft
//Link: https://learn.microsoft.com/en-us/dotnet/api/system.media.soundplayer?view=windowsdesktop-9.0
//Date accessed: 15 April 2025

//Name: Validating Input
//Author: Makers Institute
//Link: https://makersinstitute.gitbooks.io/c-basics/content/validating-input.html
//Date accessed: 15 April 2025

namespace Chatbot
{
    public class ChatbotKnowledgeBase
    {
        // Dictionary questions
        protected Dictionary<string, string> Responses = new(StringComparer.OrdinalIgnoreCase)
        {
            { "how are you?", "I’m thriving in the matrix! Thanks for asking, human." },
            { "what is your purpose?", "To help South Africans stay protected from cyber threats like phishing and scams." },
            {"im worried about online scams", "Its completely understandable to feel that way. Scammers can be very convincing." },
            { "what can i ask you about?", "You can ask about password attacks, ransomware, phishing, safe browsing, social engineering." },
            { "password attack", "A password attack is any attempt by a malicious actor to gain unauthorized access by cracking passwords. Passwords should be like your toothbrush: long, unique, and never shared. 🪥" },
            { "phishing", "Phishing is when someone tricks you into revealing sensitive info using fake emails or messages. 🐟" },
            { "safe browsing", "Safe browsing means staying away from shady websites and always checking for HTTPS 🔒." },
            { "ransomware", "Ransomware locks your files and asks for money. It's like cyber-kidnapping for data! 💸" },
            { "social engineering", "This is when hackers use charm and manipulation instead of code to trick people. Think of it as hacking humans. 🧠" }
        };

        protected Dictionary<string, string> KeywordResponses = new(StringComparer.OrdinalIgnoreCase)
    {
        { "password", "Make sure to use strong, unique passwords for each account. Avoid using personal details in your passwords." },
        { "scam", "Be cautious of unsolicited messages or offers that seem too good to be true. Always verify sources." },
        { "privacy", "Protect your privacy by limiting the personal information you share online and reviewing app permissions regularly." }
    };

        protected Dictionary<string, List<string>> RandomResponses = new(StringComparer.OrdinalIgnoreCase)
    {
        { "phishing tip", new List<string>
            {
                "Be cautious of emails asking for personal information. Scammers often disguise themselves as trusted organisations.",
                "Always check the sender's email address before clicking links. If in doubt, don’t click!",
                "Hover over links to preview URLs before clicking. Stay alert!",
                "Never download attachments from unknown or suspicious emails.",
                "Use two-factor authentication to add an extra layer of protection."
            }
        }
    };

        Random rng = new();

        private readonly List<string> followUpTriggers = new()
    {
        "tell me more",
        "what do you mean",
        "explain further",
        "more info",
        "i don’t understand",
        "can you clarify",
        "details"
    };

        private string currentTopic = null;




        public bool TryGetResponse(string input, out string response)
        {
            return Responses.TryGetValue(input, out response);
        }

        public bool TryGetKeywordResponse(string input, out string response)
        {
            foreach (var kvp in KeywordResponses)
            {
                if (input.Contains(kvp.Key, StringComparison.OrdinalIgnoreCase))
                {
                    response = kvp.Value;
                    return true;
                }
            }
            response = null!;
            return false;
        }

        public bool TryGetRandomResponse(string input, out string response)
        {
            foreach (var kvp in RandomResponses)
            {
                if (input.Contains(kvp.Key, StringComparison.OrdinalIgnoreCase))
                {
                    var responses = kvp.Value;
                    response = responses[rng.Next(responses.Count)];
                    return true;
                }
            }
            response = null!;
            return false;
        }

        public bool TryGetFollowUpResponse(string input, out string response)
        {
            foreach (var phrase in followUpTriggers)
            {
                if (input.Contains(phrase, StringComparison.OrdinalIgnoreCase) && currentTopic != null)
                {
                    response = GetFollowUpForTopic(currentTopic);
                    return true;
                }
            }
            response = null!;
            return false;
        }

        private string GetFollowUpForTopic(string topic)
        {
            return topic.ToLower() switch
            {
                "password" or "password attack" => "Try using a password manager and avoid reusing passwords across multiple sites.",
                "phishing" or "phishing tip" => "Never trust links from unknown senders. If an email sounds urgent or alarming, it might be phishing.",
                "ransomware" => "Keep backups of important files and always update your antivirus software.",
                "safe browsing" => "Install browser extensions that block trackers and avoid clicking on pop-up ads.",
                "social engineering" => "Don't overshare on social media—attackers often use your public info against you.",
                _ => "Let me get back to you on that. 🧐"
            };
        }
        }
}