//ST10493664 PROG6221 POE Part 1
//using System;

namespace CyberSecurityChatbot
{
    class Program
    {
        static void Main(string[] args)
        {
            // Play voice greeting
            AudioPlayer.PlayGreeting();

            // Display ASCII UI
            UIHelper.DisplayWelcomeScreen();

            // Start chatbot
            Chatbot bot = new Chatbot();
            bot.StartChat();

            Console.ReadLine();
        }
    }
}