using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrachatBot
{
    public class TwitchOauthResponse
    {
        public string access_token;
        public string refresh_token;
        public int expires_in; // seconds
        public string[] scope;
        public string token_type; // "bearer"
    }
}
