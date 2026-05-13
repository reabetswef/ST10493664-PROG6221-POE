using System.Collections.Generic;
using System.Linq;

namespace CybersecurityBotWPF.Models
{
    public class ConversationMemory
    {
        public string UserName { get; set; } = "Guest";
        private List<string> _userQuestions = new List<string>();
        private List<string> _botResponses = new List<string>();

        public void AddToHistory(string message, bool isUser)
        {
            if (isUser)
            {
                _userQuestions.Add(message.ToLower());
                // Keep only last 10 for memory efficiency
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

        public bool HasAskedBefore(string question)
        {
            string lowerQuestion = question.ToLower();

            // Check if similar question was asked before (simple keyword matching)
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
        }

        public string GetLastBotResponse()
        {
            return _botResponses.LastOrDefault() ?? string.Empty;
        }
    }
}