# ST10493664-PROG6221-POE
Cybersecurity Awareness Chatbot (POE Part 1)

# Overview
The Cybersecurity Awareness Chatbot is a .NET 10.0 C# console application developed in Visual Studio 2022.
It is designed to educate users on basic cybersecurity principles through an interactive command-line chatbot experience.

The chatbot provides guidance on topics such as password security, phishing scams, safe browsing practices, and general online safety awareness.

# Features
- Interactive console-based chatbot interface
- Username personalization and session-based interaction
- Cybersecurity knowledge responses including:
- Password safety and best practices
- Phishing awareness and prevention
- Safe browsing guidelines
- Malware awareness
- General cybersecurity advice
- ASCII-based welcome screen UI
- Typing animation effect for bot responses
- Audio greeting on startup (WAV playback)
- Input validation and fallback responses
- Exit command to safely end the session

# Technologies Used
- C# (.NET 10.0)
- Console Application (CLI)
- Visual Studio 2022
- System.Media (audio playback)
- System.Speech (speech synthesis support)
- Object-Oriented Programming (OOP)

# Project Structure
- The application is structured into the following main components:

# Program.cs
Entry point of the application.
Initializes the UI, plays audio greeting, and starts the chatbot session.

# Chatbot.cs
Handles:
- User input processing
- Response generation logic
- Conversation flow control
- Input validation and exit handling

# UIHelper.cs
Responsible for:
- ASCII welcome screen display
- Console UI formatting
- Typing animation effect
- Visual enhancements

# AudioPlayer.cs
Handles:
- Playing startup greeting audio (WAV file)
- Safe fallback if audio file is missing

# How It Works
- The application starts and displays an ASCII welcome screen.
- A greeting sound is played (if available).
- The user is prompted to enter their name.
- The chatbot begins an interactive session.
- The user can ask cybersecurity-related questions.
- The chatbot responds based on keyword detection.
- The session continues until the user types exit.

# Example Commands
Users can type natural language inputs such as:
- password safety
- phishing scams
- safe browsing
- malware protection
- how are you
- purpose of chatbot
- thank you

# To exit the application:
-exit

# Requirements
- .NET 10.0 SDK
- Windows OS (required for System.Speech and audio playback)
- Visual Studio 2022 recommended

# Notes
- The chatbot uses simple keyword matching for responses.
- Audio playback is optional and will not crash the program if the file is missing.
- Designed for educational purposes as part of a programming POE assignment.

# Author
- Student ID: ST10493664
- Module: PROG6221
- Project: POE Part 1 – Cybersecurity Awareness Chatbot
