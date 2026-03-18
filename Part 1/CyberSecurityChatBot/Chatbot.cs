using System;

namespace CyberSecurityChatbot
{
    class Chatbot
    {
        private string userName;

        public void StartChat()
        {
            AskUserName();

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("\nYou: ");
                Console.ResetColor();

                string input = Console.ReadLine().ToLower();

                if (string.IsNullOrWhiteSpace(input))
                {
                    DefaultResponse();
                    continue;
                }

                if (input.Contains("exit"))
                {
                    Goodbye();
                    break;
                }

                Respond(input);
            }
        }

        private void AskUserName()
        {
            Console.Write("Enter your name: ");
            userName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(userName))
            {
                userName = "User";
            }

            Console.WriteLine($"Hello, {userName}! How can I help you today?");
        }

        private void Respond(string input)
        {
            if (input.Contains("how are you"))
            {
                Console.WriteLine("I'm just a bot, but I'm here to help you stay safe online!");
            }
            else if (input.Contains("purpose"))
            {
                Console.WriteLine("My purpose is to educate you about cybersecurity and keep you safe online.");
            }
            else if (input.Contains("ask"))
            {
                Console.WriteLine("You can ask me about passwords, phishing, and safe browsing.");
            }
            else if (input.Contains("password"))
            {
                Console.WriteLine("Use strong passwords with a mix of letters, numbers, and symbols.");
            }
            else if (input.Contains("phishing"))
            {
                Console.WriteLine("Be careful of suspicious emails asking for personal information.");
            }
            else if (input.Contains("browsing"))
            {
                Console.WriteLine("Only visit secure websites and avoid clicking unknown links.");
            }
            else
            {
                DefaultResponse();
            }
        }

        private void DefaultResponse()
        {
            Console.WriteLine("I didn't quite understand that. Could you rephrase?");
        }

        private void Goodbye()
        {
            Console.WriteLine($"Goodbye, {userName}! Stay safe online.");
        }
    }
}