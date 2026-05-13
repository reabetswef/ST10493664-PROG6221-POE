using System;
using System.Media;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using System.IO;
using CybersecurityBotWPF.Models;
using CybersecurityBotWPF.Services;

namespace CybersecurityBotWPF
{
    public partial class MainWindow : Window
    {
        private ResponseService _responseService;
        private SentimentService _sentimentService;
        private ConversationMemory _memory;
        private string _currentUserName = "Guest";
        private SoundPlayer _soundPlayer;
        private VoiceService _voiceService;

        public MainWindow()
        {
            InitializeComponent();
            InitializeServices();

            // Play greeting on startup
            PlayVoiceGreeting();

            // Add welcome message
            AddBotMessage("Hello! I'm your Cybersecurity Awareness Assistant. What's your name?");
        }

        private void InitializeServices()
        {
            _responseService = new ResponseService();
            _sentimentService = new SentimentService();
            _memory = new ConversationMemory();
            _voiceService = new VoiceService();
        }

        private void PlayVoiceGreeting()
        {
            try
            {
                string audioPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "greeting.wav");

                // Also check in bin/Debug/netX.X/ folder if not found in Assets
                if (!File.Exists(audioPath))
                {
                    audioPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "greeting.wav");
                }

                if (File.Exists(audioPath))
                {
                    _soundPlayer?.Dispose(); // Dispose old player if exists
                    _soundPlayer = new SoundPlayer(audioPath);
                    _soundPlayer.Play(); // Play asynchronously (non-blocking)
                }
                else
                {
                    AddBotMessage("(Voice greeting file not found - continuing in text mode)");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Audio error: {ex.Message}");
                // Silently fail - audio is optional
            }
        }

        private void SetNameButton_Click(object sender, RoutedEventArgs e)
        {
            string newName = UserNameBox.Text.Trim();
            if (!string.IsNullOrWhiteSpace(newName))
            {
                _currentUserName = newName;
                _memory.UserName = _currentUserName;

                // Play voice greeting when name is set
                PlayVoiceGreeting();

                // Add a slight delay before showing the text response so voice plays first
                DispatcherTimer timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromMilliseconds(1500);
                timer.Tick += (s, ev) =>
                {
                    timer.Stop();
                    AddBotMessage($"Nice to meet you, {_currentUserName}! I'm here to help you stay safe online. What would you like to know about cybersecurity?");
                    AddQuickTopicSuggestions();
                };
                timer.Start();
            }
            else
            {
                AddBotMessage("Please enter a valid name.");
            }
        }

        private void PlayVoiceButton_Click(object sender, RoutedEventArgs e)
        {
            // Play voice greeting when button is clicked
            PlayVoiceGreeting();

            // Add feedback message
            AddBotMessage("🔊 Playing greeting message...");
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            SendUserMessage();
        }

        private void MessageInputBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && !(Keyboard.Modifiers == ModifierKeys.Shift))
            {
                e.Handled = true;
                SendUserMessage();
            }
        }

        private void SendUserMessage()
        {
            string userMessage = MessageInputBox.Text.Trim();
            if (string.IsNullOrWhiteSpace(userMessage))
                return;

            AddUserMessage(userMessage);
            MessageInputBox.Clear();

            // Detect sentiment
            string sentiment = _sentimentService.DetectSentiment(userMessage);

            // Store in memory
            _memory.AddToHistory(userMessage, true);

            // Get response based on sentiment
            string botResponse = _responseService.GetResponse(userMessage, sentiment, _currentUserName, _memory);

            // Add delay for realistic typing effect
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(500);
            timer.Tick += (s, e) =>
            {
                timer.Stop();
                AddBotMessage(botResponse);
                _memory.AddToHistory(botResponse, false);
            };
            timer.Start();
        }

        private void AddUserMessage(string message)
        {
            Border messageBorder = new Border
            {
                Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#E94560")),
                CornerRadius = new CornerRadius(15),
                Margin = new Thickness(50, 5, 10, 5),
                Padding = new Thickness(15, 10, 15, 10)
            };

            StackPanel stackPanel = new StackPanel { Orientation = Orientation.Horizontal };
            TextBlock messageText = new TextBlock
            {
                Text = message,
                Foreground = Brushes.White,
                FontSize = 14,
                TextWrapping = TextWrapping.Wrap,
                FontFamily = new FontFamily("Segoe UI"),
                MaxWidth = 400
            };
            TextBlock icon = new TextBlock
            {
                Text = " 👤",
                FontSize = 20,
                VerticalAlignment = VerticalAlignment.Top
            };

            stackPanel.Children.Add(messageText);
            stackPanel.Children.Add(icon);
            messageBorder.Child = stackPanel;

            ChatMessagesPanel.Children.Add(messageBorder);
            ScrollToBottom();
        }

        private void AddBotMessage(string message)
        {
            Border messageBorder = new Border
            {
                Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#2D2D44")),
                CornerRadius = new CornerRadius(15),
                Margin = new Thickness(10, 5, 50, 5),
                Padding = new Thickness(15, 10, 15, 10)
            };

            StackPanel stackPanel = new StackPanel { Orientation = Orientation.Horizontal };
            TextBlock icon = new TextBlock
            {
                Text = "🤖 ",
                FontSize = 20,
                VerticalAlignment = VerticalAlignment.Top
            };
            TextBlock messageText = new TextBlock
            {
                Text = message,
                Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4ECDC4")),
                FontSize = 14,
                TextWrapping = TextWrapping.Wrap,
                FontFamily = new FontFamily("Segoe UI"),
                MaxWidth = 400
            };

            stackPanel.Children.Add(icon);
            stackPanel.Children.Add(messageText);
            messageBorder.Child = stackPanel;

            ChatMessagesPanel.Children.Add(messageBorder);
            ScrollToBottom();
        }

        private void AddQuickTopicSuggestions()
        {
            AddBotMessage("You can ask me about:\n• Password safety\n• Phishing scams\n• Safe browsing\n• Malware protection\n• Social engineering\n• Data privacy\n• Multi-factor authentication (MFA)\n• Secure backups\n• Identity theft");
        }

        private void QuickTopic_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;
            string topic = clickedButton.Content.ToString();

            // Extract text after the emoji (or use full text if no emoji)
            int spaceIndex = topic.IndexOf(' ');
            string query = spaceIndex > 0 ? topic.Substring(spaceIndex + 1) : topic;

            MessageInputBox.Text = query;
            SendUserMessage();
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            ChatMessagesPanel.Children.Clear();
            MessageInputBox.Clear();
            _memory.ClearHistory();
            AddBotMessage("Chat cleared! How can I help you today?");
        }

        private void ScrollToBottom()
        {
            ChatScrollViewer.ScrollToBottom();
        }

        // Clean up sound player when window closes
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            _soundPlayer?.Dispose();
        }
    }
}