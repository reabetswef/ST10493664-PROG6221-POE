using System;
using System.Collections.Generic;
using CybersecurityBotWPF.Models;

namespace CybersecurityBotWPF.Services
{
    public class ResponseService
    {
        private Dictionary<string, List<string>> _keywordCategories;

        public ResponseService()
        {
            InitializeKeywordCategories();
        }

        private void InitializeKeywordCategories()
        {
            _keywordCategories = new Dictionary<string, List<string>>
            {
                { "password", new List<string> { "password", "passphrase", "strong password", "password manager", "password safety", "password security" } },
                { "phishing", new List<string> { "phishing", "scam", "fake email", "suspicious link", "fraud", "impersonation" } },
                { "privacy", new List<string> { "privacy", "data privacy", "personal information", "private data", "confidential" } },
                { "browsing", new List<string> { "safe browsing", "https", "secure website", "browser security", "padlock" } },
                { "malware", new List<string> { "malware", "virus", "ransomware", "trojan", "spyware", "worm" } },
                { "social", new List<string> { "social engineering", "manipulation", "trust attack", "human hacking" } },
                { "mfa", new List<string> { "mfa", "2fa", "multi factor", "two factor", "authentication" } },
                { "backup", new List<string> { "backup", "back up", "data recovery", "file copy" } },
                { "identity", new List<string> { "identity theft", "identity fraud", "id theft", "stolen identity" } },
                { "update", new List<string> { "update", "software update", "patch", "security update" } }
            };
        }

        public string GetResponse(string userInput, string sentiment, string userName, ConversationMemory memory)
        {
            if (string.IsNullOrWhiteSpace(userInput))
            {
                return "I didn't quite understand that. Could you rephrase?";
            }

            string input = userInput.ToLower();

            string sentimentPrefix = "";
            if (sentiment == "negative")
            {
                sentimentPrefix = "I'm sorry you're feeling that way. ";
            }
            else if (sentiment == "excited")
            {
                sentimentPrefix = "That's great energy! ";
            }

            string response = RecognizeKeywords(input, userName, memory);

            return sentimentPrefix + response;
        }

