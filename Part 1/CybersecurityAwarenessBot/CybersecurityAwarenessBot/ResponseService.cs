//ST10493664 PROG6221 POE - Part 1 - Cybersecurity Awareness Bot
using System;

namespace CybersecurityAwarenessBot
{
    // Manages responses to user queries using simple conditional statements.
    public class ResponseService
    {
        // Returns a response based on the user's input using simple if-else logic.
        public string GetResponse(string userInput)
        {
            if (string.IsNullOrWhiteSpace(userInput))
            {
                return "I didn't quite understand that. Could you rephrase?";
            }

            string input = userInput.ToLower();

            // Greetings and personal questions
            if (input.Contains("how are you"))
            {
                return "I'm doing well, thank you for asking! I'm here and ready to help you learn about cybersecurity.";
            }

            if (input.Contains("purpose") || input.Contains("what is your purpose"))
            {
                return "My purpose is to educate and raise awareness about cybersecurity threats. " +
                    "\nI want to help you stay safe online by providing " +
                    "\ntips on password safety, phishing, and safe browsing.";
            }

            if (input.Contains("what can i ask") || input.Contains("what can you help"))
            {
                return "You can ask me about password safety, phishing scams, safe browsing, malware " +
                    "\nprotection, social engineering, data privacy, multi-factor authentication, " +
                    "\nbackups, identity theft, or just general cybersecurity tips!";
            }

            // Password safety
            if (input.Contains("password"))
            {
                return "Strong passwords are essential! Use a mix of uppercase, lowercase, numbers, " +
                    "\nand symbols. Avoid using personal information like your name or birthdate. " +
                    "\nConsider using a password manager to keep track of them securely.";
            }

            if (input.Contains("passphrase"))
            {
                return "Passphrases are even better than passwords! A passphrase is a sequence of random " +
                    "\nwords, like 'Purple-Cactus-Dance-2024!'. They're easier to remember but hard for attackers to crack.";
            }

            // Phishing
            if (input.Contains("phishing"))
            {
                return "Phishing is when attackers send fake emails or messages pretending to be legitimate companies " +
                    "\nto steal your personal information. Always check the sender's email address, " +
                    "\ndon't click suspicious links, and never share passwords via email.";
            }

            if (input.Contains("suspicious link") || input.Contains("click link"))
            {
                return "If you receive a suspicious link, don't click it! Hover over the link to see the actual URL. " +
                    "\nIf it looks strange or doesn't match the company name, it's likely a phishing attempt.";
            }

            if (input.Contains("email") && (input.Contains("scam") || input.Contains("fake")))
            {
                return "Be cautious with unexpected emails, even if they appear to come from someone you know. " +
                    "\nAttackers can spoof email addresses. Look for spelling errors, urgent language, " +
                    "\nand requests for personal information.";
            }

            // Safe browsing
            if (input.Contains("safe browsing") || input.Contains("browse safely"))
            {
                return "For safe browsing, make sure websites use HTTPS (look for the padlock icon in the address bar), " +
                    "\nkeep your browser updated, avoid downloading files from untrusted sources, and use ad-blockers to reduce risk.";
            }

            if (input.Contains("https"))
            {
                return "HTTPS means the connection between your browser and the website is encrypted. " +
                    "\nAlways check for the padlock icon before entering personal information or making online purchases.";
            }

            if (input.Contains("public wifi") || input.Contains("wi-fi"))
            {
                return "Public Wi-Fi is convenient but risky. Avoid accessing sensitive accounts " +
                    "\nlike banking when on public networks. If you must, use a VPN to encrypt your connection.";
            }

            // Malware and Viruses
            if (input.Contains("malware"))
            {
                return "Malware is malicious software designed to harm your computer or steal your data. " +
                    "\nTypes include viruses, worms, trojans, and spyware. Protect yourself by keeping " +
                    "\nyour antivirus software updated, avoiding suspicious downloads, and not clicking on pop-up ads.";
            }

            if (input.Contains("virus"))
            {
                return "A computer virus spreads by attaching itself to legitimate programs or files. " +
                    "\nThey can corrupt your data, slow down your system, or steal personal information. " +
                    "\nAlways use reputable antivirus software and be careful when downloading files.";
            }

            if (input.Contains("antivirus"))
            {
                return "Antivirus software is your first line of defense against malware! It scans files " +
                    "\nand programs for known threats and can quarantine or remove infected files. " +
                    "\nMake sure to keep it updated and run regular scans.";
            }

            // Social Engineering
            if (input.Contains("social engineering"))
            {
                return "Social engineering is when attackers manipulate people into giving up " +
                    "\nconfidential information. They might pretend to be IT support, a bank " +
                    "\nrepresentative, or even a friend. Always verify who you're talking to before sharing sensitive information.";
            }

            if (input.Contains("scam"))
            {
                return "Scams come in many forms - phone calls claiming you owe money, fake lottery winnings, " +
                    "\nor romance scams. If something sounds too good to be true, it probably is! Never " +
                    "\nsend money or personal information to someone you haven't met in person.";
            }

            // Data Privacy
            if (input.Contains("data privacy") || input.Contains("privacy"))
            {
                return "Data privacy is about controlling how your personal information is collected, " +
                    "\nused, and shared. Tips: review privacy settings on social media, be careful \n" +
                    "what you post online, and read privacy policies before signing up for services.";
            }

            // Multi-Factor Authentication
            if (input.Contains("mfa") || input.Contains("2fa") || input.Contains("two factor") || input.Contains("multi factor"))
            {
                return "Multi-Factor Authentication (MFA) requires two or more verification methods \n" +
                    "to access your account. This could be something you know (password), something you " +
                    "\nhave (phone), or something you are (fingerprint). Enable it on all accounts that offer it!";
            }

            // Secure Backups
            if (input.Contains("backup") || input.Contains("back up"))
            {
                return "Regular backups are your safety net! If your device gets infected with " +
                    "\nransomware, damaged, or stolen, backups ensure you don't lose important files. " +
                    "\nFollow the 3-2-1 rule: keep 3 copies of your data, on 2 different media types, with 1 copy stored off-site.";
            }

            // Identity Theft
            if (input.Contains("identity theft") || input.Contains("identity"))
            {
                return "Identity theft happens when someone steals your personal information to commit fraud. " +
                    "\nProtect yourself by monitoring your credit reports, using strong unique passwords, " +
                    "\nshredding sensitive documents, and being cautious about sharing your ID number online.";
            }

            // General tips
            if (input.Contains("update") || input.Contains("software update"))
            {
                return "Always keep your software updated! Updates often include security patches that fix " +
                    "\nvulnerabilities attackers could exploit. Enable automatic updates when possible.";
            }

            if (input.Contains("ransomware"))
            {
                return "Ransomware is malware that locks your files and demands payment. Back up " +
                    "\nyour important files regularly and never pay the ransom. Paying doesn't guarantee you'll get your files back.";
            }

            // Default response
            return "I didn't get that! I specialize in cybersecurity topics like password " +
                "\nsafety, phishing, safe browsing, malware protection, etc...";
        }
    }
}