using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FrachatBot.Tests
{
    [TestClass]
    public class LogSplitterTest
    {
        public string HardcodedLog = 
@"[2021-07-26 08:37:13PM]  fracturefalcon: it would be pretty gay to have two horses inside you
[2021-07-26 08:37:25PM]  ZaKuroeNoGibbon: al;fljkasdhfasd
[2021-07-26 08:37:28PM]  ZaKuroeNoGibbon: frac
[2021-07-26 08:37:31PM]  hoagiebot9000: DrRyder redeemed ""Hydrate!""
[2021-07-26 08:37:31PM]  ZaKuroeNoGibbon: oh my god
[2021-07-26 08:37:33PM]  eerod: banned
[2021-07-26 08:37:36PM]  StuTheAnnouncer: I mean just one would probably be a bit much
[2021-07-26 08:37:55PM]  fracturefalcon: yeah
[2021-07-26 08:37:56PM]  fracturefalcon: yeah
[2021-07-26 08:38:10PM]  StuTheAnnouncer: Living up to the name ""fracture""
[2021-07-26 08:38:11PM]  Hapax: i ate two horse gumys and am now home of sexuals
[2021-07-26 08:38:20PM]  fracturefalcon: @StuTheAnnouncer LMFAOOOOO
[2021-07-26 08:38:24PM]  fracturefalcon: GOATed comment
[2021-07-26 08:39:01PM]  StuTheAnnouncer: ty I never graduated college
[2021-07-26 08:39:06PM]  ZaKuroeNoGibbon: F R A C T U R E";
// 93 longest line
// 959 char total

        public string CharacterLimitTestLog1 = 
@"[2021-07-26 08:43:53PM] fracturefalcon: SeemsGood100 SeemsGood100 SeemsGood100 SeemsGood100 SeemsGood1 SeemsGood1 SeemsGood1 SeemsGood1 SeemsGood1 SeemsGood1 SeemsGood1 SeemsGood1 SeemsGood1 SeemsGood1 SeemsGood1 SeemsGood1 SeemsGood1 SeemsGood1 SeemsGood1 SeemsGood1 SeemsGood1 SeemsGood1 SeemsGood1 SeemsGood1";
// 314 char

        public string CharacterLimitTestLog2 =
@"[2021-07-26 08:43:53PM] fracturefalcon: SeemsGood100 SeemsGood100 SeemsGood100 SeemsGood100 SeemsGood1 SeemsGood1 SeemsGood1 SeemsGood1 SeemsGood1 SeemsGood1 SeemsGood1 SeemsGood1 SeemsGood1 SeemsGood1 SeemsGood1 SeemsGood1 SeemsGood1 SeemsGood1 SeemsGood1 SeemsGood1 SeemsGood1 SeemsGood1 SeemsGood1 SeemsGood1
[2021-07-26 08:43:53PM] fracturefalcon: SeemsGood100 SeemsGood100 SeemsGood100 SeemsGood100 SeemsGood1 SeemsGood1 SeemsGood1 SeemsGood1 SeemsGood1 SeemsGood1 SeemsGood1 SeemsGood1 SeemsGood1 SeemsGood1 SeemsGood1 SeemsGood1 SeemsGood1 SeemsGood1 SeemsGood1 SeemsGood1 SeemsGood1 SeemsGood1 SeemsGood1 SeemsGood1
[2021-07-26 08:43:53PM] fracturefalcon: SeemsGood100 SeemsGood100 SeemsGood100 SeemsGood100 SeemsGood1 SeemsGood1 SeemsGood1 SeemsGood1 SeemsGood1 SeemsGood1 SeemsGood1 SeemsGood1 SeemsGood1 SeemsGood1 SeemsGood1 SeemsGood1 SeemsGood1 SeemsGood1 SeemsGood1 SeemsGood1 SeemsGood1 SeemsGood1 SeemsGood1 SeemsGood1
[2021-07-26 08:43:53PM] fracturefalcon: SeemsGood100 SeemsGood100 SeemsGood100 SeemsGood100 SeemsGood1 SeemsGood1 SeemsGood1 SeemsGood1 SeemsGood1 SeemsGood1 SeemsGood1 SeemsGood1 SeemsGood1 SeemsGood1 SeemsGood1 SeemsGood1 SeemsGood1 SeemsGood1 SeemsGood1 SeemsGood1 SeemsGood1 SeemsGood1 SeemsGood1 SeemsGood1
[2021-07-26 08:43:53PM] fracturefalcon: SeemsGood100 SeemsGood100 SeemsGood100 SeemsGood100 SeemsGood1 SeemsGood1 SeemsGood1 SeemsGood1 SeemsGood1 SeemsGood1 SeemsGood1 SeemsGood1 SeemsGood1 SeemsGood1 SeemsGood1 SeemsGood1 SeemsGood1 SeemsGood1 SeemsGood1 SeemsGood1 SeemsGood1 SeemsGood1 SeemsGood1 SeemsGood1";

        private StreamReader GetStreamReaderForLog(string logString)
        {
            byte[] logInBytes = Encoding.ASCII.GetBytes(logString);
            MemoryStream logStream = new MemoryStream(logInBytes);
            StreamReader logStreamReader = new StreamReader(logStream);
            return logStreamReader;
        }

        private void BaseTestFormat(int characterLimit, int expectedNumberResults, string testLog)
        {
            StreamReader logStreamReader = GetStreamReaderForLog(testLog);

            List<string> results = LogSplitter.SplitLogByLineImplementation(logStreamReader, characterLimit);

            Assert.IsNotNull(results);
            Assert.AreEqual(expectedNumberResults, results.Count);

            StringBuilder sb = new StringBuilder();
            foreach (string result in results)
            {
                Assert.IsTrue(result.Length <= characterLimit);
                sb.Append(result);
            }

            Assert.IsTrue(String.Compare(testLog, sb.ToString(), CultureInfo.InvariantCulture, CompareOptions.IgnoreSymbols) == 0);
        }
        
        // public void Given_When_Expected()

        [TestMethod]
        public void GivenHardcodedLogsAndBigCharacterLimit_WhenSplitLogsByLineInvoked_LogsAreSplitByLine()
        {
            BaseTestFormat(300, 4, HardcodedLog);
        }

        [TestMethod]
        public void GivenHardcodedLogsAndSmallCharacterLimit_WhenSplitLogsByLineInvoked_LogsAreSplitByLine()
        {
            BaseTestFormat(95, 13, HardcodedLog);
        }

        [TestMethod]
        public void GivenLogsWithNoNewlinesAndBigCharacterLimit_WhenSplitLogsByLineInvoked_LogIsNotSplit()
        {
            BaseTestFormat(9001, 1, CharacterLimitTestLog1);
        }

        [TestMethod]
        public void GivenShortLogsWithNoNewlinesAndSmallCharacterLimit_WhenSplitLogsByLineInvoked_LogsSplitByCharacterLimit()
        {
            BaseTestFormat(53, 6, CharacterLimitTestLog1);
        }

        [TestMethod]
        public void GivenLogsWithMoreCharactersPerLineThanLimit_WhenSplitLogsByLineInvoked_LogsAreSplitByCharacterLimit()
        {
            BaseTestFormat(160, 10, CharacterLimitTestLog2);
        }
    }
}
