using System.Collections.Generic;

namespace CybersecurityBotWPF.Services
{
    public class SentimentService
    {
        private HashSet<string> _positiveWords = new HashSet<string>
        {
            "happy", "great", "good", "excellent", "awesome", "amazing", "wonderful",
            "love", "like", "thanks", "thank", "excited", "fantastic", "brilliant"
        };

        private HashSet<string> _negativeWords = new HashSet<string>
        {
            "sad", "angry", "upset", "frustrated", "bad", "terrible", "awful",
            "hate", "dislike", "worried", "scared", "confused", "annoyed"
        };

        public string DetectSentiment(string message)
        {
            string lowerMessage = message.ToLower();

            foreach (string word in _positiveWords)
            {
                if (lowerMessage.Contains(word))
                    return "excited";
            }

            foreach (string word in _negativeWords)
            {
                if (lowerMessage.Contains(word))
                    return "negative";
            }

            return "neutral";
        }
    }
}