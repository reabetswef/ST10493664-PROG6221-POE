using System;
using System.Media;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using System.IO;
using System.Threading.Tasks;
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
        private bool _isTyping = false;

        public MainWindow()
        {
            InitializeComponent();
            LoadAsciiArt();
            InitializeServices();

            // Welcome message with typing effect
            AddBotMessageWithTyping("Hello! I'm your Cybersecurity Awareness Assistant. What's your name?");
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
            AddBotMessageWithTyping("🔊 Playing greeting message...");
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
                    AddBotMessageWithTyping("(Voice greeting file not found)");
                }
            }
            catch (Exception ex)
            {
                AddBotMessageWithTyping($"(Audio error: {ex.Message})");
            }
        }

        private void SetNameButton_Click(object sender, RoutedEventArgs e)
        {
            string newName = UserNameBox.Text.Trim();
            if (!string.IsNullOrWhiteSpace(newName))
            {
                _currentUserName = newName;
                _memory.UserName = _currentUserName;

                AddBotMessageWithTyping($"Nice to meet you, {_currentUserName}! I'm here to help you stay safe online. What would you like to know about cybersecurity?");

                // Add quick topics after a short delay
                DispatcherTimer timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromMilliseconds(2000);
                timer.Tick += (s, ev) =>
                {
                    timer.Stop();
                    AddQuickTopicSuggestions();
                };
                timer.Start();
            }
            else
            {
                AddBotMessageWithTyping("Please enter a valid name.");
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

        private async void SendUserMessage()
        {
            if (_isTyping) return; // Don't allow input while bot is typing

            string userMessage = MessageInputBox.Text.Trim();
            if (string.IsNullOrWhiteSpace(userMessage))
                return;

            AddUserMessage(userMessage);
            MessageInputBox.Clear();

            string sentiment = _sentimentService.DetectSentiment(userMessage);
            _memory.AddToHistory(userMessage, true);
            string botResponse = _responseService.GetResponse(userMessage, sentiment, _currentUserName, _memory);

            // Add typing effect for bot response
            await AddBotMessageWithTypingAsync(botResponse);
            _memory.AddToHistory(botResponse, false);
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

        // Regular bot message without typing effect (for quick responses)
        private void AddBotMessage(string message)
        {
            string cleanMessage = message.Replace("*", "");

            Grid messageGrid = new Grid();
            messageGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
            messageGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

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
                Foreground = Brushes.White,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };
            iconBorder.Child = icon;

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

            Grid.SetColumn(iconBorder, 0);
            Grid.SetColumn(messageBorder, 1);
            messageGrid.Children.Add(iconBorder);
            messageGrid.Children.Add(messageBorder);

            Border container = new Border
            {
                Margin = new Thickness(10, 5, 50, 5),
                Child = messageGrid
            };

            ChatMessagesPanel.Children.Add(container);
            ScrollToBottom();
        }

        // Bot message with typing effect (animated character by character)
        private async Task AddBotMessageWithTypingAsync(string message)
        {
            _isTyping = true;
            string cleanMessage = message.Replace("*", "");

            // Create the message container first
            Grid messageGrid = new Grid();
            messageGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
            messageGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

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
                Foreground = Brushes.White,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };
            iconBorder.Child = icon;

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
                Text = "",
                Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#D5B4E6")),
                FontSize = 14,
                TextWrapping = TextWrapping.Wrap,
                FontFamily = new FontFamily("Segoe UI")
            };
            messageBorder.Child = messageText;

            Grid.SetColumn(iconBorder, 0);
            Grid.SetColumn(messageBorder, 1);
            messageGrid.Children.Add(iconBorder);
            messageGrid.Children.Add(messageBorder);

            Border container = new Border
            {
                Margin = new Thickness(10, 5, 50, 5),
                Child = messageGrid
            };

            ChatMessagesPanel.Children.Add(container);
            ScrollToBottom();

            // Typing animation - add characters one by one
            for (int i = 0; i <= cleanMessage.Length; i++)
            {
                messageText.Text = cleanMessage.Substring(0, i);
                await Task.Delay(15); // 15ms delay between characters for natural typing feel
                ScrollToBottom();
            }

            _isTyping = false;
        }

        // Synchronous version for simple messages (no typing effect needed)
        private void AddBotMessageWithTyping(string message)
        {
            _ = AddBotMessageWithTypingAsync(message);
        }

        private void AddQuickTopicSuggestions()
        {
            AddBotMessageWithTyping("You can ask me about:\n• Password safety\n• Phishing scams\n• Safe browsing\n• Malware protection\n• Social engineering\n• Data privacy\n• Multi-factor authentication (MFA)\n• Secure backups\n• Identity theft");
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
            AddBotMessageWithTyping("Chat cleared! How can I help you today?");
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