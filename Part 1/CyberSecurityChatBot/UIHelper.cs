//ST10493664 PROG6221 POE Part 1
using System;
using System.Threading;

namespace CyberSecurityChatbot
{
    class UIHelper
    {
        public static void DisplayWelcomeScreen()
        {
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

        public static void ShowMainMenu()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\n========================================");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("MAIN MENU");

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("========================================");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("1 → Start Chat");
            Console.WriteLine("2 → Help");
            Console.WriteLine("3 → Exit");

            Console.ResetColor();
            Console.Write("\nSelect an option: ");
        }

        public static void ShowHelp()
        {
            DrawBorder();

            Console.ForegroundColor = ConsoleColor.Yellow;
            CenterText("HELP SECTION");
            Console.ResetColor();

            DrawBorder();

            Console.WriteLine("\nThis chatbot helps you stay safe online.\n");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("You can ask about:");
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

            Console.WriteLine("\nType 'exit' during chat to return to menu.\n");

            DrawBorder();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}