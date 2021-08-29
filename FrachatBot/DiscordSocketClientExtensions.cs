using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;

namespace FrachatBot
{
    public static class DiscordSocketClientExtensions
    {
        public static async Task InitializeAndRun(this DiscordSocketClient discordClient, string tokenFilePath)
        {
            var token = File.ReadAllText(tokenFilePath);

            await discordClient.LoginAsync(TokenType.Bot, token);

            await discordClient.StartAsync();
        }
    }
}
