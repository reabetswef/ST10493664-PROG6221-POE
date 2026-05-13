using System.Collections.Generic;

namespace CybersecurityBotWPF.Services
{
    public class SentimentService
    {
        // Positive/excited emotions
        private HashSet<string> _excitedWords = new HashSet<string>
        {
            "happy", "great", "good", "excellent", "awesome", "amazing", "wonderful",
            "love", "like", "thanks", "thank", "excited", "fantastic", "brilliant",
            "cool", "perfect", "wow", "yes", "interested", "curious"
        };

        // Worried/anxious emotions
        private HashSet<string> _worriedWords = new HashSet<string>
        {
            "worried", "anxious", "nervous", "concerned", "uneasy", "unsure",
            "scared", "afraid", "fear", "panic", "stressed", "overwhelmed"
        };

        // Frustrated/angry emotions
        private HashSet<string> _frustratedWords = new HashSet<string>
        {
            "frustrated", "angry", "annoyed", "upset", "mad", "irritated",
            "tired", "exhausted", "frustrating", "difficult", "hard"
        };

        // Curious/inquisitive emotions
        private HashSet<string> _curiousWords = new HashSet<string>
        {
            "curious", "wondering", "interesting", "tell me", "explain",
            "how does", "why", "what is", "learn", "understand"
        };

        // Sad/discouraged emotions
        private HashSet<string> _sadWords = new HashSet<string>
        {
            "sad", "depressed", "hopeless", "discouraged", "disappointed",
            "down", "unhappy", "miserable", "terrible"
        };

        public string DetectSentiment(string message)
        {
            string lowerMessage = message.ToLower();

            // Check for worried/anxious (highest priority - needs empathy)
            foreach (string word in _worriedWords)
            {
                if (lowerMessage.Contains(word))
                    return "worried";
            }

            // Check for frustrated/angry
            foreach (string word in _frustratedWords)
            {
                if (lowerMessage.Contains(word))
                    return "frustrated";
            }

            // Check for sad/discouraged
            foreach (string word in _sadWords)
            {
                if (lowerMessage.Contains(word))
                    return "sad";
            }

            // Check for curious
            foreach (string word in _curiousWords)
            {
                if (lowerMessage.Contains(word))
                    return "curious";
            }

            // Check for excited/positive
            foreach (string word in _excitedWords)
            {
                if (lowerMessage.Contains(word))
                    return "excited";
            }

            return "neutral";
        }

        public string GetEmpatheticPrefix(string sentiment, string topic = "")
        {
            switch (sentiment)
            {
                case "worried":
                    return "😟 I completely understand why you'd feel worried about this. It's normal to have concerns about cybersecurity. Let me share some practical tips to help ease your mind:\n\n";

                case "frustrated":
                    return "😤 I hear your frustration! Cybersecurity can feel overwhelming sometimes. Take a deep breath - I'm here to help make this easier for you. Here's something practical:\n\n";

                case "sad":
                    return "😔 I'm sorry you're feeling this way. Cybersecurity issues can be discouraging, but remember that every step you take makes you safer. Let me help:\n\n";

                case "curious":
                    return "🧠 That's a great question! I love your curiosity about cybersecurity. Here's what you should know:\n\n";

                case "excited":
                    return "🎉 That's awesome energy! I'm excited to help you learn more about cybersecurity. Check this out:\n\n";

                default:
                    return "";
            }
        }

        public string GetEncouragingFollowUp(string sentiment)
        {
            switch (sentiment)
            {
                case "worried":
                    return "\n\n💪 Remember: Being aware is the first step to being safe. You're already doing great by learning about this! Would you like another tip to feel more confident?";

                case "frustrated":
                    return "\n\n✨ You've got this! Cybersecurity doesn't have to be perfect - just consistent. Want me to share an easier tip?";

                case "sad":
                    return "\n\n🌟 Every small step counts! You're building good habits. Would you like to hear something encouraging?";

                case "curious":
                    return "\n\n🔍 Keep those questions coming! Curiosity is what makes great cybersecurity experts. Want to dive deeper into this topic?";

                case "excited":
                    return "\n\n🚀 Love your enthusiasm! Want another exciting cybersecurity tip?";

                default:
                    return "\n\n💡 Would you like another tip on this topic?";
            }
        }
    }
}