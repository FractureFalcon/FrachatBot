using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrachatBot
{
    public static class DiscordTextPostDataModel
    {
        public const int CharactersForPlainText = 6;

        public const int TextPostLimit = 2000;
        public const int TextPostLimitPlainTextPosts = TextPostLimit - CharactersForPlainText;

        public const int TextPostLimit_Nitro = 4000;
        public const int TextPostLimitPlainTextPosts_Nitro = TextPostLimit_Nitro - CharactersForPlainText;
    }
}