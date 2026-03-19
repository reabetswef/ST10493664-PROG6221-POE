//ST10493664 PROG6221 POE Part 1
using System.Media;
using System.Speech.Synthesis;

namespace CyberSecurityChatbot
{
    class AudioPlayer
    {
        public static void PlayGreeting()
        {
            try
            {
                SoundPlayer player = new SoundPlayer("greeting.wav");
                player.PlaySync();
            }
            catch
            {
                // If file missing, ignore (prevents crash)
            }
        }
    }
}