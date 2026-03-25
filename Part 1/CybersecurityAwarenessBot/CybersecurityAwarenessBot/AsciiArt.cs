// File: AsciiArt.cs
using System;

namespace CybersecurityAwarenessBot
{
    /// <summary>
    /// Contains ASCII art for visual enhancement of the chatbot.
    /// </summary>
    public static class AsciiArt
    {
        /// <summary>
        /// Displays the main logo for the Cybersecurity Awareness Bot.
        /// </summary>
        public static void DisplayLogo()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            string logo = @"
    ╔══════════════════════════════════════════════════════════════════════╗
    ║                                                                      ║
    ║    ██████╗██╗   ██╗██████╗ ███████╗██████╗     █████╗ ██╗    ██╗     ║
    ║   ██╔════╝╚██╗ ██╔╝██╔══██╗██╔════╝██╔══██╗   ██╔══██╗██║    ██║     ║
    ║   ██║      ╚████╔╝ ██████╔╝█████╗  ██████╔╝   ███████║██║ █╗ ██║     ║
    ║   ██║       ╚██╔╝  ██╔══██╗██╔══╝  ██╔══██╗   ██╔══██║██║███╗██║     ║
    ║   ╚██████╗   ██║   ██████╔╝███████╗██║  ██║   ██║  ██║╚███╔███╔╝     ║
    ║    ╚═════╝   ╚═╝   ╚═════╝ ╚══════╝╚═╝  ╚═╝   ╚═╝  ╚═╝ ╚══╝╚══╝      ║
    ║                                                                      ║
    ║           ██████╗ ██████╗ ████████╗                               ║
    ║          ██╔═══██╗██╔══██╗╚══██╔══╝                               ║
    ║          ██║   ██║██████╔╝   ██║                                  ║
    ║          ██║   ██║██╔══██╗   ██║                                  ║
    ║          ╚██████╔╝██████╔╝   ██║                                  ║
    ║           ╚═════╝ ╚═════╝    ╚═╝                                  ║
    ║                                                                      ║
    ║                     CYBERSECURITY AWARENESS BOT                      ║
    ║                         Stay Safe Online!                            ║
    ║                                                                      ║
    ╚══════════════════════════════════════════════════════════════════════╝";

            Console.WriteLine(logo);
            Console.ResetColor();
            Console.WriteLine();
        }

        /// <summary>
        /// Displays a decorative border for section headers.
        /// </summary>
        public static void DisplaySectionHeader(string title)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            string border = new string('═', 60);
            Console.WriteLine($"\n╔{border}╗");
            Console.WriteLine($"║{title.PadLeft(30 + title.Length / 2).PadRight(60)}║");
            Console.WriteLine($"╚{border}╝");
            Console.ResetColor();
        }

        /// <summary>
        /// Displays a simple decorative divider.
        /// </summary>
        public static void DisplayDivider()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(new string('─', 60));
            Console.ResetColor();
        }
    }
}