using Discord;
using Discord.Rest;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrachatBot
{
    public class FrachatBotInterOpMain
    {
        private FrachatBotForm frachatBotForm;
        private DiscordSocketClient discordClient;
        private SocketGuild targetServer;
        private SocketGuildChannel targetChannel;
        private ChattyHeartBeat chattyHeartBeat;
        private string logToSend;

        // Deadname myself instead of committing my secrets to GitHub, the dedication
        private const string tokenFilePath = "C:\\Users\\K8\\frachatBotToken.txt";

        public static void Main(string[] args)
        {
            new FrachatBotInterOpMain().Initialize();
        }

        public void Initialize()
        {
            this.chattyHeartBeat = new ChattyHeartBeat();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            frachatBotForm = new FrachatBotForm();
            frachatBotForm.LogModifiedEvent += OnLogModified;
            frachatBotForm.OnApplicationClose += OnApplicationClose;

            discordClient = new DiscordSocketClient();

            discordClient.Log += OnLogEvent;

            discordClient.Connected += OnClientConnected;
            discordClient.Disconnected += OnClientDisconnected;
            discordClient.LoggedIn += OnClientLoggedIn;
            discordClient.LoggedOut += OnClientLoggedOut;
            discordClient.Ready += OnClientReady;

            _ = discordClient.InitializeAndRun(tokenFilePath);

            Application.Run(frachatBotForm);
        }

        private async Task OnClientConnected()
        {
            await frachatBotForm.SetBotStatus("Connected");
        }

        private async Task OnClientDisconnected(Exception e)
        {
            await frachatBotForm.SetBotStatus("Disconnected");
        }

        private async Task OnClientLoggedIn()
        {
            await frachatBotForm.SetBotStatus("Logged in");
        }

        private async Task OnClientLoggedOut()
        {
            await frachatBotForm.SetBotStatus("Logged out");
        }

        private async Task OnClientReady()
        {
            await frachatBotForm.SetBotStatus("Ready");

            frachatBotForm.PopulateServerList(discordClient.Guilds);

            frachatBotForm.ServerSelected -= OnServerSelected;
            frachatBotForm.ChannelSelected -= OnChannelSelected;
            frachatBotForm.LogSendEvent -= TrySendLogs;

            frachatBotForm.ServerSelected += OnServerSelected;
            frachatBotForm.ChannelSelected += OnChannelSelected;
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

            foreach (string logChunk in logChunks)
            {
                IUserMessage messageResult = null;
                try
                {
                    messageResult = await messageChannel.SendMessageAsync($"```{logChunk}```");
                }
                catch (Exception e)
                {
                    await LogLineToConsole(e.Message);
                    return;
                }

                if (messageResult == null)
                {
                    await LogLineToConsole("messageResult from SendMessageAsync was null");
                    return;
                }
                else
                {
                    await LogLineToConsole($"SendMessageAsync returned {messageResult.Id} created at {messageResult.Timestamp} ({messageResult.Content.Substring(0, Math.Min(messageResult.Content.Length, 50))}...)");
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
