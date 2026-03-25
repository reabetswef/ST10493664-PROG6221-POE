//ST10493664 PROG6221 POE Part 1
using System;

namespace CyberSecurityChatbot
{
    class Program
    {
        static void Main(string[] args)
        {

            UIHelper.DisplayWelcomeScreen();
            AudioPlayer.PlayGreeting();

            Console.Write("\nEnter your name: ");
            string userName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(userName))
                userName = "User";

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\nWelcome, {userName}! Let's get started.");
            Console.ResetColor();

            Chatbot bot = new Chatbot(userName);
            bot.StartChat();

            Console.ReadLine();
        }
    }
}