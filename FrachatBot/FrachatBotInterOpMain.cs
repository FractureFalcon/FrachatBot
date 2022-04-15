using Discord;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace FrachatBot
{
    public class FrachatBotInterOpMain
    {
        private FrachatBotForm frachatBotForm;
        private FrachatBotConfigManager frachatBotConfigManager;
        private FrachatBotDiscordProvider discordProvider;
        private FrachatBotTwitchIrcInterOp twitchIrcInterOp;
        private FrachatBotTwitchApiInterOp twitchApiInterOp;

        private string logToSend;
        private SocketGuildChannel targetChannel;
        private SocketGuild targetServer;

        public static void Main(string[] args)
        {
            new FrachatBotInterOpMain().Initialize();
        }

        public async void Initialize()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            frachatBotForm = new FrachatBotForm();
            frachatBotConfigManager = new FrachatBotConfigManager(frachatBotForm);
            discordProvider = new FrachatBotDiscordProvider(frachatBotForm);
            discordProvider.OnInitializationComplete += InitializeDiscordUi;
            discordProvider.Initialize();

            twitchIrcInterOp = new FrachatBotTwitchIrcInterOp(frachatBotForm);
            twitchApiInterOp = new FrachatBotTwitchApiInterOp(frachatBotForm);

            Application.Run(frachatBotForm);
        }

        // TODO: Re-wire this functionality through DiscordProvider
        private Task OnClientConnected()
        {
            frachatBotForm.SetDiscordBotStatus("Connected");
            return Task.CompletedTask;
        }

        private Task OnClientDisconnected(Exception e)
        {
            frachatBotForm.SetDiscordBotStatus("Disconnected");
            return Task.CompletedTask;
        }

        private Task OnClientLoggedIn()
        {
            frachatBotForm.SetDiscordBotStatus("Logged in");
            return Task.CompletedTask;
        }

        private Task OnClientLoggedOut()
        {
            frachatBotForm.SetDiscordBotStatus("Logged out");
            return Task.CompletedTask;
        }

        private void RefreshServerList(object sender, EventArgs args)
        {
            frachatBotForm.PopulateDiscordAutomationServerList(discordProvider.GetServerList());
        }

        private void TrySendLogs(object sender, EventArgs args)
        {
            if (CanSendLog())
            {
                discordProvider.TrySendLogs(targetChannel, logToSend);
            }
        }
        private void InitializeDiscordUi(object sender, EventArgs args)
        {
            RefreshServerList(null, null);

            frachatBotForm.DiscordAutomationServerRefresh -= RefreshServerList;
            frachatBotForm.DiscordAutomationServerSelected -= OnServerSelected;
            frachatBotForm.DiscordAutomationChannelSelected -= OnChannelSelected;
            frachatBotForm.LogSendEvent -= TrySendLogs;

            frachatBotForm.DiscordAutomationServerRefresh += RefreshServerList;
            frachatBotForm.DiscordAutomationServerSelected += OnServerSelected;
            frachatBotForm.DiscordAutomationChannelSelected += OnChannelSelected;
            frachatBotForm.LogSendEvent += TrySendLogs;
        }

        private void OnLogModified(object sender, EventArgs args)
        {
            RichTextBox senderTextBox = sender as RichTextBox;
            if (senderTextBox == null)
            {
                return;
            }
            logToSend = senderTextBox.Text;
            frachatBotForm.ToggleSendLogButtonFunctionality(CanSendLog());
        }

        private void OnServerSelected(ComboBox sender, EventArgs eventArgs)
        {
            SocketGuild selectedServer = sender.SelectedItem as SocketGuild;

            if (selectedServer == null)
            {
                return;
            }

            targetServer = selectedServer;
            frachatBotForm.PopulateStreamConfigChannelList(selectedServer.Channels);
            frachatBotForm.ToggleSendLogButtonFunctionality(false);
        }

        private void OnChannelSelected(ComboBox sender, EventArgs eventArgs)
        {
            SocketGuildChannel selectedChannel = sender.SelectedItem as SocketGuildChannel;

            if (selectedChannel == null)
            {
                return;
            }

            targetChannel = selectedChannel;

            frachatBotForm.ToggleSendLogButtonFunctionality(CanSendLog());
        }

        private bool CanSendLog()
        {
            if (targetChannel != null && logToSend != null && logToSend.Length > 0)
            {
                return true;
            }

            return false;
        }

        private async Task TrySendLogChunk(IMessageChannel messageChannel, string logChunk, int maxRetries = 10)
        {
            bool success = false;
            IUserMessage messageResult = null;
            int tries = 0;

            while (!success)
            {
                tries += 1;

                try
                {
                    messageResult = await messageChannel.SendMessageAsync($"```{logChunk}```");
                }
                catch (Exception e)
                {
                    await LogLineToDiscordConsole($"SendMessageAsync threw exception {e.ToString()}: {e.Message}");
                }

                if (messageResult == null)
                {
                    await LogLineToDiscordConsole("messageResult from SendMessageAsync was null");
                }
                else
                {
                    int previewLength = Math.Min(messageResult.Content.Length, messageResult.Content.IndexOf(Environment.NewLine));
                    previewLength = Math.Min(previewLength, 50);
                    await LogLineToDiscordConsole($"SendMessageAsync returned {messageResult.Id} @ {messageResult.Timestamp}: {messageResult.Content.Substring(0, previewLength)}...");
                    success = true;
                }

                if (!success)
                {
                    if (tries >= maxRetries)
                    {
                        await LogLineToDiscordConsole($"LOG CHUNK FAILED TO UPLOAD AFTER {maxRetries} ATTEMPTS:");
                        await LogLineToDiscordConsole($"```{logChunk}```");
                        return;
                    }

                    await Task.Delay(1000);
                }
            }
        }

        private async Task OnLogEvent(LogMessage message)
        {
            Console.WriteLine($"DiscordLogEvent: {message}");
            await LogLineToDiscordConsole(message.ToString());
        }

        private async Task LogLineToDiscordConsole(string message)
        {
            await frachatBotForm.LogLineToDiscordLog(message);
        }

        public static List<string> SplitLog(string log, int characterLimit = DiscordTextPostDataModel.TextPostLimitPlainTextPosts, bool prettify = true)
        {
            string textToSplit = log;
            if (prettify)
            {
                textToSplit = LogPrettifier.PrettifyLog(log);
            }
            List<string> logChunks = LogSplitter.SplitInMemoryLogByLine(textToSplit, characterLimit);
            return logChunks;
        }
    }
}
