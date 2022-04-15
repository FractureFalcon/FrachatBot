using System;
using System.Collections.Generic;
using System.Deployment.Application;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitchLib.Api;

namespace FrachatBot
{
    class FrachatBotTwitchApiInterOp
    {
        private FrachatBotForm frachatBotForm;
        private string token;
        //private Timer timer;
        private const string twitchSecret = "C:\\Users\\K8\\frachatBotTwitchSecret.txt";
        private const string twitchAccessCode = "C:\\Users\\K8\\frachatBotAccessCode.txt";
        private TwitchAPI twitchApi;
        //private readonly HttpClient httpClient;
        TwitchLib.Api.Services.LiveStreamMonitorService streamMonitor;

        public event EventHandler OnStreamEnded;

        private readonly List<string> streamsToMonitor = new List<string>
        {
            "vermanubis",
            "clamhat",
            "ryukred_"
        };

        public FrachatBotTwitchApiInterOp(FrachatBotForm form)
        {
            frachatBotForm = form;
            //httpClient = new HttpClient();
            Initialize();
        }

        public async void Initialize()
        {
            //await GetOauthToken();
            twitchApi = new TwitchAPI();
            twitchApi.Settings.ClientId = "7aokvuzhnblzo8ybxy6a5om6phqxa1";
            twitchApi.Settings.AccessToken = File.ReadAllText(twitchAccessCode);
            //string authCodeUrl = twitchApi.Auth.GetAuthorizationCodeUrl("http://localhost", new AuthScopes[] { AuthScopes.None });
            //System.Diagnostics.Process.Start(authCodeUrl);
            streamMonitor = new TwitchLib.Api.Services.LiveStreamMonitorService(twitchApi);
            streamMonitor.SetChannelsByName(streamsToMonitor);
            streamMonitor.OnStreamOffline += OnStreamOffline;
            //bool lukeLive = await twitchApi.V5.Streams.BroadcasterOnlineAsync("lukeflywalkerr");
            //bool clamLive = await twitchApi.V5.Streams.BroadcasterOnlineAsync("clamhat");
        }

        public void UpdateStreamsToMonitor(List<string> streams)
        {
            streamMonitor.SetChannelsByName(streams);
        }

        public async Task GetOauthToken()
        {
            //string secret = File.ReadAllText(twitchSecretFilePath);
            //string endpoint = "https://id.twitch.tv/oauth2/token";
            //string urlWithArgs = $"{endpoint}?client_id=7aokvuzhnblzo8ybxy6a5om6phqxa1&client_secret={secret}&grant_type=client_credentials&scope=chat:read";

            //HttpResponseMessage response = await httpClient.PostAsync(urlWithArgs, new StringContent(string.Empty));

            //LogToConsole($"Got response {response.StatusCode}: {response.Content}");

            //if (response.IsSuccessStatusCode)
            //{
            //    string responseString = await response.Content.ReadAsStringAsync();
            //    TwitchOauthResponse deserializedResponse = JsonConvert.DeserializeObject<TwitchOauthResponse>(responseString);
            //    token = deserializedResponse.access_token;
            //}

            //string secret = File.ReadAllText(twitchSecretFilePath);
            //string endpoint = "https://id.twitch.tv/oauth2/authorize";
            //string urlWithArgs = $"{endpoint}?client_id=7aokvuzhnblzo8ybxy6a5om6phqxa1&redirect_uri=http://localhost&response_type=code&scope=chat:read";

            //HttpResponseMessage response = await httpClient.GetAsync(urlWithArgs);

            //LogToConsole($"Got response {response.StatusCode}: {response.Content}");

            //if (response.IsSuccessStatusCode)
            //{
            //    string responseString = await response.Content.ReadAsStringAsync();
            //    string filePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            //    filePath = Path.Combine(filePath, "FrachatBot");
            //    Directory.CreateDirectory(filePath);
            //    string file = Path.Combine(filePath, "auth.html");
            //    File.WriteAllText(file, responseString);
            //    System.Diagnostics.Process.Start(file);
            //}
        }

        public void OnStreamOffline(object sender, EventArgs args)
        {
            EventUtils.SendEventHandlerEventSafe(OnStreamEnded, this, args);
        }
    }
}
