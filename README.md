# ST10493664-PROG6221-POE
## Cybersecurity Awareness Chatbot (POE Part 2 - WPF GUI Application)

---

## Overview
The Cybersecurity Awareness Chatbot is a .NET 10.0 WPF (Windows Presentation Foundation) desktop application developed in Visual Studio 2022. It is designed to educate users on basic cybersecurity principles through an engaging graphical user interface with voice interaction, sentiment detection, and conversational memory.

The chatbot provides guidance on topics such as password security, phishing scams, safe browsing practices, malware protection, social engineering, data privacy, multi-factor authentication, secure backups, identity theft prevention, and general online safety awareness. The application has been upgraded from a console application to a modern WPF interface with enhanced features for Part 2 of the POE.

---

## Features
### Core Functionality
- **Modern WPF graphical user interface** with custom color scheme (White & Purple theme)
- **Username personalization** with persistent session memory
- **Voice greeting** on demand (WAV audio playback via button click)
- **Typing effect simulation** for bot responses
- **Input validation** with graceful error handling
- **Exit command** to safely end the session
- **Quick topic buttons** for easy access to cybersecurity topics

### Visual Enhancements
- **ASCII art logo** displayed in header using fixed-width font (Consolas)
- **Modern color scheme**:
  - Bot messages: Light Purple (#D5B4E6) on dark background with purple border
  - User messages: White text on Purple (#9B59B6) background
  - ASCII art: Light Purple (#D5B4E6)
  - Section headers: Purple (#9B59B6)
  - Send button: Purple (#9B59B6)
  - Clear button: Red (#E74C3C)
- **Icon-based message layout** with dedicated icon column (🤖 for bot, 👤 for user)
- **Rounded corners and modern borders** for professional appearance

### Cybersecurity Topics Covered (10+ Topics)
The chatbot responds to questions about:
- **Password safety** - Strong passwords and passphrases
- **Phishing scams** - Email safety and suspicious links
- **Safe browsing** - HTTPS, public Wi-Fi, browser security
- **Malware protection** - Viruses, antivirus software
- **Social engineering** - Manipulation tactics and scam awareness
- **Data privacy** - Personal information protection
- **Multi-factor authentication (MFA/2FA)** - Extra security layers
- **Secure backups** - 3-2-1 backup rule
- **Identity theft** - Prevention and monitoring
- **Ransomware** - Protection and recovery
- **Software updates** - Importance of patching

### Enhanced Features (Part 2)
#### 1. Keyword Recognition
- Recognizes 10+ cybersecurity keywords using dictionary-based categorization
- Provides immediate, relevant responses without requiring rephrasing
- Categories include password, phishing, privacy, browsing, malware, social engineering, MFA, backup, identity, and updates

#### 2. Random Responses
- Multiple response variations (4-6 per topic) using List<string> collections
- Random selection creates varied, engaging conversations
- Prevents repetitive answers for repeated questions

#### 3. Conversation Flow
- Handles follow-up questions: "tell me more", "another tip", "explain more"
- Maintains context across conversation turns
- Provides detailed explanations on demand

#### 4. Memory and Recall
- Stores user's favorite cybersecurity topic
- Tracks number of tips given during session
- Recalls user preferences with "what do you remember about me"
- Personalizes greetings based on past interests

#### 5. Sentiment Detection
- Detects 5 emotional states: worried, frustrated, curious, excited, sad
- Provides empathetic responses with encouraging follow-ups
- Adjusts response tone based on user's mood
- Gives immediate tips without requiring additional prompts

#### 6. Code Optimisation
- Dictionaries for keyword categorization
- Lists/arrays for random response storage
- Random class for varied output selection
- Clean OOP structure with 5 specialized classes
- Ready for further expansion in Part 3

---

## Technologies Used
- **C# (.NET 8.0)** - Core programming language
- **WPF (Windows Presentation Foundation)** - GUI framework
- **XAML** - User interface markup language
- **Visual Studio 2022** - Development environment
- **System.Media** - Audio playback for voice greeting
- **Object-Oriented Programming (OOP)** - Code structure with multiple classes
- **Generic Collections** - Dictionaries and Lists for data management

---

## Project Structure
The application is organized into the following classes for clean code separation:

| Class | Responsibility |
|-------|----------------|
| **MainWindow.xaml** | GUI layout with modern white/purple theme, ASCII art header, chat message panel, quick topic buttons, and input area |
| **MainWindow.xaml.cs** | Code-behind handling UI events, message display, voice playback coordination, and chat flow management |
| **ResponseService.cs** | Manages keyword recognition, random response selection, follow-up handling, and topic-based replies using dictionaries and lists |
| **SentimentService.cs** | Detects user emotions (worried, frustrated, curious, excited, sad) and generates empathetic response prefixes |
| **ConversationMemory.cs** | Stores user preferences (favorite topic, security concerns), tracks conversation history, and provides personalized recall |
| **VoiceService.cs** | Handles WAV audio playback on demand with safe fallback if file is missing |

---

## How It Works
1. **Application Startup**
   - Window loads with purple/white theme
   - ASCII art logo displays in fixed-width font
   - Welcome message appears asking for user's name

2. **User Greeting**
   - User enters name and clicks "Set Name"
   - Bot personalizes all future responses
   - Voice greeting available via "Play Greeting" button

3. **Main Chat Loop**
   - User types questions or clicks quick topic buttons
   - Sentiment analysis detects user's emotional state
   - Keyword recognition identifies cybersecurity topic
   - Random response selected from appropriate list
   - Response displayed with empathetic prefix if needed
   - Follow-ups handled with "tell me more" or "another tip"

4. **Response System**
   - Uses Dictionary<string, List<string>> for keyword categorization
   - 10+ List<string> collections for random response storage
   - Random class ensures varied, non-repetitive answers
   - Memory system stores and recalls user preferences

5. **Visual Feedback**
   - Icon-based layout (🤖 bot, 👤 user) with dedicated columns
   - Rounded message bubbles with color coding
   - Auto-scrolling chat panel
   - Typing effect simulation for realism

---

## Example Commands

Users can type natural language inputs such as:
- `password safety` or `how to create strong password`
- `phishing` or `what is phishing`
- `safe browsing` or `https`
- `malware` or `virus protection`
- `social engineering` or `scam`
- `data privacy` or `privacy`
- `2fa` or `mfa` or `multi-factor authentication`
- `backup` or `backups`
- `identity theft`
- `ransomware`
- `how are you`
- `purpose` or `what is your purpose`
- `what can i ask`
- `tell me more` (follow-up after a tip)
- `another tip` (get another random tip on same topic)
- `what do you remember about me` (recall stored preferences)
- `I'm interested in privacy` (store favorite topic)

### To exit the application:
- Close the window or type `goodbye` / `bye`

---

## Requirements
- **.NET 10.0 SDK** or later
- **Windows OS** (required for WPF and System.Media audio playback)
- **Visual Studio 2022** recommended for development
- **greeting.wav** audio file placed in the `Assets` folder (optional)

---

## GitHub Requirements (POE Submission)
- ✅ Minimum of 6 meaningful commits
- ✅ GitHub Actions CI workflow configured
- ✅ CI workflow passes with green check mark
- ✅ Screenshot of successful CI run in README
- ✅ All source code and multimedia files included

---

## Notes
- The chatbot uses dictionary-based keyword matching with list collections for random responses
- Audio playback is optional and will not crash the program if the file is missing
- Sentiment detection enhances user experience with empathetic responses
- Memory system stores preferences within the current session
- Color scheme uses White (#FFFFFF) and Purple (#9B59B6) as primary colors
- Designed for educational purposes as part of a programming POE assignment
- All code follows OOP principles with clear separation of concerns
- Code is optimised for further expansion in Part 3

---

## Author
- **Full Name:** Reabetswe Tebogo Fafudi
- **Student ID:** ST10493664
- **Module:** PROG6221
- **Project:** POE Part 2 – Cybersecurity Awareness Chatbot (WPF GUI Application)
