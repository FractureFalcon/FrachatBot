using Discord;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrachatBot
{
    
    public partial class FrachatBotForm : Form
    {
        #region Manual-side UI code

        public FrachatBotForm()
        {
            InitializeComponent();
        }

        private static TextBox GenerateLogChunkTextBox(Control parentObject, int numChunks = 0, string startingText = "")
        {
            TextBox textBox = new TextBox();
            textBox.ReadOnly = true;
            textBox.BackColor = SystemColors.ButtonFace;
            textBox.BorderStyle = BorderStyle.None;
            textBox.Multiline = true;
            textBox.Click += new System.EventHandler(EventUtils.CopyTextToClipboard);

            if (!string.IsNullOrWhiteSpace(startingText))
            {
                textBox.Text = startingText;
            }

            textBox.Parent = parentObject;

            int width = (int)(parentObject.Width * .9f);
            int height = textBox.GetPreferredSize(new Size(0, 0)).Height;

            if (numChunks > 0)
            {
                height = (int)(parentObject.Height * .85f / numChunks);
            }

            textBox.Size = new Size(width, height);

            return textBox;
        }

        private void LogSplitButton_Click(object sender, EventArgs e)
        {
            NormalTabFlowLayoutGroup.Controls.Clear();

            List<string> logChunks = FrachatBotInterOpMain.SplitLog(LogInputTextBox.Text, 
                DiscordTextPostDataModel.TextPostLimitPlainTextPosts_Nitro, 
                PrettifyLogCheckBox.Checked);

            Label logChunkCountLabel = new Label();
            logChunkCountLabel.Text = $"Total log chunks: {logChunks.Count}";
            logChunkCountLabel.Size = logChunkCountLabel.PreferredSize;
            NormalTabFlowLayoutGroup.Controls.Add(logChunkCountLabel);

            int i = 1;
            foreach (string logChunk in logChunks)
            {
                string plainTextFormat = $"```{logChunk}```";
                GenerateLogChunkTextBox(NormalTabFlowLayoutGroup, logChunks.Count, plainTextFormat);

                string debugTextFormat = $"{i++}:{Environment.NewLine}```{logChunk}```";
                GenerateLogChunkTextBox(DebugFlowLayoutGroup, 0, debugTextFormat);
            }
        }
        #endregion

        #region Automation-side code

        public delegate void DropDownSelectedEvent(ComboBox sender, EventArgs eventArgs);
        public event DropDownSelectedEvent ServerSelected;
        public event DropDownSelectedEvent ChannelSelected;
        public event EventHandler LogSendEvent;
        public event EventHandler LogModifiedEvent;

        public Task LogLine(string message)
        {
            LogTextBox.InvokeWithRequiredCheck(() => LogTextBox.AppendText($"{message}{Environment.NewLine}"));

            return Task.CompletedTask;
        }

        public void SetBotStatus(string status)
        {
            const string botStatusHeader = "Bot Status: ";
            string newStatus = $"{botStatusHeader} {status}";
            SetBotStatusTextSafe(newStatus);
        }

        public void SetBotStatusTextSafe(string text)
        {
            BotStatusLabel.InvokeWithRequiredCheck(() => BotStatusLabel.Text = text);
        }

        private void OnLogModified(object sender, EventArgs args)
        {
            EventUtils.SendEventHandlerEventSafe(LogModifiedEvent, sender, args);
        }

        private void OnDropDownSelected(object sender, EventArgs e)
        {
            ComboBox dropDown = sender as ComboBox;
            if (dropDown == null)
            {
                return;
            }

            DropDownSelectedEvent dropDownEvent = null;
            if (dropDown.Name == "ServerSelectDropDown")
            {
                dropDownEvent = ServerSelected;
            }
            else if (dropDown.Name == "ChannelSelectDropDown")
            {
                dropDownEvent = ChannelSelected;
            }

            dropDownEvent?.Invoke(dropDown, e);
        }

        public void PopulateDropDownList(ComboBox dropDown, IReadOnlyCollection<SocketEntity<UInt64>> items, string defaultDropDownText = "")
        {
            dropDown.InvokeWithRequiredCheck(() =>
            {
                dropDown.Items.Clear();

                foreach (SocketEntity<UInt64> item in items)
                {
                    dropDown.Items.Add(item);
                }

                // Setting the autocomplete stuff is an OLE operation, so we need a STA thread
                _ = EventUtils.RunActionOnSTAThread(
                () =>
                {
                    dropDown.AutoCompleteSource = AutoCompleteSource.ListItems;
                    dropDown.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                },
                // ...then we need the original thread to finish modifying the dropdown
                // so finish up in the callback (original context)
                () =>
                {
                    dropDown.DisplayMember = "ToString()";
                    dropDown.Text = defaultDropDownText;
                    dropDown.Enabled = true;
                });
            });
        }

        public void PopulateServerList(IReadOnlyCollection<SocketEntity<UInt64>> items)
        {
            PopulateDropDownList(ServerSelectDropDown, items, "Select a server...");
        }

        public void PopulateChannelList(IReadOnlyCollection<SocketEntity<UInt64>> items)
        {
            PopulateDropDownList(ChannelSelectDropDown, items, "Select a channel...");
        }

        public void ToggleSendLogButtonFunctionality(Boolean enabled)
        {
            SendLogToDiscordButton.InvokeWithRequiredCheck(() => SendLogToDiscordButton.Enabled = enabled);
        }

        private void OnLogSendButtonClicked(object sender, EventArgs args)
        {
            EventUtils.SendEventHandlerEventSafe(LogSendEvent, sender, args);
        }

        private async void LaunchAutomatedFileSelectDialog(object sender, EventArgs args)
        {
            await EventUtils.RunActionOnSTAThread(() => AutomatedLogFileSelectDialog.ShowDialog());
        }

        private void LoadSelectedFileIntoTextbox(object sender, CancelEventArgs args)
        {
            string fileContents = null;
            try
            {
                fileContents = File.ReadAllText(AutomatedLogFileSelectDialog.FileName);
            }
            catch (Exception e)
            {
                LogLine($"{e.GetType().Name}: {e.Message}");
                LogLine($"Exception occurred while loading log file {AutomatedLogFileSelectDialog.FileName}, please try again.");
            }

            if (string.IsNullOrWhiteSpace(fileContents))
            {
                return;
            }

            BotLogInputTextBox.InvokeWithRequiredCheck(() => BotLogInputTextBox.Text = fileContents);
        }
        #endregion

        #region System Tray Handlers

        public EventHandler OnApplicationClose;

        private void TwitchLogSplitterForm_GoToTray(object sender, FormClosingEventArgs e)
        {
            FrachatBotTrayIcon.Visible = true;

            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        private void TwitchLogSplitterForm_OnClickHandler(object sender, EventArgs e)
        {
            MouseEventArgs mouseEventArgs = e as MouseEventArgs;
            if (mouseEventArgs == null)
            {
                return;
            }

            if (mouseEventArgs.Button == MouseButtons.Left)
            {
                TwitchLogSplitterForm_ReturnFromTray(sender, e);
            }
        }

        private void TwitchLogSplitterForm_ReturnFromTray(object sender, EventArgs e)
        {
            FrachatBotTrayIcon.Visible = false;
            Show();
        }

        private void TwitchLogSplittingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            TwitchLogSplitterForm_GoToTray(sender, e);
        }

        private void CloseFrachatBot(object sender, EventArgs e)
        {
            this.Close();
            EventUtils.SendEventHandlerEventSafe(OnApplicationClose, sender, e);
        }

        #endregion
    }
}
