using System;
using System.Threading;

namespace CyberSecurityChatbot
{
    class UIHelper
    {
        public static void DisplayWelcomeScreen()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine("========================================");
            Console.WriteLine("   CYBERSECURITY AWARENESS CHATBOT");
            Console.WriteLine("========================================");

            Console.ResetColor();

            // ASCII Art
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine(@"
   _______  _______  _______  _______
  (  ____ \(  ____ \(  ____ \(  ____ )
  | (    \/| (    \/| (    \/| (    )|
  | |      | (__    | (__    | (____)|
  | | ____ |  __)   |  __)   |     __)
  | | \_  )| (      | (      | (\ (
  | (___) || (____/\| (____/\| ) \ \__
  (_______)(_______/(_______/|/   \__/
");

            Console.ResetColor();

            TypeText("Welcome to the Cybersecurity Awareness Bot...\n");
        }

        public static void TypeText(string message)
        {
            foreach (char c in message)
            {
                Console.Write(c);
                Thread.Sleep(20); // typing effect
            }
        }
    }
}