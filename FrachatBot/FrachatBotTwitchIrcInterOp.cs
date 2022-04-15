using System;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using TwitchLib.Client;
using TwitchLib.Client.Events;
using TwitchLib.Client.Models;
using TwitchLib.Communication.Clients;
using TwitchLib.Communication.Models;

namespace FrachatBot
{
    public class FrachatBotTwitchIrcInterOp
    {
        private FrachatBotForm frachatBotForm;
        private TwitchClient twitchClient;
        private const string twitchIrcPassword = "C:\\Users\\K8\\frachatBotTwitchIrcPassword.txt";

        public FrachatBotTwitchIrcInterOp(FrachatBotForm form)
        {
            frachatBotForm = form;
            Initialize();
        }

        public void Initialize()
        {
            InitializeTwitchClient();
        }

        public void InitializeTwitchClient()
        {
            ConnectionCredentials credentials = new ConnectionCredentials("frachatbot", File.ReadAllText(twitchIrcPassword));
            var clientOptions = new ClientOptions
            {
                MessagesAllowedInPeriod = 750,
                ThrottlingPeriod = TimeSpan.FromSeconds(30),
                ClientType = TwitchLib.Communication.Enums.ClientType.Chat
            };

            WebSocketClient customClient = new WebSocketClient(clientOptions);
            twitchClient = new TwitchClient(customClient);
            twitchClient.Initialize(credentials);

            twitchClient.OnConnected += OnConnected;
            twitchClient.OnMessageReceived += OnMessageReceived;

            twitchClient.Connect();
        }

        public void OnConnected(object sender, OnConnectedArgs args)
        {
            frachatBotForm.LogLineToTwitchLog($"{DateTime.Now}: Connected");
            twitchClient.JoinChannel("clamhat");
            twitchClient.JoinChannel("willow");
            twitchClient.JoinChannel("vermanubis");
        }

        public void OnMessageReceived(object sender, OnMessageReceivedArgs args)
        {
            ChatMessage chatMessage = args.ChatMessage;
            string chatMessageFormat = $"(#{chatMessage.Channel}) [{DateTime.Now.ToString("yyyy-MM-dd hh:mm:sstt")}] {chatMessage.Username}: {chatMessage.Message}";
            frachatBotForm.LogLineToTwitchChatLog(chatMessageFormat);
        }
    }
}
