using System.Collections.Generic;
using System.Linq;

namespace CybersecurityBotWPF.Models
{
    public class ConversationMemory
    {
        public string UserName { get; set; } = "Guest";
        public string FavoriteTopic { get; set; } = "";
        public string SecurityConcern { get; set; } = "";
        public int TipsGiven { get; set; } = 0;

        private List<string> _userQuestions = new List<string>();
        private List<string> _botResponses = new List<string>();
        private List<string> _discussedTopics = new List<string>();

        public void AddToHistory(string message, bool isUser)
        {
            if (isUser)
            {
                _userQuestions.Add(message.ToLower());
                if (_userQuestions.Count > 10)
                    _userQuestions.RemoveAt(0);
            }
            else
            {
                _botResponses.Add(message);
                if (_botResponses.Count > 10)
                    _botResponses.RemoveAt(0);
            }
        }

        public void AddDiscussedTopic(string topic)
        {
            if (!_discussedTopics.Contains(topic))
            {
                _discussedTopics.Add(topic);
            }
        }

        public bool HasDiscussedTopic(string topic)
        {
            return _discussedTopics.Contains(topic);
        }

        public bool HasAskedBefore(string question)
        {
            string lowerQuestion = question.ToLower();

            foreach (string pastQuestion in _userQuestions)
            {
                if (pastQuestion.Contains(lowerQuestion) || lowerQuestion.Contains(pastQuestion))
                {
                    return true;
                }
            }
            return false;
        }

        public void ClearHistory()
        {
            _userQuestions.Clear();
            _botResponses.Clear();
            _discussedTopics.Clear();
            FavoriteTopic = "";
            SecurityConcern = "";
            TipsGiven = 0;
        }

        public string GetLastBotResponse()
        {
            return _botResponses.LastOrDefault() ?? string.Empty;
        }

        public string GetPersonalizedGreeting()
        {
            if (!string.IsNullOrEmpty(FavoriteTopic))
            {
                return $"Welcome back! Since you're interested in {FavoriteTopic}, would you like more tips on that topic today?";
            }
            else if (!string.IsNullOrEmpty(SecurityConcern))
            {
                return $"Welcome back! Remember when you mentioned concerns about {SecurityConcern}? I have more tips to help you stay safe!";
            }
            return $"Great to see you again, {UserName}! Ready to learn more about cybersecurity?";
        }

        public string GetPersonalizedReminder()
        {
            if (!string.IsNullOrEmpty(FavoriteTopic))
            {
                return $"As someone interested in {FavoriteTopic}, here's an important reminder: ";
            }
            else if (!string.IsNullOrEmpty(SecurityConcern))
            {
                return $"Since you're concerned about {SecurityConcern}, remember that ";
            }
            return "";
        }
    }
}