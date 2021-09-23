using System.Collections.Generic;
using System.Windows.Forms;


namespace FrachatBot
{
    public class FrachatBotInterOpMain
    {
        private FrachatBotForm frachatBotForm;
        private FrachatBotDiscordInterOp discordInterOp;

        public static void Main(string[] args)
        {
            new FrachatBotInterOpMain().Initialize();
        }

        public void Initialize()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            frachatBotForm = new FrachatBotForm();
            discordInterOp = new FrachatBotDiscordInterOp(frachatBotForm);

            Application.Run(frachatBotForm);
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
