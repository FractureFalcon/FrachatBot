using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FrachatBot
{
    public static class LogPrettifier
    {
        public static Regex discordInviteLinkRegex = new Regex(@"https:\/\/discord\.gg\/\w{7,10}");
        public const string discordInviteLinkReplacement = "LINK_REMOVED_FOR_ARCHIVE";

        public static string PrettifyLog(string log)
        {
            return discordInviteLinkRegex.Replace(log, discordInviteLinkReplacement);
        }
    }
}
