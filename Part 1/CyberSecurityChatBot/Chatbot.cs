//ST10493664 PROG6221 POE Part 1
using System;
using System.Threading;

namespace CyberSecurityChatbot
{
    class Chatbot
    {
        private string userName;

        public void StartChat()
        {
            AskUserName();
            ShowHelpMenu();

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("\nYou: ");
                Console.ResetColor();

                string input = Console.ReadLine()?.ToLower().Trim();

                // ✅ Input validation
                if (string.IsNullOrWhiteSpace(input))
                {
                    DefaultResponse();
                    continue;
                }

                if (input == "exit")
                {
                    Goodbye();
                    break;
                }

                Respond(input);
            }
        }

        private void AskUserName()
        {
            UIHelper.TypeText("\nEnter your name: ");
            userName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(userName))
                userName = "User";

            UIHelper.TypeText($"\nWelcome, {userName}! I'm your Cybersecurity Assistant.\n");
        }

        private void ShowHelpMenu()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\nYou can ask me about:");
            Console.WriteLine("- Password safety");
            Console.WriteLine("- Phishing scams");
            Console.WriteLine("- Safe browsing");
            Console.WriteLine("- General questions");
            Console.WriteLine("Type 'exit' to quit.\n");
            Console.ResetColor();
        }

        private void Respond(string input)
        {
            if (input.Contains("how are you"))
            {
                BotReply("I'm running perfectly and ready to help!");
            }
            else if (input.Contains("purpose"))
            {
                BotReply("I help users stay safe online by teaching cybersecurity basics.");
            }
            else if (input.Contains("ask"))
            {
                BotReply("You can ask about passwords, phishing, and safe browsing.");
            }
            else if (input.Contains("password"))
            {
                BotReply("Use strong passwords: at least 12 characters, mix symbols, numbers, and letters. Never reuse passwords.");
            }
            else if (input.Contains("phishing"))
            {
                BotReply("Phishing scams try to trick you into giving personal info. Never click suspicious links and always verify the sender.");
            }
            else if (input.Contains("browsing"))
            {
                BotReply("Only browse secure websites (HTTPS). Avoid downloading files from unknown sources.");
            }
            else if (input.Contains("malware"))
            {
                BotReply("Malware is harmful software. Install antivirus and avoid suspicious downloads.");
            }
            else if (input.Contains("safe"))
            {
                BotReply("Keep your software updated, use strong passwords, and avoid public Wi-Fi for sensitive tasks.");
            }
            else if (input.Contains("thank"))
            {
                BotReply("You're welcome! Stay cyber safe.");
            }
            else
            {
                DefaultResponse();
            }
        }

        private void BotReply(string message)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("\nBot: ");
            Console.ResetColor();

            foreach (char c in message)
            {
                Console.Write(c);
                Thread.Sleep(15);
            }

            Console.WriteLine();
        }

        private void DefaultResponse()
        {
            BotReply("I didn't quite understand that. Try asking about passwords, phishing, or browsing.");
        }

        private void Goodbye()
        {
            BotReply($"Goodbye, {userName}! Stay safe online.");
        }
    }
}