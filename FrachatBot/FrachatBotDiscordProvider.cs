using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Discord;
using Discord.Rest;
using Discord.WebSocket;

namespace FrachatBot
{
    public class FrachatBotDiscordProvider
    {
        public event EventHandler OnInitializationComplete;

        private FrachatBotForm frachatBotForm;
        private DiscordSocketClient discordClient;

        // Deadname myself instead of committing my secrets to GitHub, the dedication
        private const string discordTokenFilePath = "C:\\Users\\K8\\frachatBotDiscordToken.txt";

        public FrachatBotDiscordProvider(FrachatBotForm form)
        {
            frachatBotForm = form;
            frachatBotForm.OnApplicationClose += OnApplicationClose;
        }

        // Wait till initialized before calling
        public IReadOnlyCollection<SocketGuild> GetServerList()
        {
            return discordClient.Guilds;
        }

        public IReadOnlyCollection<SocketChannel> GetChannelList(SocketGuild selectedServer)
        {
            return selectedServer.Channels;
        }

        public async void Initialize()
        {
            discordClient = new DiscordSocketClient();

            discordClient.Log += OnLogEvent;

            discordClient.Connected += OnClientConnected;
            discordClient.Disconnected += OnClientDisconnected;
            discordClient.LoggedIn += OnClientLoggedIn;
            discordClient.LoggedOut += OnClientLoggedOut;
            discordClient.Ready += OnClientReady;

            _ = discordClient.InitializeAndRun(discordTokenFilePath);
        }

        private Task OnClientConnected()
        {
            return Task.CompletedTask;
        }

        private Task OnClientDisconnected(Exception e)
        {
            return Task.CompletedTask;
        }

        private Task OnClientLoggedIn()
        {
            return Task.CompletedTask;
        }

        private Task OnClientLoggedOut()
        {
            return Task.CompletedTask;
        }

        private Task OnClientReady()
        {
            EventUtils.SendEventHandlerEventSafe(OnInitializationComplete, this, null);
            return Task.CompletedTask;
        }

        public async void TrySendLogs(SocketGuildChannel targetChannel, string logToSend)
        {
            SocketChannel channel = discordClient.GetChannel(targetChannel.Id);
            IMessageChannel messageChannel = channel as IMessageChannel;
            if (messageChannel == null)
            {
                await LogLineToConsole("Selected channel did not cast to IMessageChannel");
                return;
            }

            List<string> logChunks = FrachatBotInterOpMain.SplitLog(logToSend);
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
            await frachatBotForm.LogLineToDiscordLog(message);
        }

        private async void OnApplicationClose(object sender, EventArgs args)
        {
            await discordClient.StopAsync();
            discordClient.Dispose();
            Application.Exit();
        }
    }
}