        private string RecognizeKeywords(string input, string userName, ConversationMemory memory)
        {
            bool askedBefore = memory.HasAskedBefore(input);
            string memoryPrefix = askedBefore ? "As I mentioned earlier, " : "";

            // Password Safety
            if (ContainsKeyword(input, "password"))
            {
                return $"{memoryPrefix}🔐 Password Safety Tips:\n\n" +
                       $"• Use strong, unique passwords for each account (at least 12 characters with uppercase, lowercase, numbers, and symbols)\n" +
                       $"• Never use personal information like your name, birthday, or ID number\n" +
                       $"• Consider using a password manager to store and generate complex passwords\n" +
                       $"• Enable two-factor authentication whenever possible\n" +
                       $"• Change your passwords immediately if you suspect a breach\n\n" +
                       $"Stay secure, {userName}!";
            }

            // Phishing & Scams
            if (ContainsKeyword(input, "phishing"))
            {
                return $"{memoryPrefix}🎣 How to Spot Phishing Scams:\n\n" +
                       $"• Check the sender's email address carefully - scammers use fake addresses similar to real ones\n" +
                       $"• Never click on suspicious links - hover to see the actual URL first\n" +
                       $"• Look for spelling and grammar mistakes - legitimate companies proofread their emails\n" +
                       $"• Be wary of urgent language demanding immediate action\n" +
                       $"• Legitimate companies never ask for passwords or personal info via email\n\n" +
                       $"When in doubt, contact the company directly through their official website!";
            }

            // Privacy
            if (ContainsKeyword(input, "privacy"))
            {
                return $"{memoryPrefix}🔒 Data Privacy Protection:\n\n" +
                       $"• Review privacy settings on all social media platforms\n" +
                       $"• Be careful what personal information you share online (address, phone number, ID)\n" +
                       $"• Read privacy policies before signing up for services\n" +
                       $"• Use privacy-focused browsers or search engines\n" +
                       $"• Limit app permissions - does a flashlight need access to your contacts?\n" +
                       $"• Regularly clear your browsing history and cookies\n\n" +
                       $"Your data is valuable - protect it, {userName}!";
            }

            // Safe Browsing
            if (ContainsKeyword(input, "browsing"))
            {
                return $"{memoryPrefix}🌐 Safe Browsing Practices:\n\n" +
                       $"• Always look for HTTPS and the padlock icon in the address bar\n" +
                       $"• Avoid using public Wi-Fi for banking or sensitive transactions\n" +
                       $"• Keep your browser and extensions updated\n" +
                       $"• Use ad-blockers to reduce risk from malicious ads\n" +
                       $"• Don't download files from untrusted sources\n" +
                       $"• Clear your cache and cookies regularly\n\n" +
                       $"Browse safely, {userName}!";
            }

            // Malware
            if (ContainsKeyword(input, "malware"))
            {
                return $"{memoryPrefix}🛡️ Malware Protection Guide:\n\n" +
                       $"• Install and regularly update reputable antivirus software\n" +
                       $"• Run weekly system scans to detect threats early\n" +
                       $"• Never open email attachments from unknown senders\n" +
                       $"• Avoid clicking on pop-up ads or suspicious links\n" +
                       $"• Keep your operating system and all software updated\n" +
                       $"• Be careful when downloading free software or cracks\n\n" +
                       $"Types of malware include: viruses, ransomware, spyware, trojans, and worms.";
            }

            // Social Engineering
            if (ContainsKeyword(input, "social"))
            {
                return $"{memoryPrefix}🧠 Social Engineering Awareness:\n\n" +
                       $"• Attackers manipulate people, not computers, to get information\n" +
                       $"• Common tactics: pretending to be IT support, bank reps, or even friends\n" +
                       $"• Always verify identity before sharing sensitive information\n" +
                       $"• Be suspicious of unsolicited calls, emails, or messages\n" +
                       $"• Never give out passwords or OTPs over the phone\n" +
                       $"• If something feels wrong, trust your instincts and hang up\n\n" +
                       $"Remember: Legitimate organizations won't demand immediate action!";
            }

            // MFA/2FA
            if (ContainsKeyword(input, "mfa"))
            {
                return $"{memoryPrefix}🔑 Multi-Factor Authentication (MFA/2FA):\n\n" +
                       $"• MFA requires TWO or more verification methods to access your account\n" +
                       $"• Types: something you know (password), something you have (phone), something you are (fingerprint)\n" +
                       $"• Even if someone steals your password, they can't access your account without the second factor\n" +
                       $"• Enable MFA on all accounts that offer it - email, banking, social media\n" +
                       $"• Use authenticator apps (Google Authenticator, Microsoft Authenticator) instead of SMS when possible\n\n" +
                       $"This is one of the BEST ways to protect your accounts, {userName}!";
            }

            // Backups
            if (ContainsKeyword(input, "backup"))
            {
                return $"{memoryPrefix}💾 The 3-2-1 Backup Rule:\n\n" +
                       $"• Keep 3 copies of your important data\n" +
                       $"• Store on 2 different types of media (external drive + cloud)\n" +
                       $"• Keep 1 copy off-site (cloud storage or different location)\n\n" +
                       $"Why backups matter:\n" +
                       $"• Protection against ransomware attacks\n" +
                       $"• Recovery from hardware failure or theft\n" +
                       $"• Peace of mind knowing your photos and documents are safe\n\n" +
                       $"Set up automatic backups today - don't wait until it's too late!";
            }

            // Identity Theft
            if (ContainsKeyword(input, "identity"))
            {
                return $"{memoryPrefix}🆔 Identity Theft Prevention:\n\n" +
                       $"• Monitor your bank and credit card statements regularly\n" +
                       $"• Shred documents containing personal information before discarding\n" +
                       $"• Never share your ID number unless absolutely necessary\n" +
                       $"• Use strong, unique passwords for financial accounts\n" +
                       $"• Be cautious on social media - don't post your full birthdate or address\n" +
                       $"• Consider credit monitoring services if available in South Africa\n\n" +
                       $"Report suspicious activity to your bank and the SAPS immediately!";
            }

            // Software Updates
            if (ContainsKeyword(input, "update"))
            {
                return $"{memoryPrefix}🔄 Why Software Updates Matter:\n\n" +
                       $"• Updates fix security vulnerabilities that hackers exploit\n" +
                       $"• Enable automatic updates whenever possible\n" +
                       $"• Don't ignore update notifications - they protect you!\n" +
                       $"• Update ALL devices: computer, phone, tablet, and even smart devices\n" +
                       $"• Outdated software is one of the most common ways hackers gain access\n\n" +
                       $"Stay updated, stay protected, {userName}!";
            }

            // Greetings
            if (input.Contains("how are you") || input.Contains("how are u"))
            {
                return $"I'm doing great, {userName}! Thanks for asking. I'm fully charged and ready to help you learn about cybersecurity. How can I assist you today?";
            }

            if (input.Contains("what is your purpose") || input.Contains("what do you do") || input.Contains("what can you do"))
            {
                return $"My purpose is to educate and empower people like you, {userName}, to stay safe online! I can help with:\n\n" +
                       $"• Creating strong passwords 🔐\n" +
                       $"• Spotting phishing scams 🎣\n" +
                       $"• Protecting your privacy 🔒\n" +
                       $"• Safe browsing habits 🌐\n" +
                       $"• Malware prevention 🛡️\n" +
                       $"• Multi-factor authentication 🔑\n" +
                       $"• And much more! Just ask me about any cybersecurity topic.";
            }

            if (input.Contains("thank you") || input.Contains("thanks") || input.Contains("thank"))
            {
                return $"You're very welcome, {userName}! 😊 I'm glad I could help. Remember, cybersecurity starts with YOU. Stay safe and come back anytime you have questions!";
            }

            if (input.Contains("hello") || input.Contains("hi") || input.Contains("hey"))
            {
                return $"Hello there, {userName}! 👋 Welcome to the Cybersecurity Awareness Bot. What would you like to learn about today? Try asking me about passwords, phishing, or privacy!";
            }

            // Help
            if (input.Contains("what can i ask") || input.Contains("help") || input.Contains("topics"))
            {
                return $"📚 Topics I can help with, {userName}:\n\n" +
                       $"🔐 Password Safety\n" +
                       $"🎣 Phishing & Scams\n" +
                       $"🔒 Data Privacy\n" +
                       $"🌐 Safe Browsing\n" +
                       $"🛡️ Malware Protection\n" +
                       $"🧠 Social Engineering\n" +
                       $"🔑 Multi-Factor Authentication (MFA)\n" +
                       $"💾 Secure Backups\n" +
                       $"🆔 Identity Theft\n" +
                       $"🔄 Software Updates\n\n" +
                       $"Just type any of these topics and I'll give you detailed tips!";
            }

            // Default
            return $"That's an interesting question, {userName}! 🤔\n\n" +
                   $"I specialize in cybersecurity topics like:\n" +
                   $"• Password safety\n" +
                   $"• Phishing scams\n" +
                   $"• Data privacy\n" +
                   $"• Safe browsing\n" +
                   $"• Malware protection\n" +
                   $"• Social engineering\n" +
                   $"• Multi-factor authentication (MFA)\n" +
                   $"• Secure backups\n" +
                   $"• Identity theft\n\n" +
                   $"Could you ask me about one of these areas? Or type 'help' to see all topics!";
        }

        private bool ContainsKeyword(string input, string category)
        {
            if (_keywordCategories.ContainsKey(category))
            {
                foreach (string keyword in _keywordCategories[category])
                {
                    if (input.Contains(keyword))
                        return true;
                }
            }
            return false;
        }
    }
}