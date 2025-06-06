﻿using System;
using System.Threading;
using System.Media;
using Figgle;
using Chatbot;

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
//Link: https://www.w3schools.com/cs/cs_inheritance.php
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
    // Represents a chatbot user
    class User
    {
        public string Name { get; set; }
    }

    // Inheriting from ChatbotKnowledgeBase in Dictionary.cs
    class Program : ChatbotKnowledgeBase
    {
        static void Main(string[] args)
        {
            SoundPlayerWrapper.Play();  // Play greeting audio

            try
            {
                ShowWelcomeScreen();
                DrawBorder("Welcome");

                string name = GetValidatedInput("Enter your name: ");
                User user = new() { Name = name };

                Program chatbot = new();  // Instance to access inherited methods
                chatbot.ChatWithUser(user);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nUnexpected error: {ex.Message}");
                Console.ResetColor();
            }
            finally
            {
                Console.WriteLine("\nPress any key to exit...");
                Console.ReadKey();
            }
        }

        // Welcome screen with ASCII logo
        static void ShowWelcomeScreen()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(FiggleFonts.Standard.Render("CS Awareness Assistant"));
            Console.ResetColor();
            Console.WriteLine("Welcome to the Cybersecurity Awareness Assistant.");
            Console.WriteLine("\nPress Enter to continue...");
            Console.ReadLine();
        }

        // Border with ASCII-style title
        static void DrawBorder(string title)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            string formatted = FiggleFonts.Small.Render(title).TrimEnd();
            int width = formatted.Split('\n')[0].Length;
            Console.WriteLine(new string('=', width));
            Console.WriteLine(formatted);
            Console.WriteLine(new string('=', width));
            Console.ResetColor();
        }

        // Ensures user input is not empty
        static string GetValidatedInput(string prompt)
        {
            string input;
            do
            {
                Console.Write(prompt);
                input = Console.ReadLine()?.Trim();
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Input cannot be empty.");
                    Console.ResetColor();
                }
            } while (string.IsNullOrWhiteSpace(input));

            return input;
        }

        // The chatbot interaction logic
        public void ChatWithUser(User user)
        {
            string input;
            do
            {
                DrawBorder("Cybersecurity Assistant");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Hi {user.Name}! Ask me something or type 'exit' to leave.");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("\nYou: ");
                Console.ResetColor();
                input = Console.ReadLine()?.Trim();

                if (string.IsNullOrWhiteSpace(input))
                {
                    ShowBotResponse("Huh? I didn’t quite catch that. Speak cyber, not gibberish.");
                    continue;
                }

                if (input.Equals("exit", StringComparison.OrdinalIgnoreCase))
                {
                    ShowBotResponse("Logging off... but not emotionally. Stay safe out there, digital warrior!");
                    break;
                }

                if (TryGetResponse(input.ToLower(), out string response))
                {
                    ShowBotResponse(response);
                }
                else if (TryGetKeywordResponse(input.ToLower(), out string keywordResponse))
                {
                    ShowBotResponse(keywordResponse);
                }
                else if (TryGetRandomResponse(input.ToLower(), out string randomResponse))
                {
                    ShowBotResponse(randomResponse);
                }
                else if (TryGetFollowUpResponse(input.ToLower(), out string followUp))
                {
                    ShowBotResponse(followUp);
                }
                else
                {
                    ShowBotResponse("Hmm, I'm not sure about that. Try asking about a cybersecurity topic.");
                }




                Console.WriteLine("\nPress Enter to continue...");
                Console.ReadLine();
            } while (true);
        }

        // Typing effect response
        static void ShowBotResponse(string message)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            foreach (char c in message)
            {
                Console.Write(c);
                Thread.Sleep(20);
            }
            Console.WriteLine();
            Console.ResetColor();
        }
    }
}