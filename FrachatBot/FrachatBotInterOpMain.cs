using System.Collections.Generic;
using System.Windows.Forms;


namespace FrachatBot
{
    public class FrachatBotInterOpMain
    {
        private FrachatBotForm frachatBotForm;
        private FrachatBotDiscordInterOp discordInterOp;

        public static void Main(string[] args)
        {
            new FrachatBotInterOpMain().Initialize();
        }

        public void Initialize()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            frachatBotForm = new FrachatBotForm();
            discordInterOp = new FrachatBotDiscordInterOp(frachatBotForm);

            Application.Run(frachatBotForm);
        }

        private Task OnClientConnected()
        {
            frachatBotForm.SetBotStatus("Connected");
            return Task.CompletedTask;
        }

        private Task OnClientDisconnected(Exception e)
        {
            frachatBotForm.SetBotStatus("Disconnected");
            return Task.CompletedTask;
        }

        private Task OnClientLoggedIn()
        {
            frachatBotForm.SetBotStatus("Logged in");
            return Task.CompletedTask;
        }

        private Task OnClientLoggedOut()
        {
            frachatBotForm.SetBotStatus("Logged out");
            return Task.CompletedTask;
        }

        private void RefreshServerList(object sender, EventArgs args)
        {
            frachatBotForm.PopulateServerList(discordClient.Guilds);
        }

        private Task OnClientReady()
        {
            frachatBotForm.SetBotStatus("Ready");

            RefreshServerList(null, null);

            frachatBotForm.ServerRefresh -= RefreshServerList;
            frachatBotForm.ServerSelected -= OnServerSelected;
            frachatBotForm.ChannelSelected -= OnChannelSelected;
            frachatBotForm.LogSendEvent -= TrySendLogs;

            frachatBotForm.ServerRefresh += RefreshServerList;
            frachatBotForm.ServerSelected += OnServerSelected;
            frachatBotForm.ChannelSelected += OnChannelSelected;
            frachatBotForm.LogSendEvent += TrySendLogs;

            return Task.CompletedTask;
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
            frachatBotForm.PopulateChannelList(selectedServer.Channels);
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

        private async void TrySendLogs(object sender, EventArgs args)
        {
            SocketChannel channel = discordClient.GetChannel(targetChannel.Id);
            IMessageChannel messageChannel = channel as IMessageChannel;
            if (messageChannel == null)
            {
                await LogLineToConsole("Selected channel did not cast to IMessageChannel");
                return;
            }

            List<string> logChunks = SplitLog(logToSend);
            frachatBotForm.ToggleSendLogButtonFunctionality(false);

            foreach (string logChunk in logChunks)
            {
                await TrySendLogChunk(messageChannel, logChunk);
            }

            frachatBotForm.ToggleSendLogButtonFunctionality(true);
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
                    await LogLineToConsole($"SendMessageAsync threw exception {e.ToString()}: {e.Message}");
                }

                if (messageResult == null)
                {
                    await LogLineToConsole("messageResult from SendMessageAsync was null");
                }
                else
                {
                    int previewLength = Math.Min(messageResult.Content.Length, messageResult.Content.IndexOf(Environment.NewLine));
                    previewLength = Math.Min(previewLength, 50);
                    await LogLineToConsole($"SendMessageAsync returned {messageResult.Id} @ {messageResult.Timestamp}: {messageResult.Content.Substring(0, previewLength)}...");
                    success = true;
                }

                if (!success)
                {
                    if (tries >= maxRetries)
                    {
                        await LogLineToConsole($"LOG CHUNK FAILED TO UPLOAD AFTER {maxRetries} ATTEMPTS:");
                        await LogLineToConsole($"```{logChunk}```");
                        return;
                    }

                    await Task.Delay(1000);
                }
            }
        }

        private async Task OnLogEvent(LogMessage message)
        {
            Console.WriteLine($"DiscordLogEvent: {message}");
            await LogLineToConsole(message.ToString());
        }

        private async Task LogLineToConsole(string message)
        {
            await frachatBotForm.LogLine(message);
        }

        private async void OnApplicationClose(object sender, EventArgs args)
        {
            await discordClient.StopAsync();
            discordClient.Dispose();
            Application.Exit();
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
