//ST10493664 PROG6221 POE - Part 1 - Cybersecurity Awareness Bot
using System;
using System.Threading.Tasks;

namespace CybersecurityAwarenessBot
{
    // Handles user interaction, including name collection and the main chat loop.
    public static class InteractionService
    {
        private const int TypingDelayMs = 30;

        // Asks the user for their name and returns it.
        public static string GetUserName()
        {
            AsciiArt.DisplaySectionHeader("WELCOME");

            Console.ForegroundColor = ConsoleColor.Green;
            TypeWithDelay("Hello! I'm your Cybersecurity Awareness Assistant.", TypingDelayMs);
            Console.WriteLine();
            TypeWithDelay("What is your name?", TypingDelayMs);
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\nYou: ");
            string name = Console.ReadLine();
            Console.ResetColor();

            // Input validation for name
            while (string.IsNullOrWhiteSpace(name))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                TypeWithDelay("I didn't catch that. Could you please tell me your name?", TypingDelayMs);
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("\nYou: ");
                name = Console.ReadLine();
                Console.ResetColor();
            }

            // Capitalize first letter of name
            name = char.ToUpper(name[0]) + name.Substring(1).ToLower();

            Console.ForegroundColor = ConsoleColor.Green;
            TypeWithDelay($"\nWonderful to meet you, {name}! I'm here to help you stay safe online.", TypingDelayMs);
            Console.ResetColor();

            return name;
        }

        // Starts the main chat loop where users can ask cybersecurity questions.
        public static async Task StartChatLoop(string userName, ResponseService responseService)
        {
            bool running = true;
            AsciiArt.DisplaySectionHeader("MAIN MENU");

            Console.ForegroundColor = ConsoleColor.Green;
            TypeWithDelay($"So {userName}, what would you like to know about cybersecurity?", TypingDelayMs);
            Console.WriteLine();
            TypeWithDelay("You can ask me about:\n- Password safety\n- Phishing scams\n- Safe browsing\n- Malware protection\n- Social engineering\n- Data privacy\n- Multi-factor authentication\n- Secure backups\n- Identity theft\n- How I'm doing\n- My purpose\n- What I can help with", TypingDelayMs);
            TypeWithDelay("\n\nType 'exit' at any time to end our conversation.", TypingDelayMs);
            Console.ResetColor();

            while (running)
            {
                AsciiArt.DisplayDivider();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"{userName}: ");
                string userInput = Console.ReadLine();
                Console.ResetColor();

                if (string.IsNullOrWhiteSpace(userInput))
                {
                    HandleInvalidInput();
                    continue;
                }

                if (userInput.ToLower() == "exit")
                {
                    running = false;
                    Console.ForegroundColor = ConsoleColor.Green;
                    TypeWithDelay($"\nThank you for chatting with me, {userName}! Remember to stay safe online. Goodbye!", TypingDelayMs);
                    Console.ResetColor();
                    continue;
                }

                string response = responseService.GetResponse(userInput);
                Console.ForegroundColor = ConsoleColor.Green;
                TypeWithDelay($"\nBot: {response}", TypingDelayMs);
                Console.ResetColor();
                Console.WriteLine();

                await Task.Delay(500);
            }
        }

        // Handles invalid input by showing a default message.
        private static void HandleInvalidInput()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            TypeWithDelay("\nBot: I didn't quite understand that. Could you rephrase?", TypingDelayMs);
            Console.ResetColor();
            Console.WriteLine();
        }

        // Simulates a typing effect by printing characters one by one with a delay.
        private static void TypeWithDelay(string message, int delayMs)
        {
            foreach (char c in message)
            {
                Console.Write(c);
                System.Threading.Thread.Sleep(delayMs);
            }
            Console.WriteLine();
        }
    }
}