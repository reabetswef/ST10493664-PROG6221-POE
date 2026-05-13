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

        public MainWindow()
        {
            InitializeComponent();
            LoadAsciiArt();
            InitializeServices();

            AddBotMessage("Hello! I'm your Cybersecurity Awareness Assistant. What's your name?");
        }

        private void LoadAsciiArt()
        {
            string asciiArt = @"
╔════════════════════════════════════════════════════════════════════╗
║                                                                    ║
║                                                                    ║
║                   CYBER SECURITY AWARENESS BOT                     ║
║                                                                    ║
║                        Stay Safe Online!                           ║
║                                                                    ║
║                   🔒 🛡️ 🔐 🔑 🔒 🛡️ 🔐 🔑 🔒                   ║
║                                                                    ║
║                                                                    ║
╚════════════════════════════════════════════════════════════════════╝";

            AsciiArtTextBlock.Text = asciiArt;
        }

        private void InitializeServices()
        {
            _responseService = new ResponseService();
            _sentimentService = new SentimentService();
            _memory = new ConversationMemory();
        }

        private void PlayVoiceButton_Click(object sender, RoutedEventArgs e)
        {
            PlayVoiceGreeting();
            AddBotMessage("🔊 Playing greeting message...");
        }

        private void PlayVoiceGreeting()
        {
            try
            {
                string audioPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "greeting.wav");

                if (!File.Exists(audioPath))
                {
                    audioPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "greeting.wav");
                }

                if (File.Exists(audioPath))
                {
                    _soundPlayer?.Dispose();
                    _soundPlayer = new SoundPlayer(audioPath);
                    _soundPlayer.Play();
                }
                else
                {
                    AddBotMessage("(Voice greeting file not found)");
                }
            }
            catch (Exception ex)
            {
                AddBotMessage($"(Audio error: {ex.Message})");
            }
        }

        private void SetNameButton_Click(object sender, RoutedEventArgs e)
        {
            string newName = UserNameBox.Text.Trim();
            if (!string.IsNullOrWhiteSpace(newName))
            {
                _currentUserName = newName;
                _memory.UserName = _currentUserName;

                AddBotMessage($"Nice to meet you, {_currentUserName}! I'm here to help you stay safe online. What would you like to know about cybersecurity?");
                AddQuickTopicSuggestions();
            }
            else
            {
                AddBotMessage("Please enter a valid name.");
            }
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

            string sentiment = _sentimentService.DetectSentiment(userMessage);
            _memory.AddToHistory(userMessage, true);
            string botResponse = _responseService.GetResponse(userMessage, sentiment, _currentUserName, _memory);

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
            // Create a grid for proper icon and message alignment
            Grid messageGrid = new Grid();
            messageGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
            messageGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            // Icon column (fixed width with spacing)
            Border iconBorder = new Border
            {
                Width = 40,
                Height = 40,
                CornerRadius = new CornerRadius(20),
                Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#9B59B6")),
                Margin = new Thickness(0, 0, 15, 0),
                VerticalAlignment = VerticalAlignment.Top
            };

            TextBlock icon = new TextBlock
            {
                Text = "👤",
                FontSize = 22,
                Foreground = Brushes.White,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };
            iconBorder.Child = icon;

            // Message column
            Border messageBorder = new Border
            {
                Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#9B59B6")),
                CornerRadius = new CornerRadius(15),
                Padding = new Thickness(15, 10, 15, 10),
                Margin = new Thickness(0, 0, 20, 5),
                MaxWidth = 500,
                HorizontalAlignment = HorizontalAlignment.Left
            };

            TextBlock messageText = new TextBlock
            {
                Text = message,
                Foreground = Brushes.White,
                FontSize = 14,
                TextWrapping = TextWrapping.Wrap,
                FontFamily = new FontFamily("Segoe UI")
            };
            messageBorder.Child = messageText;

            // Add to grid
            Grid.SetColumn(iconBorder, 0);
            Grid.SetColumn(messageBorder, 1);
            messageGrid.Children.Add(iconBorder);
            messageGrid.Children.Add(messageBorder);

            // Container border
            Border container = new Border
            {
                Margin = new Thickness(10, 5, 50, 5),
                Child = messageGrid
            };

            ChatMessagesPanel.Children.Add(container);
            ScrollToBottom();
        }

        private void AddBotMessage(string message)
        {
            // Remove any asterisks from the message
            string cleanMessage = message.Replace("*", "");

            // Create a grid for proper icon and message alignment
            Grid messageGrid = new Grid();
            messageGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
            messageGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            // Icon column (fixed width with spacing)
            Border iconBorder = new Border
            {
                Width = 40,
                Height = 40,
                CornerRadius = new CornerRadius(20),
                Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#2C2C3E")),
                BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#9B59B6")),
                BorderThickness = new Thickness(1),
                Margin = new Thickness(0, 0, 15, 0),
                VerticalAlignment = VerticalAlignment.Top
            };

            TextBlock icon = new TextBlock
            {
                Text = "🤖",
                FontSize = 22,
                Foreground = Brushes.White,  // White icon
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };
            iconBorder.Child = icon;

            // Message column
            Border messageBorder = new Border
            {
                Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#2C2C3E")),
                CornerRadius = new CornerRadius(15),
                Padding = new Thickness(15, 10, 15, 10),
                BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#9B59B6")),
                BorderThickness = new Thickness(1),
                Margin = new Thickness(0, 0, 20, 5),
                MaxWidth = 550,
                HorizontalAlignment = HorizontalAlignment.Left
            };

            TextBlock messageText = new TextBlock
            {
                Text = cleanMessage,
                Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#D5B4E6")),
                FontSize = 14,
                TextWrapping = TextWrapping.Wrap,
                FontFamily = new FontFamily("Segoe UI")
            };
            messageBorder.Child = messageText;

            // Add to grid
            Grid.SetColumn(iconBorder, 0);
            Grid.SetColumn(messageBorder, 1);
            messageGrid.Children.Add(iconBorder);
            messageGrid.Children.Add(messageBorder);

            // Container border
            Border container = new Border
            {
                Margin = new Thickness(10, 5, 50, 5),
                Child = messageGrid
            };

            ChatMessagesPanel.Children.Add(container);
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

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            _soundPlayer?.Dispose();
        }
    }
}