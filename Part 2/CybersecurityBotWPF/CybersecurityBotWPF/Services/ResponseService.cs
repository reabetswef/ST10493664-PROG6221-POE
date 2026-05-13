using System;
using CybersecurityBotWPF.Models;

namespace CybersecurityBotWPF.Services
{
    public class ResponseService
    {
        public string GetResponse(string userInput, string sentiment, string userName, ConversationMemory memory)
        {
            if (string.IsNullOrWhiteSpace(userInput))
            {
                return "I didn't quite understand that. Could you rephrase?";
            }

            string input = userInput.ToLower();

            // Sentiment-based opening
            if (sentiment == "negative")
            {
                return "I'm sorry you're feeling that way. " + GetCybersecurityResponse(input, userName, memory);
            }
            else if (sentiment == "excited")
            {
                return "That's great energy! " + GetCybersecurityResponse(input, userName, memory);
            }

            return GetCybersecurityResponse(input, userName, memory);
        }

        private string GetCybersecurityResponse(string input, string userName, ConversationMemory memory)
        {
            // Check if user has asked before (memory)
            bool askedBefore = memory.HasAskedBefore(input);
            string memoryPrefix = askedBefore ? $"As I mentioned earlier, " : "";

            // Password safety
            if (input.Contains("password"))
            {
                return $"{memoryPrefix}Strong passwords are essential! Use a mix of uppercase, lowercase, numbers, and symbols. " +
                       $"Avoid using personal information. Consider using a password manager, {userName}!";
            }

            // Phishing
            if (input.Contains("phishing"))
            {
                return $"{memoryPrefix}Phishing is when attackers send fake emails pretending to be legitimate companies. " +
                       $"Always check the sender's email address and never click suspicious links.";
            }

            // Safe browsing
            if (input.Contains("safe browsing") || input.Contains("https"))
            {
                return $"{memoryPrefix}For safe browsing, look for the padlock icon (HTTPS) in the address bar. " +
                       $"Avoid public Wi-Fi for sensitive transactions, and keep your browser updated.";
            }

            // Malware
            if (input.Contains("malware") || input.Contains("virus"))
            {
                return $"{memoryPrefix}Malware includes viruses, worms, and ransomware. Protect yourself with updated " +
                       $"antivirus software and avoid downloading from untrusted sources.";
            }

            // Social engineering
            if (input.Contains("social engineering") || input.Contains("scam"))
            {
                return $"{memoryPrefix}Social engineering manipulates people into giving up confidential information. " +
                       $"Always verify who you're talking to before sharing sensitive data.";
            }

            // Data privacy
            if (input.Contains("privacy") || input.Contains("data"))
            {
                return $"{memoryPrefix}Protect your privacy by reviewing social media settings, being careful what you post, " +
                       $"and reading privacy policies before signing up for services.";
            }

            // MFA
            if (input.Contains("mfa") || input.Contains("2fa") || input.Contains("multi factor"))
            {
                return $"{memoryPrefix}Multi-Factor Authentication adds an extra layer of security. " +
                       $"Enable it on all accounts that offer it - it's one of the best protections available!";
            }

            // Backups
            if (input.Contains("backup"))
            {
                return $"{memoryPrefix}Follow the 3-2-1 backup rule: keep 3 copies of your data, on 2 different media types, " +
                       $"with 1 copy stored off-site. Regular backups are your safety net against ransomware!";
            }

            // Identity theft
            if (input.Contains("identity theft") || input.Contains("identity"))
            {
                return $"{memoryPrefix}Protect your identity by monitoring your credit reports, using strong unique passwords, " +
                       $"and being cautious about sharing your ID number online.";
            }

            // Ransomware
            if (input.Contains("ransomware"))
            {
                return $"{memoryPrefix}Ransomware locks your files and demands payment. Never pay the ransom! " +
                       $"Regular backups are your best defense.";
            }

            // Greeting
            if (input.Contains("how are you"))
            {
                return $"I'm doing great, {userName}! Thanks for asking. I'm here to help you stay safe online.";
            }

            // Purpose
            if (input.Contains("purpose") || input.Contains("what can you do"))
            {
                return $"My purpose is to educate people about cybersecurity threats, {userName}. " +
                       $"I can help with passwords, phishing, safe browsing, malware, and much more!";
            }

            // Thanks
            if (input.Contains("thank"))
            {
                return $"You're very welcome, {userName}! Stay safe out there! 😊";
            }

            // Default response
            return $"That's an interesting question, {userName}! I specialize in cybersecurity topics like password safety, " +
                   $"phishing, safe browsing, malware, social engineering, data privacy, MFA, backups, and identity theft. " +
                   $"Could you ask me about one of those areas?";
        }
    }
}