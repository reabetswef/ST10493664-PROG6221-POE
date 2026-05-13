using System;
using System.Collections.Generic;
using CybersecurityBotWPF.Models;

namespace CybersecurityBotWPF.Services
{
    public class ResponseService
    {
        private Dictionary<string, List<string>> _keywordCategories;
        private Random _random;

        // Track last topic discussed for follow-up questions
        private string _lastTopic = "";
        private string _lastDetailedResponse = "";

        // Arrays/Lists for random responses
        private List<string> _passwordTips;
        private List<string> _phishingTips;
        private List<string> _privacyTips;
        private List<string> _browsingTips;
        private List<string> _malwareTips;
        private List<string> _socialTips;
        private List<string> _mfaTips;
        private List<string> _backupTips;
        private List<string> _identityTips;
        private List<string> _updateTips;
        private List<string> _greetingResponses;
        private List<string> _farewellResponses;

        // Detailed explanations for "tell me more" requests
        private Dictionary<string, string> _detailedExplanations;

        public ResponseService()
        {
            _random = new Random();
            InitializeKeywordCategories();
            InitializeRandomResponses();
            InitializeDetailedExplanations();
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

        private void InitializeDetailedExplanations()
        {
            _detailedExplanations = new Dictionary<string, string>
            {
                { "password", "🔐 Let me explain password security in more detail:\n\nWhy are strong passwords important? Hackers use automated tools that can guess millions of passwords per second. A weak password like 'password123' can be cracked instantly, while a strong 12-character password would take centuries to break.\n\nHow to create a strong password:\n• Use a passphrase: Combine 4-6 random words (example: 'Coffee$Tree&Happy@Lamp')\n• Make it at least 12 characters long\n• Never use dictionary words or common patterns\n• Use a different password for every account\n\nPro tip: Password managers like Bitwarden or LastPass generate and store complex passwords for you. You only need to remember ONE master password!" },

                { "phishing", "🎣 Let me dive deeper into phishing scams:\n\nWhat exactly is phishing? It's when cybercriminals send fake messages pretending to be legitimate companies (banks, PayPal, Microsoft, etc.) to trick you into giving away sensitive information.\n\nCommon phishing red flags:\n• Generic greetings like 'Dear Customer' instead of your name\n• Urgent threats like 'Your account will be closed TODAY!'\n• Requests for passwords, OTPs, or credit card details\n• Spelling and grammar mistakes\n• Suspicious sender email addresses\n\nWhat to do if you receive a phishing email:\n1. Don't click any links or download attachments\n2. Report it to the company being impersonated\n3. Delete the email immediately\n4. If you clicked a link, change your passwords and run antivirus scan" },

                { "privacy", "🔒 Here's more about protecting your privacy online:\n\nYour personal data is valuable - companies collect and sell it. Here's how to take control:\n\nSocial Media Privacy:\n• Set profiles to private\n• Don't share your location in real-time\n• Remove personal details from bios (birthdate, phone number, address)\n\nBrowser Privacy:\n• Use private/incognito mode for sensitive searches\n• Install privacy extensions like uBlock Origin\n• Use a VPN to hide your IP address\n\nApp Permissions:\n• Review permissions regularly - revoke unnecessary access\n• A calculator app doesn't need your contacts or camera!" },

                { "mfa", "🔑 Let me explain Multi-Factor Authentication in depth:\n\nHow MFA works: It requires TWO or more verification methods to access your account:\n1. Something you KNOW (password/PIN)\n2. Something you HAVE (phone, security key, authenticator app)\n3. Something you ARE (fingerprint, face ID)\n\nWhy MFA is critical: Even if hackers steal your password, they CAN'T access your account without the second factor. It blocks 99.9% of automated attacks!\n\nHow to set up MFA:\n• Go to account settings on any platform (Google, Facebook, banking)\n• Look for 'Security' or 'Two-Factor Authentication'\n• Choose authenticator app (Google Authenticator, Microsoft Authenticator) - more secure than SMS\n• Save backup codes in a safe place" }
            };
        }

        private void InitializeRandomResponses()
        {
            // Password tips (5 variations)
            _passwordTips = new List<string>
            {
                "🔐 Create passwords that are at least 12 characters long. The longer, the stronger! Mix uppercase, lowercase, numbers, and symbols.",
                "🔐 Never reuse passwords across different accounts. If one gets compromised, all your accounts become vulnerable!",
                "🔐 Consider using a passphrase instead of a password. String together 4 random words like 'Purple-Cactus-Dance-2024' - easier to remember, harder to crack!",
                "🔐 Avoid using personal information like your name, birthday, or pet's name in passwords. Hackers can easily find this info online.",
                "🔐 Use a password manager! It generates and stores complex passwords for you, so you only need to remember one master password."
            };

            // Phishing tips (6 variations)
            _phishingTips = new List<string>
            {
                "🎣 Be cautious of emails asking for personal information. Scammers often disguise themselves as trusted organisations like your bank or Microsoft.",
                "🎣 Always check the sender's email address carefully. Scammers use addresses that look similar to real ones but have small differences like 'arnazon.com' instead of 'amazon.com'.",
                "🎣 Never click on links in suspicious emails. Hover over the link first to see where it really leads. If it looks strange, don't click!",
                "🎣 Look for spelling and grammar mistakes. Legitimate companies proofread their emails, but scammers often rush and make errors.",
                "🎣 Be wary of urgent language like 'Your account will be closed immediately!' Scammers create false urgency to make you act without thinking.",
                "🎣 Remember: No legitimate company will ever ask for your password, OTP, or credit card details via email. Never share this information!"
            };

            // Privacy tips (5 variations)
            _privacyTips = new List<string>
            {
                "🔒 Review your social media privacy settings regularly. Make sure only friends can see your personal posts and information.",
                "🔒 Be careful what you share online! Avoid posting your full address, phone number, or ID number on public platforms.",
                "🔒 Read privacy policies before signing up for apps or services. Many collect and sell your data without you knowing.",
                "🔒 Use privacy-focused browsers like Brave or Firefox with enhanced tracking protection. They block trackers that follow you across websites.",
                "🔒 Limit app permissions on your phone. Does a flashlight app really need access to your contacts and location?"
            };

            // Safe browsing tips (5 variations)
            _browsingTips = new List<string>
            {
                "🌐 Always look for HTTPS and the padlock icon in the address bar before entering any personal information or making payments online.",
                "🌐 Avoid using public Wi-Fi for banking or shopping. If you must use it, always use a VPN to encrypt your connection.",
                "🌐 Keep your browser and extensions updated. Outdated software has known vulnerabilities that hackers can exploit.",
                "🌐 Use ad-blockers to reduce the risk of malicious ads. Cybercriminals sometimes hide malware in legitimate-looking advertisements.",
                "🌐 Clear your browsing history, cache, and cookies regularly. This removes tracking data and reduces your digital footprint."
            };

            // Malware tips (5 variations)
            _malwareTips = new List<string>
            {
                "🛡️ Install reputable antivirus software and keep it updated. Run weekly scans to detect and remove threats early.",
                "🛡️ Never download software from untrusted websites. Stick to official app stores and developer websites.",
                "🛡️ Be extremely careful with email attachments, even from people you know. Their account might have been hacked!",
                "🛡️ Enable ransomware protection if your antivirus offers it. Regular backups are also essential - the 3-2-1 rule!",
                "🛡️ Don't click on pop-up ads claiming your computer is infected. These are usually scams trying to trick you into downloading fake antivirus software."
            };

            // Social engineering tips (5 variations)
            _socialTips = new List<string>
            {
                "🧠 Never give out passwords or OTPs over the phone. Legitimate companies will never ask for this information.",
                "🧠 If someone calls claiming to be from IT support or your bank, hang up and call back using the official number from their website.",
                "🧠 Be suspicious of unexpected messages, even from friends. Their account might have been hacked by attackers sending malicious links.",
                "🧠 Attackers use emotions like fear and urgency to manipulate you. If a message makes you panic, stop and verify through another channel.",
                "🧠 Trust your instincts! If something feels wrong or too good to be true, it probably is. Take a moment to think before acting."
            };

            // MFA tips (5 variations)
            _mfaTips = new List<string>
            {
                "🔑 Enable 2FA on every account that offers it! It's the single most effective way to protect your accounts from unauthorised access.",
                "🔑 Use authenticator apps like Google Authenticator or Microsoft Authenticator instead of SMS. They're more secure and work without phone signal.",
                "🔑 Biometric authentication (fingerprint or face ID) is convenient and secure. Enable it on your phone and laptop for an extra layer of protection.",
                "🔑 Keep backup codes in a safe place. If you lose access to your 2FA device, these codes will save you from being locked out.",
                "🔑 Even if hackers steal your password, they can't access your account without your second factor. That's why MFA is so powerful!"
            };

            // Backup tips (5 variations)
            _backupTips = new List<string>
            {
                "💾 Follow the 3-2-1 backup rule: 3 copies of your data, on 2 different media types, with 1 copy stored off-site.",
                "💾 Set up automatic backups to an external hard drive or cloud service. Manual backups are easy to forget!",
                "💾 Test your backups regularly! A backup is useless if you can't restore from it when you need to.",
                "💾 Don't wait until it's too late. Ransomware attacks can lock your files forever if you don't have backups.",
                "💾 Store important documents, photos, and work files in at least two different places - like OneDrive AND an external drive."
            };

            // Identity theft tips (5 variations)
            _identityTips = new List<string>
            {
                "🆔 Monitor your bank and credit card statements monthly. Report any suspicious transactions immediately.",
                "🆔 Shred documents containing personal information like bank statements, medical records, or ID copies before throwing them away.",
                "🆔 Never share your ID number unless absolutely necessary. Many companies ask for it but don't actually need it.",
                "🆔 Place a fraud alert on your credit profile if you suspect your information has been compromised.",
                "🆔 Be careful what you post on social media. Your full birthdate, address, and vacation plans can be used by identity thieves."
            };

            // Update tips (4 variations)
            _updateTips = new List<string>
            {
                "🔄 Enable automatic updates on your phone, computer, and apps. Updates contain critical security patches!",
                "🔄 Don't ignore update notifications. Hackers actively look for people who don't update their software.",
                "🔄 Update ALL devices, not just your computer. Your router, smart TV, and even your refrigerator can be hacked if not updated.",
                "🔄 Set aside time each week to check for and install updates. Make it part of your cybersecurity routine!"
            };

            // Greeting variations (4 variations)
            _greetingResponses = new List<string>
            {
                "Hello there! 👋 Welcome to the Cybersecurity Awareness Bot. How can I help you stay safe online today?",
                "Hi! 😊 I'm your cybersecurity assistant. Ready to learn about online safety? Ask me anything!",
                "Greetings! 👋 I'm here to help you protect yourself from cyber threats. What would you like to know?",
                "Hey there! 🛡️ Let's talk about cybersecurity. What topic interests you today?"
            };

            // Farewell variations (4 variations)
            _farewellResponses = new List<string>
            {
                "Stay safe out there! Remember to use strong passwords and never click suspicious links. Goodbye! 👋",
                "Thanks for chatting! Keep learning about cybersecurity - it's the best way to protect yourself. Stay safe! 🔒",
                "Remember: Cybersecurity starts with YOU! Come back anytime you have questions. Goodbye! 🛡️",
                "Stay vigilant and keep your digital life secure! Hope to see you again soon. Bye for now! 👋"
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

        private string GetRandomResponse(List<string> responses)
        {
            int index = _random.Next(responses.Count);
            return responses[index];
        }

        private string RecognizeKeywords(string input, string userName, ConversationMemory memory)
        {
            bool askedBefore = memory.HasAskedBefore(input);
            string memoryPrefix = askedBefore ? "As I mentioned earlier, " : "";

            // Follow-up: tell me more
            if (input.Contains("tell me more") || input.Contains("explain more") || input.Contains("more details") || input.Contains("elaborate"))
            {
                if (!string.IsNullOrEmpty(_lastTopic) && _detailedExplanations.ContainsKey(_lastTopic))
                {
                    return _detailedExplanations[_lastTopic];
                }
                else
                {
                    return "I'd love to tell you more! What topic would you like me to explain in detail? Try asking about passwords, phishing, privacy, or MFA!";
                }
            }

            // Follow-up: another tip
            if (input.Contains("another tip") || input.Contains("give me another") || input.Contains("more tips") || input.Contains("another one"))
            {
                if (!string.IsNullOrEmpty(_lastTopic))
                {
                    switch (_lastTopic)
                    {
                        case "password":
                            return GetRandomResponse(_passwordTips);
                        case "phishing":
                            return GetRandomResponse(_phishingTips);
                        case "privacy":
                            return GetRandomResponse(_privacyTips);
                        case "browsing":
                            return GetRandomResponse(_browsingTips);
                        case "malware":
                            return GetRandomResponse(_malwareTips);
                        case "social":
                            return GetRandomResponse(_socialTips);
                        case "mfa":
                            return GetRandomResponse(_mfaTips);
                        case "backup":
                            return GetRandomResponse(_backupTips);
                        case "identity":
                            return GetRandomResponse(_identityTips);
                        case "update":
                            return GetRandomResponse(_updateTips);
                        default:
                            return "Sure! What topic would you like another tip about? Try asking for password tips, phishing tips, or privacy tips!";
                    }
                }
                else
                {
                    return "I'd be happy to give you another tip! First, ask me about a cybersecurity topic like passwords, phishing, or privacy.";
                }
            }

            // Handle confusion
            if (input.Contains("i don't understand") || input.Contains("confused") || input.Contains("unclear"))
            {
                return "I'm sorry you're confused! Let me try to help. Could you tell me which topic you'd like me to explain in simpler terms? Try asking about passwords, phishing, or privacy, and I'll give you an easy-to-understand explanation.";
            }

            // Password Safety
            if (ContainsKeyword(input, "password"))
            {
                _lastTopic = "password";
                _lastDetailedResponse = GetRandomResponse(_passwordTips);
                return memoryPrefix + _lastDetailedResponse + "\n\n💡 Type 'tell me more' for a detailed explanation or 'another tip' for more password advice!";
            }

            // Phishing
            if (ContainsKeyword(input, "phishing"))
            {
                _lastTopic = "phishing";
                _lastDetailedResponse = GetRandomResponse(_phishingTips);
                return memoryPrefix + _lastDetailedResponse + "\n\n💡 Type 'tell me more' for a detailed explanation or 'another tip' for more phishing advice!";
            }

            // Privacy
            if (ContainsKeyword(input, "privacy"))
            {
                _lastTopic = "privacy";
                _lastDetailedResponse = GetRandomResponse(_privacyTips);
                return memoryPrefix + _lastDetailedResponse + "\n\n💡 Type 'tell me more' for a detailed explanation or 'another tip' for more privacy advice!";
            }

            // Browsing
            if (ContainsKeyword(input, "browsing"))
            {
                _lastTopic = "browsing";
                _lastDetailedResponse = GetRandomResponse(_browsingTips);
                return memoryPrefix + _lastDetailedResponse + "\n\n💡 Type 'tell me more' for a detailed explanation or 'another tip' for more browsing advice!";
            }

            // Malware
            if (ContainsKeyword(input, "malware"))
            {
                _lastTopic = "malware";
                _lastDetailedResponse = GetRandomResponse(_malwareTips);
                return memoryPrefix + _lastDetailedResponse + "\n\n💡 Type 'tell me more' for a detailed explanation or 'another tip' for more malware advice!";
            }

            // Social Engineering
            if (ContainsKeyword(input, "social"))
            {
                _lastTopic = "social";
                _lastDetailedResponse = GetRandomResponse(_socialTips);
                return memoryPrefix + _lastDetailedResponse + "\n\n💡 Type 'tell me more' for a detailed explanation or 'another tip' for more social engineering advice!";
            }

            // MFA
            if (ContainsKeyword(input, "mfa"))
            {
                _lastTopic = "mfa";
                _lastDetailedResponse = GetRandomResponse(_mfaTips);
                return memoryPrefix + _lastDetailedResponse + "\n\n💡 Type 'tell me more' for a detailed explanation or 'another tip' for more MFA advice!";
            }

            // Backup
            if (ContainsKeyword(input, "backup"))
            {
                _lastTopic = "backup";
                _lastDetailedResponse = GetRandomResponse(_backupTips);
                return memoryPrefix + _lastDetailedResponse + "\n\n💡 Type 'tell me more' for a detailed explanation or 'another tip' for more backup advice!";
            }

            // Identity
            if (ContainsKeyword(input, "identity"))
            {
                _lastTopic = "identity";
                _lastDetailedResponse = GetRandomResponse(_identityTips);
                return memoryPrefix + _lastDetailedResponse + "\n\n💡 Type 'tell me more' for a detailed explanation or 'another tip' for more identity theft advice!";
            }

            // Update
            if (ContainsKeyword(input, "update"))
            {
                _lastTopic = "update";
                _lastDetailedResponse = GetRandomResponse(_updateTips);
                return memoryPrefix + _lastDetailedResponse + "\n\n💡 Type 'tell me more' for a detailed explanation or 'another tip' for more update advice!";
            }

            // How are you
            if (input.Contains("how are you") || input.Contains("how are u"))
            {
                return $"I'm doing great, {userName}! Thanks for asking. How can I help you with cybersecurity today?";
            }

            // Purpose
            if (input.Contains("what is your purpose") || input.Contains("what do you do") || input.Contains("what can you do"))
            {
                return $"My purpose is to educate and empower people like you, {userName}, to stay safe online! I can help with passwords, phishing, privacy, safe browsing, malware, MFA, backups, identity theft, and more.\n\n💡 After I give you a tip, you can ask me 'tell me more' or 'another tip' to continue the conversation!";
            }

            // Thanks
            if (input.Contains("thank you") || input.Contains("thanks") || input.Contains("thank"))
            {
                return $"You're very welcome, {userName}! 😊 I'm glad I could help. Stay safe online!";
            }

            // Hello/Hi
            if (input.Contains("hello") || input.Contains("hi") || input.Contains("hey"))
            {
                _lastTopic = "";
                return GetRandomResponse(_greetingResponses);
            }

            // Goodbye
            if (input.Contains("goodbye") || input.Contains("bye") || input.Contains("see you"))
            {
                return GetRandomResponse(_farewellResponses);
            }

            // Help
            if (input.Contains("what can i ask") || input.Contains("help") || input.Contains("topics"))
            {
                return $"📚 Topics I can help with, {userName}:\n\n🔐 Password Safety\n🎣 Phishing & Scams\n🔒 Data Privacy\n🌐 Safe Browsing\n🛡️ Malware Protection\n🧠 Social Engineering\n🔑 MFA/2FA\n💾 Secure Backups\n🆔 Identity Theft\n🔄 Software Updates\n\n💡 Try asking about any of these topics! After I respond, say 'tell me more' or 'another tip'!";
            }

            // Default
            List<string> defaultResponses = new List<string>
            {
                $"That's an interesting question, {userName}! 🤔 I specialize in cybersecurity topics. Try asking me about passwords, phishing, privacy, or type 'help' to see all topics!",
                $"Great question, {userName}! 💭 I can help with password safety, phishing scams, privacy protection, and more. What would you like to learn about?",
                $"I love your curiosity, {userName}! 🌟 Why not ask me about MFA, secure backups, or identity theft? I have lots of tips to share!",
                $"Thanks for asking, {userName}! 🙏 I know about 10+ cybersecurity topics. Try typing 'password tips' or 'phishing advice' to get started!"
            };

            return GetRandomResponse(defaultResponses);
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