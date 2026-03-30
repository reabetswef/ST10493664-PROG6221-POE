# ST10493664-PROG6221-POE
- Cybersecurity Awareness Chatbot (POE Part 1)


## Overview
The Cybersecurity Awareness Chatbot is a .NET 10.0 C# console application developed in Visual Studio 2026. It is designed to educate users on basic cybersecurity principles through an interactive command-line chatbot experience.

The chatbot provides guidance on topics such as password security, phishing scams, safe browsing practices, malware protection, social engineering, data privacy, multi-factor authentication, and general online safety awareness.


## Features
### Core Functionality
- **Interactive console-based chatbot interface** with natural dialogue flow
- **Username personalization** and session-based interaction
- **Voice greeting** on startup (WAV audio playback)
- **Typing animation effect** for bot responses to simulate conversation
- **Input validation** with graceful error handling
- **Exit command** to safely end the session

### Visual Enhancements
- **ASCII art logo** displayed at startup
- **Colored text interface**:
  - Bot messages: Green
  - User messages: Yellow
  - ASCII art: Red
  - Section headers: Magenta
  - Dividers: Dark Gray
  - Error messages: Red
- **Decorative borders and dividers** for structured UI
- **Section headers** to organize conversation flow

### Cybersecurity Topics Covered
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


## Technologies Used
- **C# (.NET 10.0)** - Core programming language
- **Console Application (CLI)** - User interface platform
- **Visual Studio 2026** - Development environment
- **System.Media** - Audio playback for voice greeting
- **Object-Oriented Programming (OOP)** - Code structure with multiple classes


## Project Structure
The application is organized into the following classes for clean code separation:

| Class | Responsibility |
|-------|----------------|
| **Program.cs** | Entry point of the application. Initializes all services and starts the chatbot session. |
| **VoiceService.cs** | Handles playing startup greeting audio (WAV file) with safe fallback if audio file is missing. |
| **AsciiArt.cs** | Responsible for ASCII logo display, section headers, decorative borders, and visual enhancements. |
| **InteractionService.cs** | Manages user interaction including name collection, chat loop, typing animation effect, color formatting, and conversation flow control. |
| **ResponseService.cs** | Generates responses using keyword matching with if-else statements for cybersecurity topics. Handles input validation and exit commands. |


## How It Works
1. **Application Startup**
   - Console title is set to "Cybersecurity Awareness Bot"
   - VoiceService plays voice greeting (if `greeting.wav` exists)
   - AsciiArt displays ASCII art logo in cyan

2. **User Greeting**
   - InteractionService asks for user's name with typing effect
   - Input validation ensures name is not empty
   - Name is capitalized for personalization

3. **Main Chat Loop**
   - InteractionService displays available topics
   - User types questions in natural language
   - ResponseService generates relevant cybersecurity information
   - Conversation continues until user types `exit`

4. **Response System**
   - Uses simple if-else statements for keyword matching
   - Provides specific responses for cybersecurity topics
   - Returns default response for unrecognized queries
   - Handles empty input gracefully

5. **Visual Feedback**
   - InteractionService provides typing animation for conversational feel
   - Color coding distinguishes bot (green) from user (magenta)
   - AsciiArt provides dividers and section headers to organize the interface


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


### To exit the application:
- exit


## Requirements
- **.NET 10.0 SDK** or later
- **Windows OS** (required for System.Media audio playback)
- **Visual Studio 2026** recommended for development
- **greeting.wav** audio file placed in the output directory (optional)


## Setup Instructions
1. **Clone the repository**
2. **Open the project**
- Open Visual Studio 2026
- Open the solution file (`.sln`)
3. **Add audio file (optional)**
- Place `greeting.wav` in the `bin/Debug/net10.0/` folder
- Or set file to "Copy to Output Directory" in properties
4. **Build and run**
- Press `F5` to build and run the application


## GitHub Requirements (POE Submission)
- ✅ Minimum of 6 meaningful commits
- ✅ GitHub Actions CI workflow configured
- ✅ CI workflow passes with green check mark
- ✅ Screenshot of successful CI run in README
- ✅ All source code and multimedia files included


## Notes
- The chatbot uses simple keyword matching with if-else statements for responses (no dictionaries for simplicity)
- Audio playback is optional and will not crash the program if the file is missing
- Typing effect can be adjusted by changing `TypingDelayMs` constant in `InteractionService.cs`
- Color scheme can be customized by changing `ConsoleColor` values
- Designed for educational purposes as part of a programming POE assignment
- All code follows OOP principles with clear separation of concerns


## Author
- **Full Name:** ST10493664
- **Student ID:** ST10493664
- **Module:** PROG6221
- **Project:** POE Part 1 – Cybersecurity Awareness Chatbot
