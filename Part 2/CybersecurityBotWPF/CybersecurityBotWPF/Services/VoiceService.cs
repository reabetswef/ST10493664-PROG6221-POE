using System.Media;
using System.IO;

namespace CybersecurityBotWPF.Services
{
    public class VoiceService
    {
        private SoundPlayer _soundPlayer;

        public void PlayGreeting()
        {
            try
            {
                // Try multiple possible paths
                string[] possiblePaths = {
                    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "greeting.wav"),
                    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "greeting.wav"),
                    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "bin", "Debug", "net8.0", "Assets", "greeting.wav"),
                    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "bin", "Debug", "net10.0", "Assets", "greeting.wav")
                };

                string audioPath = null;
                foreach (string path in possiblePaths)
                {
                    if (File.Exists(path))
                    {
                        audioPath = path;
                        break;
                    }
                }

                if (audioPath != null)
                {
                    _soundPlayer?.Dispose();
                    _soundPlayer = new SoundPlayer(audioPath);
                    _soundPlayer.Play(); // Play asynchronously
                }
            }
            catch
            {
                // Silently fail - audio is optional
            }
        }

        public void Dispose()
        {
            _soundPlayer?.Dispose();
        }
    }
}