using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Web;

namespace FrachatBot
{
    public static class LogSplitter
    {
        public static List<string> SplitLogByLine(string filepath, int characterLimit)
        {
            StreamReader streamReader = new StreamReader(filepath);

            return SplitLogByLineImplementation(streamReader, characterLimit);
        }

        public static List<string> SplitInMemoryLogByLine(string logs, int characterLimit)
        {
            StreamReader streamReader = GetStreamReaderForLogInMemory(logs);

            return SplitLogByLineImplementation(streamReader, characterLimit);
        }

        private static StreamReader GetStreamReaderForLogInMemory(string logString)
        {
            byte[] logInBytes = Encoding.ASCII.GetBytes(logString);
            MemoryStream logStream = new MemoryStream(logInBytes);
            StreamReader logStreamReader = new StreamReader(logStream);
            return logStreamReader;
        }

        internal static List<string> SplitLogByLineImplementation(StreamReader inputStream, int characterLimit)
        {
            List<string> logChunks = new List<string>();
            StringBuilder sb = new StringBuilder();

            while (inputStream.Peek() > -1)
            {
                string nextString = inputStream.ReadLine() + Environment.NewLine; // Why doesn't it give me the newline too??

                if (sb.Length + nextString.Length <= characterLimit)
                {
                    sb.Append(nextString);
                    continue;
                }

                if (sb.Length > 0)
                {
                    logChunks.Add(sb.ToString());
                    sb.Clear();
                }
                
                if (nextString.Length <= characterLimit)
                {
                    sb.Append(nextString);
                    continue;
                }

                // Peculiar case where the next line is more than our character limit
                // We could try to split it nicely by space, but that ultimately
                // leads us back here again, (what if the line has no spaces?)
                // so let's just not bother
                int charCount = 0;
                while (charCount < nextString.Length)
                {
                    string substring;
                    if (charCount + characterLimit <= nextString.Length)
                    {
                        substring = nextString.Substring(charCount, characterLimit);
                    }
                    else
                    {
                        substring = nextString.Substring(charCount);
                    }

                    logChunks.Add(substring);
                    charCount += characterLimit;
                }
            }

            if (sb.Length > 0)
            {
                logChunks.Add(sb.ToString());
            }

            return logChunks;
        }
    }
}