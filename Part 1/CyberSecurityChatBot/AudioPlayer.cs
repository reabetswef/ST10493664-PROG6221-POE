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