//ST10493664 PROG6221 POE Part 1
using System;
using System.Threading;

namespace CyberSecurityChatbot
{
    class UIHelper
    {
        public static void DisplayWelcomeScreen()
        {
            Console.Clear();

            DrawBorder();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("CYBERSECURITY AWARENESS CHATBOT");
            Console.ResetColor();

            DrawBorder();

            // ASCII Logo
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine(@"
   ██████╗ ██╗   ██╗██████╗ ███████╗██████╗ 
  ██╔════╝ ██║   ██║██╔══██╗██╔════╝██╔══██╗
  ██║      ██║   ██║██████╔╝█████╗  ██████╔╝
  ██║      ██║   ██║██╔══██╗██╔══╝  ██╔══██╗
  ╚██████╗ ╚██████╔╝██████╔╝███████╗██║  ██║
   ╚═════╝  ╚═════╝ ╚═════╝ ╚══════╝╚═╝  ╚═╝

        🔐 CYBER SECURITY CHATBOT 🔐

        [ PROTECT • DETECT • RESPOND ]

              .--------.
             / .------. \
            / /        \ \
            | |  .--.  | |
            | | (____) | |
            | |        | |
            | '--------' |
             \__________/

        >>> STAY SAFE ONLINE <<<
");

            Console.ResetColor();

            TypeText("\nWelcome! I will help you stay safe online.\n");
        }

        public static void DrawBorder()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(new string('=', 50));
            Console.ResetColor();
        }

        public static void CenterText(string text)
        {
            int width = Console.WindowWidth;
            int leftPadding = (width - text.Length) / 2;
            Console.SetCursorPosition(Math.Max(leftPadding, 0), Console.CursorTop);
            Console.WriteLine(text);
        }

        public static void TypeText(string message)
        {
            foreach (char c in message)
            {
                Console.Write(c);
                Thread.Sleep(15);
            }
        }
    }
}