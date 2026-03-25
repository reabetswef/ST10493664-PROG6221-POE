//ST10493664 PROG6221 POE - Part 1 - Cybersecurity Awareness Bot
using System;
using System.Media;
using System.IO;

namespace CybersecurityAwarenessBot
{
    // Handles the audio greeting functionality for the chatbot.
    public static class VoiceService
    {
        private const string AudioFilePath = "greeting.wav";

        // Plays the welcome audio greeting.
        public static void PlayGreeting()
        {
            try
            {
                if (File.Exists(AudioFilePath))
                {
                    using (SoundPlayer player = new SoundPlayer(AudioFilePath))
                    {
                        player.PlaySync(); // Play synchronously to ensure it completes before UI starts
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("[System] Audio file 'greeting.wav' not found. Continuing with text-only mode.");
                    Console.ResetColor();
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"[System] Error playing audio: {ex.Message}");
                Console.ResetColor();
            }
        }
    }
}