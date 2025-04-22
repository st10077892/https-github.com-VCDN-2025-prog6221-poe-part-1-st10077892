using System;
using System.Media;

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
    class SoundPlayerWrapper
    {
        public static void Play()
        {
            try
            {
                var player = new System.Media.SoundPlayer("Greeting.wav");
                player.PlaySync(); 
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Could not play the voice greeting. Check if 'greeting.wav' is present.");
                Console.ResetColor();
            }
        }
    }
}
