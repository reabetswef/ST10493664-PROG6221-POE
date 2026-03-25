// File: ResponseService.cs
using System;
using System.Collections.Generic;

namespace CybersecurityAwarenessBot
{
    /// <summary>
    /// Manages responses to user queries, including keyword matching and default messages.
    /// </summary>
    public class ResponseService
    {
        private readonly Dictionary<string, string> _responses;

        public ResponseService()
        {
            _responses = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                // Greetings and personal questions
                { "how are you", "I'm doing well, thank you for asking! I'm here and ready to help you learn about cybersecurity." },
                { "purpose", "My purpose is to educate and raise awareness about cybersecurity threats. I want to help you stay safe online by providing tips on password safety, phishing, and safe browsing." },
                { "what can i ask", "You can ask me about password safety, phishing scams, safe browsing practices, or just general cybersecurity tips. Try asking me something like 'How do I create a strong password?' or 'What is phishing?'" },
                
                // Password safety
                { "password", "Strong passwords are essential! Use a mix of uppercase, lowercase, numbers, and symbols. Avoid using personal information like your name or birthdate. Consider using a password manager to keep track of them securely." },
                { "passphrase", "Passphrases are even better than passwords! A passphrase is a sequence of random words, like 'Purple-Cactus-Dance-2024!'. They're easier to remember but hard for attackers to crack." },
                
                // Phishing
                { "phishing", "Phishing is when attackers send fake emails or messages pretending to be legitimate companies to steal your personal information. Always check the sender's email address, don't click suspicious links, and never share passwords via email." },
                { "suspicious link", "If you receive a suspicious link, don't click it! Hover over the link to see the actual URL. If it looks strange or doesn't match the company name, it's likely a phishing attempt." },
                { "email", "Be cautious with unexpected emails, even if they appear to come from someone you know. Attackers can spoof email addresses. Look for spelling errors, urgent language, and requests for personal information." },
                
                // Safe browsing
                { "safe browsing", "For safe browsing, make sure websites use HTTPS (look for the padlock icon in the address bar), keep your browser updated, avoid downloading files from untrusted sources, and use ad-blockers to reduce risk." },
                { "https", "HTTPS means the connection between your browser and the website is encrypted. Always check for the padlock icon before entering personal information or making online purchases." },
                { "public wifi", "Public Wi-Fi is convenient but risky. Avoid accessing sensitive accounts like banking when on public networks. If you must, use a VPN to encrypt your connection." },
                
                // General tips
                { "2fa", "Two-Factor Authentication (2FA) adds an extra layer of security. Even if someone steals your password, they'd still need your phone or another device to access your account. Enable it wherever possible!" },
                { "update", "Always keep your software updated! Updates often include security patches that fix vulnerabilities attackers could exploit." },
                { "ransomware", "Ransomware is malware that locks your files and demands payment. Back up your important files regularly to an external drive or cloud storage, and never pay the ransom." }
            };
        }

        /// <summary>
        /// Returns a response based on the user's input. Uses keyword matching.
        /// </summary>
        /// <param name="userInput">The user's message.</param>
        /// <returns>A relevant response or a default message.</returns>
        public string GetResponse(string userInput)
        {
            if (string.IsNullOrWhiteSpace(userInput))
            {
                return "I didn't quite understand that. Could you rephrase?";
            }

            string lowerInput = userInput.ToLower();

            // Check for exact or partial keyword matches
            foreach (var keyword in _responses.Keys)
            {
                if (lowerInput.Contains(keyword))
                {
                    return _responses[keyword];
                }
            }

            // Default response for unmatched queries
            return "That's an interesting question! I specialize in cybersecurity topics like password safety, phishing, and safe browsing. Could you ask me something about those areas? Or type 'what can I ask' for more ideas.";
        }
    }
}