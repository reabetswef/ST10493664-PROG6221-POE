using System;
using System.Collections.Generic;

namespace CyberSecurityChatbot
{
    class ResponseHandler
    {
        private static Random random = new Random();

        public static string GetResponse(string input)
        {
            input = input.ToLower();

            // Keyword groups
            if (ContainsAny(input, "how are you", "how r u"))
                return GetRandomResponse(new List<string>
                {
                    "I'm running perfectly and ready to help!",
                    "All systems operational!",
                    "I'm great! Thanks for asking."
                });

            if (ContainsAny(input, "purpose", "what do you do"))
                return GetRandomResponse(new List<string>
                {
                    "I help users stay safe online.",
                    "I provide cybersecurity awareness and advice.",
                    "I guide you on how to avoid online threats."
                });

            if (ContainsAny(input, "password", "strong password"))
                return GetRandomResponse(new List<string>
                {
                    "Use at least 12 characters with symbols, numbers, and letters.",
                    "Never reuse passwords across different accounts.",
                    "Consider using a password manager."
                });

            if (ContainsAny(input, "phishing", "scam", "email scam"))
                return GetRandomResponse(new List<string>
                {
                    "Always verify the sender before clicking links.",
                    "Phishing emails often create urgency — be cautious.",
                    "Never share personal info through suspicious messages."
                });

            if (ContainsAny(input, "malware", "virus"))
                return GetRandomResponse(new List<string>
                {
                    "Install antivirus software and keep it updated.",
                    "Avoid downloading files from unknown sources.",
                    "Malware can steal your data — stay alert."
                });

            if (ContainsAny(input, "browsing", "website", "https"))
                return GetRandomResponse(new List<string>
                {
                    "Always check for HTTPS before entering sensitive info.",
                    "Avoid suspicious websites and pop-ups.",
                    "Use trusted browsers and keep them updated."
                });

            if (ContainsAny(input, "wifi", "public wifi"))
                return GetRandomResponse(new List<string>
                {
                    "Avoid sensitive transactions on public Wi-Fi.",
                    "Use a VPN when connected to public networks.",
                    "Public Wi-Fi can be unsafe — be cautious."
                });

            if (ContainsAny(input, "privacy", "data", "information"))
                return GetRandomResponse(new List<string>
                {
                    "Limit what you share online.",
                    "Check your privacy settings regularly.",
                    "Protect your personal data at all times."
                });

            if (ContainsAny(input, "thank", "thanks"))
                return GetRandomResponse(new List<string>
                {
                    "You're welcome!",
                    "Anytime! Stay safe.",
                    "Happy to help!"
                });

            // Email security
            if (ContainsAny(input, "email", "email security"))
                return GetRandomResponse(new List<string>
                {
                    "Be cautious of attachments and unknown senders.",
                    "Always verify emails before clicking links.",
                    "Email scams are common — stay alert."
                });

            // Mobile safety
            if (ContainsAny(input, "mobile", "phone", "device"))
                return GetRandomResponse(new List<string>
                {
                    "Install apps only from trusted stores.",
                    "Keep your phone updated and locked.",
                    "Avoid public charging stations (juice jacking)."
                });

            // Identity theft
            if (ContainsAny(input, "identity", "identity theft"))
                return GetRandomResponse(new List<string>
                {
                    "Never share personal information online.",
                    "Monitor your accounts for suspicious activity.",
                    "Use strong, unique passwords."
                });

            // General cybersecurity
            if (ContainsAny(input, "cybersecurity", "safety", "secure"))
                return GetRandomResponse(new List<string>
                {
                    "Keep software updated and use antivirus protection.",
                    "Avoid suspicious links and downloads.",
                    "Stay informed about new cyber threats."
                });

            return null;
        }

        // 🔍 Check for multiple keywords
        private static bool ContainsAny(string input, params string[] keywords)
        {
            foreach (var keyword in keywords)
            {
                if (input.Contains(keyword))
                    return true;
            }
            return false;
        }

        // 🎲 Random response picker
        private static string GetRandomResponse(List<string> responses)
        {
            int index = random.Next(responses.Count);
            return responses[index];
        }
    }
}