using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrachatBot
{
    public class FrachatBotConfig
    {
        public const string FrachatBotAppName = "FrachatBot";

        public Dictionary<string, TwitchArchiveConfig> twitchArchiveConfigs;
    }

    public class TwitchArchiveConfig
    {
        public string discordServer;
        public string discordChannel;
    }
}
