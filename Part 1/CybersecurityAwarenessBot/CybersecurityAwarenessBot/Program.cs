//ST10493664 PROG6221 POE - Part 1 - Cybersecurity Awareness Bot
using System;
using System.Threading.Tasks;

namespace CybersecurityAwarenessBot
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.Title = "Cybersecurity Awareness Bot";
                   
            // 1. Display ASCII Art
            AsciiArt.DisplayLogo();

            // 2. Voice Greeting
            VoiceService.PlayGreeting();

            // 3. Text Greeting and User Interaction
            string userName = InteractionService.GetUserName();

            // 4. Basic Response System
            ResponseService responseService = new ResponseService();

            // 5. Chat Loop with Input Validation
            await InteractionService.StartChatLoop(userName, responseService);
        }
    }
} 