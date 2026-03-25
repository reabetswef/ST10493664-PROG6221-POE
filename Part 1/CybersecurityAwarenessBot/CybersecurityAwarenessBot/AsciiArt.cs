//ST10493664 PROG6221 POE - Part 1 - Cybersecurity Awareness Bot
using System;

namespace CybersecurityAwarenessBot
{
    // Contains ASCII art for visual enhancement of the chatbot.
    public static class AsciiArt
    {
        // Displays the main logo for the Cybersecurity Awareness Bot.
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
    ║                     ██████╗  ██████╗ ████████╗                       ║
    ║                     ██╔══██╗██╔═══██╗╚══██╔══╝                       ║
    ║                     ██████╔╝██║   ██║   ██║                          ║
    ║                     ██╔══██╗██║   ██║   ██║                          ║
    ║                     ██████╔╝╚██████╔╝   ██║                          ║
    ║                     ╚═════╝  ╚═════╝    ╚═╝                          ║
    ║                                                                      ║
    ║                     CYBERSECURITY AWARENESS BOT                      ║
    ║                         Stay Safe Online!                            ║
    ║                                                                      ║
    ╚══════════════════════════════════════════════════════════════════════╝";

            Console.WriteLine(logo);
            Console.ResetColor();
            Console.WriteLine();
        }

        // Displays a decorative border for section headers.
        public static void DisplaySectionHeader(string title)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            string border = new string('═', 60);
            Console.WriteLine($"\n╔{border}╗");
            Console.WriteLine($"║{title.PadLeft(30 + title.Length / 2).PadRight(60)}║");
            Console.WriteLine($"╚{border}╝");
            Console.ResetColor();
        }

        // Displays a simple decorative divider.
        public static void DisplayDivider()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(new string('─', 60));
            Console.ResetColor();
        }
    }
}