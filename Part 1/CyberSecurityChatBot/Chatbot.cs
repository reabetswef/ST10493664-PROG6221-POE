//ST10493664 PROG6221 POE Part 1
using System;
using System.Threading;

namespace CyberSecurityChatbot
{
    class Chatbot
    {
        private string userName;
        public Chatbot(string name)
        {
            userName = name;
        }

        public void StartChat()
        {
            bool running = true;

            while (running)
            {
                UIHelper.ShowMainMenu();
                string choice = Console.ReadLine()?.Trim();

                switch (choice)
                {
                    case "1":
                        RunChat();
                        break;

                    case "2":
                        UIHelper.ShowHelp();
                        break;

                    case "3":
                        running = false;
                        Goodbye();
                        break;

                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        Thread.Sleep(1000);
                        break;
                }
            }
        }

        private void ShowHelpMenu()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;

            Console.WriteLine("\nYou can ask me about:\n");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("1. Password Safety");
            Console.WriteLine("2. Phishing Scams");
            Console.WriteLine("3. Malware & Viruses");
            Console.WriteLine("4. Safe Browsing");
            Console.WriteLine("5. Public Wi-Fi Safety");
            Console.WriteLine("6. Identity Theft");
            Console.WriteLine("7. Privacy & Data Protection");
            Console.WriteLine("8. Email Security");
            Console.WriteLine("9. Mobile Device Safety");
            Console.WriteLine("10. General Cybersecurity Tips");

            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\nYou can also ask general questions like:");
            Console.WriteLine("- 'How are you?'");
            Console.WriteLine("- 'What is your purpose?'");
            Console.WriteLine("- 'What can I ask you about?'\n");

            Console.WriteLine("Type 'exit' anytime to return to the main menu.");
            Console.ResetColor();
        }

        private void RunChat()
        {
            ShowHelpMenu();

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"\n{userName}: ");
                Console.ResetColor();

                string input = Console.ReadLine()?.ToLower().Trim();

                if (string.IsNullOrWhiteSpace(input))
                {
                    DefaultResponse();
                    continue;
                }

                if (input == "exit")
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("\nReturning to menu...\n");
                    Console.ResetColor();
                    break;
                }

                Respond(input);
            }
        }

        private void Respond(string input)
        {
            string response = ResponseHandler.GetResponse(input);

            if (response != null)
            {
                BotReply(response);
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

            Thread.Sleep(300);

            foreach (char c in message)
            {
                Console.Write(c);
                Thread.Sleep(15);
            }

            Console.WriteLine($"\n({userName}, feel free to ask more!)");
        }

        private void DefaultResponse()
        {
            BotReply("I didn't quite understand that. Try asking about passwords, phishing, malware, or safe browsing.");
        }

        private void Goodbye()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            BotReply($"Goodbye, {userName}! Stay safe online.");
        }
    }
}