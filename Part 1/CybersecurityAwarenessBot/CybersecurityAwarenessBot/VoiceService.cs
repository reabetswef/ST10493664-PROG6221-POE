// File: VoiceService.cs
using System;
using System.Media;
using System.IO;

namespace CybersecurityAwarenessBot
{
    /// <summary>
    /// Handles the audio greeting functionality for the chatbot.
    /// </summary>
    public static class VoiceService
    {
        private const string AudioFilePath = "greeting.wav";

        /// <summary>
        /// Plays the welcome audio greeting.
        /// </summary>
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