namespace FrachatBot
{
    partial class FrachatBotForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrachatBotForm));
            this.ManualTabSplitContainer = new System.Windows.Forms.SplitContainer();
            this.PrettifyLogCheckBox = new System.Windows.Forms.CheckBox();
            this.LogInputTextBox = new System.Windows.Forms.RichTextBox();
            this.LogSplitButton = new System.Windows.Forms.Button();
            this.LogInputLabel = new System.Windows.Forms.Label();
            this.LogOutputTabGroup = new System.Windows.Forms.TabControl();
            this.NormalTabPage = new System.Windows.Forms.TabPage();
            this.NormalTabFlowLayoutGroup = new System.Windows.Forms.FlowLayoutPanel();
            this.DebugTabPage = new System.Windows.Forms.TabPage();
            this.DebugFlowLayoutGroup = new System.Windows.Forms.FlowLayoutPanel();
            this.UploadMethodTabControl = new System.Windows.Forms.TabControl();
            this.ManualTab = new System.Windows.Forms.TabPage();
            this.DiscordTab = new System.Windows.Forms.TabPage();
            this.BotUploadGroupBox = new System.Windows.Forms.GroupBox();
            this.StepTwoGroupBox = new System.Windows.Forms.GroupBox();
            this.SendLogToDiscordButton = new System.Windows.Forms.Button();
            this.DiscordAutomationChannelSelectDropDown = new System.Windows.Forms.ComboBox();
            this.ChannelSelectLabel = new System.Windows.Forms.Label();
            this.ServerSelectLabel = new System.Windows.Forms.Label();
            this.DiscordAutomationServerSelectDropDown = new System.Windows.Forms.ComboBox();
            this.StepOneGroupBox = new System.Windows.Forms.GroupBox();
            this.BotLogInputTextBox = new System.Windows.Forms.RichTextBox();
            this.AutomatedLogFileSelectButton = new System.Windows.Forms.Button();
            this.BotManualUploadLabel = new System.Windows.Forms.Label();
            this.OrLabel = new System.Windows.Forms.Label();
            this.DiscordLogTextBox = new System.Windows.Forms.TextBox();
            this.LogLabel = new System.Windows.Forms.Label();
            this.BotStatusLabel = new System.Windows.Forms.Label();
            this.TwitchTabPage = new System.Windows.Forms.TabPage();
            this.TwitchChatTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TwitchStreamConfigGroupBox = new System.Windows.Forms.GroupBox();
            this.StreamConfigurationGroupBox = new System.Windows.Forms.GroupBox();
            this.streamConfigDiscordChannelDropDown = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.StreamConfigDiscordServerDropDown = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.streamConfigStreamTextBox = new System.Windows.Forms.TextBox();
            this.SelectedStreamStreamConfigLabel = new System.Windows.Forms.Label();
            this.StreamConfigStreamInputTextBox = new System.Windows.Forms.TextBox();
            this.StreamConfigStreamsLabel = new System.Windows.Forms.Label();
            this.StreamConfigKeyListBox = new System.Windows.Forms.ListBox();
            this.TwitchLogTextBox = new System.Windows.Forms.TextBox();
            this.TwitchLogLabel = new System.Windows.Forms.Label();
            this.DebugTab = new System.Windows.Forms.TabPage();
            this.DebugTestingButton = new System.Windows.Forms.Button();
            this.FrachatBotTrayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.FrachatBotSystemTrayContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ShowFrachatBotMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitFrachatBotMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AutomatedLogFileSelectDialog = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.ManualTabSplitContainer)).BeginInit();
            this.ManualTabSplitContainer.Panel1.SuspendLayout();
            this.ManualTabSplitContainer.Panel2.SuspendLayout();
            this.ManualTabSplitContainer.SuspendLayout();
            this.LogOutputTabGroup.SuspendLayout();
            this.NormalTabPage.SuspendLayout();
            this.DebugTabPage.SuspendLayout();
            this.UploadMethodTabControl.SuspendLayout();
            this.ManualTab.SuspendLayout();
            this.DiscordTab.SuspendLayout();
            this.BotUploadGroupBox.SuspendLayout();
            this.StepTwoGroupBox.SuspendLayout();
            this.StepOneGroupBox.SuspendLayout();
            this.TwitchTabPage.SuspendLayout();
            this.TwitchStreamConfigGroupBox.SuspendLayout();
            this.StreamConfigurationGroupBox.SuspendLayout();
            this.DebugTab.SuspendLayout();
            this.FrachatBotSystemTrayContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // ManualTabSplitContainer
            // 
            this.ManualTabSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ManualTabSplitContainer.Location = new System.Drawing.Point(3, 3);
            this.ManualTabSplitContainer.Name = "ManualTabSplitContainer";
            // 
            // ManualTabSplitContainer.Panel1
            // 
            this.ManualTabSplitContainer.Panel1.Controls.Add(this.PrettifyLogCheckBox);
            this.ManualTabSplitContainer.Panel1.Controls.Add(this.LogInputTextBox);
            this.ManualTabSplitContainer.Panel1.Controls.Add(this.LogSplitButton);
            this.ManualTabSplitContainer.Panel1.Controls.Add(this.LogInputLabel);
            // 
            // ManualTabSplitContainer.Panel2
            // 
            this.ManualTabSplitContainer.Panel2.Controls.Add(this.LogOutputTabGroup);
            this.ManualTabSplitContainer.Size = new System.Drawing.Size(1125, 884);
            this.ManualTabSplitContainer.SplitterDistance = 375;
            this.ManualTabSplitContainer.TabIndex = 4;
            // 
            // PrettifyLogCheckBox
            // 
            this.PrettifyLogCheckBox.Checked = true;
            this.PrettifyLogCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.PrettifyLogCheckBox.Location = new System.Drawing.Point(3, 834);
            this.PrettifyLogCheckBox.Name = "PrettifyLogCheckBox";
            this.PrettifyLogCheckBox.Size = new System.Drawing.Size(367, 17);
            this.PrettifyLogCheckBox.TabIndex = 3;
            this.PrettifyLogCheckBox.Text = "Prettify Log?";
            this.PrettifyLogCheckBox.UseVisualStyleBackColor = true;
            // 
            // LogInputTextBox
            // 
            this.LogInputTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LogInputTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LogInputTextBox.EnableAutoDragDrop = true;
            this.LogInputTextBox.Location = new System.Drawing.Point(3, 18);
            this.LogInputTextBox.Margin = new System.Windows.Forms.Padding(5);
            this.LogInputTextBox.Name = "LogInputTextBox";
            this.LogInputTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.LogInputTextBox.Size = new System.Drawing.Size(367, 808);
            this.LogInputTextBox.TabIndex = 1;
            this.LogInputTextBox.Text = "";
            // 
            // LogSplitButton
            // 
            this.LogSplitButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LogSplitButton.Location = new System.Drawing.Point(0, 857);
            this.LogSplitButton.Name = "LogSplitButton";
            this.LogSplitButton.Size = new System.Drawing.Size(375, 27);
            this.LogSplitButton.TabIndex = 2;
            this.LogSplitButton.Text = "Split Logs";
            this.LogSplitButton.UseVisualStyleBackColor = true;
            this.LogSplitButton.Click += new System.EventHandler(this.LogSplitButton_Click);
            // 
            // LogInputLabel
            // 
            this.LogInputLabel.AutoSize = true;
            this.LogInputLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.LogInputLabel.Location = new System.Drawing.Point(0, 0);
            this.LogInputLabel.Margin = new System.Windows.Forms.Padding(3);
            this.LogInputLabel.Name = "LogInputLabel";
            this.LogInputLabel.Size = new System.Drawing.Size(78, 13);
            this.LogInputLabel.TabIndex = 0;
            this.LogInputLabel.Text = "Paste log here:";
            // 
            // LogOutputTabGroup
            // 
            this.LogOutputTabGroup.Controls.Add(this.NormalTabPage);
            this.LogOutputTabGroup.Controls.Add(this.DebugTabPage);
            this.LogOutputTabGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LogOutputTabGroup.Location = new System.Drawing.Point(0, 0);
            this.LogOutputTabGroup.Name = "LogOutputTabGroup";
            this.LogOutputTabGroup.SelectedIndex = 0;
            this.LogOutputTabGroup.Size = new System.Drawing.Size(746, 884);
            this.LogOutputTabGroup.TabIndex = 1;
            // 
            // NormalTabPage
            // 
            this.NormalTabPage.Controls.Add(this.NormalTabFlowLayoutGroup);
            this.NormalTabPage.Location = new System.Drawing.Point(4, 22);
            this.NormalTabPage.Name = "NormalTabPage";
            this.NormalTabPage.Padding = new System.Windows.Forms.Padding(5);
            this.NormalTabPage.Size = new System.Drawing.Size(738, 858);
            this.NormalTabPage.TabIndex = 0;
            this.NormalTabPage.Text = "Normal";
            this.NormalTabPage.UseVisualStyleBackColor = true;
            // 
            // NormalTabFlowLayoutGroup
            // 
            this.NormalTabFlowLayoutGroup.AutoScroll = true;
            this.NormalTabFlowLayoutGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NormalTabFlowLayoutGroup.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.NormalTabFlowLayoutGroup.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.NormalTabFlowLayoutGroup.Location = new System.Drawing.Point(5, 5);
            this.NormalTabFlowLayoutGroup.Name = "NormalTabFlowLayoutGroup";
            this.NormalTabFlowLayoutGroup.Padding = new System.Windows.Forms.Padding(5);
            this.NormalTabFlowLayoutGroup.Size = new System.Drawing.Size(728, 848);
            this.NormalTabFlowLayoutGroup.TabIndex = 1;
            this.NormalTabFlowLayoutGroup.WrapContents = false;
            // 
            // DebugTabPage
            // 
            this.DebugTabPage.Controls.Add(this.DebugFlowLayoutGroup);
            this.DebugTabPage.Location = new System.Drawing.Point(4, 22);
            this.DebugTabPage.Name = "DebugTabPage";
            this.DebugTabPage.Padding = new System.Windows.Forms.Padding(5);
            this.DebugTabPage.Size = new System.Drawing.Size(738, 847);
            this.DebugTabPage.TabIndex = 1;
            this.DebugTabPage.Text = "DebugTabPage";
            this.DebugTabPage.UseVisualStyleBackColor = true;
            // 
            // DebugFlowLayoutGroup
            // 
            this.DebugFlowLayoutGroup.AutoScroll = true;
            this.DebugFlowLayoutGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DebugFlowLayoutGroup.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.DebugFlowLayoutGroup.Location = new System.Drawing.Point(5, 5);
            this.DebugFlowLayoutGroup.Name = "DebugFlowLayoutGroup";
            this.DebugFlowLayoutGroup.Size = new System.Drawing.Size(728, 837);
            this.DebugFlowLayoutGroup.TabIndex = 0;
            this.DebugFlowLayoutGroup.WrapContents = false;
            // 
            // UploadMethodTabControl
            // 
            this.UploadMethodTabControl.Controls.Add(this.ManualTab);
            this.UploadMethodTabControl.Controls.Add(this.DiscordTab);
            this.UploadMethodTabControl.Controls.Add(this.TwitchTabPage);
            this.UploadMethodTabControl.Controls.Add(this.DebugTab);
            this.UploadMethodTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UploadMethodTabControl.Location = new System.Drawing.Point(0, 0);
            this.UploadMethodTabControl.Name = "UploadMethodTabControl";
            this.UploadMethodTabControl.SelectedIndex = 0;
            this.UploadMethodTabControl.Size = new System.Drawing.Size(1139, 916);
            this.UploadMethodTabControl.TabIndex = 1;
            // 
            // ManualTab
            // 
            this.ManualTab.Controls.Add(this.ManualTabSplitContainer);
            this.ManualTab.Location = new System.Drawing.Point(4, 22);
            this.ManualTab.Name = "ManualTab";
            this.ManualTab.Padding = new System.Windows.Forms.Padding(3);
            this.ManualTab.Size = new System.Drawing.Size(1131, 890);
            this.ManualTab.TabIndex = 0;
            this.ManualTab.Text = "Manual";
            this.ManualTab.UseVisualStyleBackColor = true;
            // 
            // DiscordTab
            // 
            this.DiscordTab.Controls.Add(this.BotUploadGroupBox);
            this.DiscordTab.Controls.Add(this.DiscordLogTextBox);
            this.DiscordTab.Controls.Add(this.LogLabel);
            this.DiscordTab.Controls.Add(this.BotStatusLabel);
            this.DiscordTab.Location = new System.Drawing.Point(4, 22);
            this.DiscordTab.Name = "DiscordTab";
            this.DiscordTab.Padding = new System.Windows.Forms.Padding(3);
            this.DiscordTab.Size = new System.Drawing.Size(1131, 890);
            this.DiscordTab.TabIndex = 1;
            this.DiscordTab.Text = "Discord";
            this.DiscordTab.UseVisualStyleBackColor = true;
            // 
            // BotUploadGroupBox
            // 
            this.BotUploadGroupBox.Controls.Add(this.StepTwoGroupBox);
            this.BotUploadGroupBox.Controls.Add(this.StepOneGroupBox);
            this.BotUploadGroupBox.Location = new System.Drawing.Point(7, 365);
            this.BotUploadGroupBox.Name = "BotUploadGroupBox";
            this.BotUploadGroupBox.Size = new System.Drawing.Size(1116, 517);
            this.BotUploadGroupBox.TabIndex = 3;
            this.BotUploadGroupBox.TabStop = false;
            this.BotUploadGroupBox.Text = "BotUpload";
            // 
            // StepTwoGroupBox
            // 
            this.StepTwoGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StepTwoGroupBox.Controls.Add(this.SendLogToDiscordButton);
            this.StepTwoGroupBox.Controls.Add(this.DiscordAutomationChannelSelectDropDown);
            this.StepTwoGroupBox.Controls.Add(this.ChannelSelectLabel);
            this.StepTwoGroupBox.Controls.Add(this.ServerSelectLabel);
            this.StepTwoGroupBox.Controls.Add(this.DiscordAutomationServerSelectDropDown);
            this.StepTwoGroupBox.Location = new System.Drawing.Point(559, 20);
            this.StepTwoGroupBox.Name = "StepTwoGroupBox";
            this.StepTwoGroupBox.Size = new System.Drawing.Size(551, 490);
            this.StepTwoGroupBox.TabIndex = 7;
            this.StepTwoGroupBox.TabStop = false;
            this.StepTwoGroupBox.Text = "2. Configure where to send it";
            // 
            // SendLogToDiscordButton
            // 
            this.SendLogToDiscordButton.Enabled = false;
            this.SendLogToDiscordButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SendLogToDiscordButton.Location = new System.Drawing.Point(22, 128);
            this.SendLogToDiscordButton.Name = "SendLogToDiscordButton";
            this.SendLogToDiscordButton.Size = new System.Drawing.Size(505, 346);
            this.SendLogToDiscordButton.TabIndex = 4;
            this.SendLogToDiscordButton.Text = "Send the log!";
            this.SendLogToDiscordButton.UseVisualStyleBackColor = true;
            this.SendLogToDiscordButton.Click += new System.EventHandler(this.OnLogSendButtonClicked);
            // 
            // DiscordAutomationChannelSelectDropDown
            // 
            this.DiscordAutomationChannelSelectDropDown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DiscordAutomationChannelSelectDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DiscordAutomationChannelSelectDropDown.Enabled = false;
            this.DiscordAutomationChannelSelectDropDown.FormattingEnabled = true;
            this.DiscordAutomationChannelSelectDropDown.Location = new System.Drawing.Point(22, 76);
            this.DiscordAutomationChannelSelectDropDown.Name = "DiscordAutomationChannelSelectDropDown";
            this.DiscordAutomationChannelSelectDropDown.Size = new System.Drawing.Size(505, 21);
            this.DiscordAutomationChannelSelectDropDown.TabIndex = 3;
            this.DiscordAutomationChannelSelectDropDown.SelectedIndexChanged += new System.EventHandler(this.OnDropDownSelected);
            // 
            // ChannelSelectLabel
            // 
            this.ChannelSelectLabel.AutoSize = true;
            this.ChannelSelectLabel.Location = new System.Drawing.Point(6, 59);
            this.ChannelSelectLabel.Name = "ChannelSelectLabel";
            this.ChannelSelectLabel.Size = new System.Drawing.Size(99, 13);
            this.ChannelSelectLabel.TabIndex = 2;
            this.ChannelSelectLabel.Text = "Select the channel:";
            // 
            // ServerSelectLabel
            // 
            this.ServerSelectLabel.AutoSize = true;
            this.ServerSelectLabel.Location = new System.Drawing.Point(6, 17);
            this.ServerSelectLabel.Name = "ServerSelectLabel";
            this.ServerSelectLabel.Size = new System.Drawing.Size(90, 13);
            this.ServerSelectLabel.TabIndex = 1;
            this.ServerSelectLabel.Text = "Select the server:";
            // 
            // DiscordAutomationServerSelectDropDown
            // 
            this.DiscordAutomationServerSelectDropDown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DiscordAutomationServerSelectDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DiscordAutomationServerSelectDropDown.Enabled = false;
            this.DiscordAutomationServerSelectDropDown.FormattingEnabled = true;
            this.DiscordAutomationServerSelectDropDown.Location = new System.Drawing.Point(22, 35);
            this.DiscordAutomationServerSelectDropDown.Name = "DiscordAutomationServerSelectDropDown";
            this.DiscordAutomationServerSelectDropDown.Size = new System.Drawing.Size(505, 21);
            this.DiscordAutomationServerSelectDropDown.TabIndex = 0;
            this.DiscordAutomationServerSelectDropDown.SelectedIndexChanged += new System.EventHandler(this.OnDropDownSelected);
            this.DiscordAutomationServerSelectDropDown.Click += new System.EventHandler(this.ServerRefreshRequested);
            // 
            // StepOneGroupBox
            // 
            this.StepOneGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StepOneGroupBox.Controls.Add(this.BotLogInputTextBox);
            this.StepOneGroupBox.Controls.Add(this.AutomatedLogFileSelectButton);
            this.StepOneGroupBox.Controls.Add(this.BotManualUploadLabel);
            this.StepOneGroupBox.Controls.Add(this.OrLabel);
            this.StepOneGroupBox.Location = new System.Drawing.Point(6, 19);
            this.StepOneGroupBox.Name = "StepOneGroupBox";
            this.StepOneGroupBox.Size = new System.Drawing.Size(547, 491);
            this.StepOneGroupBox.TabIndex = 6;
            this.StepOneGroupBox.TabStop = false;
            this.StepOneGroupBox.Text = "1. Select the log";
            // 
            // BotLogInputTextBox
            // 
            this.BotLogInputTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BotLogInputTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BotLogInputTextBox.EnableAutoDragDrop = true;
            this.BotLogInputTextBox.Location = new System.Drawing.Point(11, 36);
            this.BotLogInputTextBox.Margin = new System.Windows.Forms.Padding(5);
            this.BotLogInputTextBox.Name = "BotLogInputTextBox";
            this.BotLogInputTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.BotLogInputTextBox.Size = new System.Drawing.Size(528, 355);
            this.BotLogInputTextBox.TabIndex = 2;
            this.BotLogInputTextBox.Text = "";
            this.BotLogInputTextBox.TextChanged += new System.EventHandler(this.OnDiscordLogModified);
            // 
            // AutomatedLogFileSelectButton
            // 
            this.AutomatedLogFileSelectButton.Location = new System.Drawing.Point(11, 425);
            this.AutomatedLogFileSelectButton.Name = "AutomatedLogFileSelectButton";
            this.AutomatedLogFileSelectButton.Size = new System.Drawing.Size(528, 51);
            this.AutomatedLogFileSelectButton.TabIndex = 5;
            this.AutomatedLogFileSelectButton.Text = "Select the log file here (Opens a file dialog)";
            this.AutomatedLogFileSelectButton.UseVisualStyleBackColor = true;
            this.AutomatedLogFileSelectButton.Click += new System.EventHandler(this.LaunchAutomatedFileSelectDialog);
            // 
            // BotManualUploadLabel
            // 
            this.BotManualUploadLabel.AutoSize = true;
            this.BotManualUploadLabel.Location = new System.Drawing.Point(8, 18);
            this.BotManualUploadLabel.Name = "BotManualUploadLabel";
            this.BotManualUploadLabel.Size = new System.Drawing.Size(98, 13);
            this.BotManualUploadLabel.TabIndex = 3;
            this.BotManualUploadLabel.Text = "Paste log text here:";
            // 
            // OrLabel
            // 
            this.OrLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OrLabel.AutoSize = true;
            this.OrLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OrLabel.Location = new System.Drawing.Point(256, 396);
            this.OrLabel.Name = "OrLabel";
            this.OrLabel.Size = new System.Drawing.Size(45, 26);
            this.OrLabel.TabIndex = 4;
            this.OrLabel.Text = "OR";
            this.OrLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DiscordLogTextBox
            // 
            this.DiscordLogTextBox.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DiscordLogTextBox.Location = new System.Drawing.Point(13, 20);
            this.DiscordLogTextBox.Multiline = true;
            this.DiscordLogTextBox.Name = "DiscordLogTextBox";
            this.DiscordLogTextBox.ReadOnly = true;
            this.DiscordLogTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DiscordLogTextBox.Size = new System.Drawing.Size(1110, 316);
            this.DiscordLogTextBox.TabIndex = 2;
            // 
            // LogLabel
            // 
            this.LogLabel.AutoSize = true;
            this.LogLabel.Location = new System.Drawing.Point(3, 3);
            this.LogLabel.Name = "LogLabel";
            this.LogLabel.Size = new System.Drawing.Size(83, 13);
            this.LogLabel.TabIndex = 1;
            this.LogLabel.Text = "Discord Bot Log";
            // 
            // BotStatusLabel
            // 
            this.BotStatusLabel.AutoSize = true;
            this.BotStatusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BotStatusLabel.Location = new System.Drawing.Point(5, 344);
            this.BotStatusLabel.Margin = new System.Windows.Forms.Padding(5);
            this.BotStatusLabel.Name = "BotStatusLabel";
            this.BotStatusLabel.Size = new System.Drawing.Size(70, 13);
            this.BotStatusLabel.TabIndex = 0;
            this.BotStatusLabel.Text = "Bot Status:";
            // 
            // TwitchTabPage
            // 
            this.TwitchTabPage.Controls.Add(this.TwitchChatTextBox);
            this.TwitchTabPage.Controls.Add(this.label1);
            this.TwitchTabPage.Controls.Add(this.TwitchStreamConfigGroupBox);
            this.TwitchTabPage.Controls.Add(this.TwitchLogTextBox);
            this.TwitchTabPage.Controls.Add(this.TwitchLogLabel);
            this.TwitchTabPage.Location = new System.Drawing.Point(4, 22);
            this.TwitchTabPage.Name = "TwitchTabPage";
            this.TwitchTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.TwitchTabPage.Size = new System.Drawing.Size(1131, 890);
            this.TwitchTabPage.TabIndex = 3;
            this.TwitchTabPage.Text = "Twitch Int.";
            this.TwitchTabPage.UseVisualStyleBackColor = true;
            // 
            // TwitchChatTextBox
            // 
            this.TwitchChatTextBox.Location = new System.Drawing.Point(7, 516);
            this.TwitchChatTextBox.Multiline = true;
            this.TwitchChatTextBox.Name = "TwitchChatTextBox";
            this.TwitchChatTextBox.ReadOnly = true;
            this.TwitchChatTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TwitchChatTextBox.Size = new System.Drawing.Size(1116, 366);
            this.TwitchChatTextBox.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 499);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "ChatLogMonitor";
            // 
            // TwitchStreamConfigGroupBox
            // 
            this.TwitchStreamConfigGroupBox.Controls.Add(this.StreamConfigurationGroupBox);
            this.TwitchStreamConfigGroupBox.Controls.Add(this.StreamConfigStreamInputTextBox);
            this.TwitchStreamConfigGroupBox.Controls.Add(this.StreamConfigStreamsLabel);
            this.TwitchStreamConfigGroupBox.Controls.Add(this.StreamConfigKeyListBox);
            this.TwitchStreamConfigGroupBox.Location = new System.Drawing.Point(9, 253);
            this.TwitchStreamConfigGroupBox.Name = "TwitchStreamConfigGroupBox";
            this.TwitchStreamConfigGroupBox.Size = new System.Drawing.Size(1114, 239);
            this.TwitchStreamConfigGroupBox.TabIndex = 2;
            this.TwitchStreamConfigGroupBox.TabStop = false;
            this.TwitchStreamConfigGroupBox.Text = "Config";
            // 
            // StreamConfigurationGroupBox
            // 
            this.StreamConfigurationGroupBox.Controls.Add(this.streamConfigDiscordChannelDropDown);
            this.StreamConfigurationGroupBox.Controls.Add(this.label3);
            this.StreamConfigurationGroupBox.Controls.Add(this.StreamConfigDiscordServerDropDown);
            this.StreamConfigurationGroupBox.Controls.Add(this.label2);
            this.StreamConfigurationGroupBox.Controls.Add(this.streamConfigStreamTextBox);
            this.StreamConfigurationGroupBox.Controls.Add(this.SelectedStreamStreamConfigLabel);
            this.StreamConfigurationGroupBox.Location = new System.Drawing.Point(211, 20);
            this.StreamConfigurationGroupBox.Name = "StreamConfigurationGroupBox";
            this.StreamConfigurationGroupBox.Size = new System.Drawing.Size(306, 213);
            this.StreamConfigurationGroupBox.TabIndex = 3;
            this.StreamConfigurationGroupBox.TabStop = false;
            this.StreamConfigurationGroupBox.Text = "Stream Configuration";
            // 
            // streamConfigDiscordChannelDropDown
            // 
            this.streamConfigDiscordChannelDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.streamConfigDiscordChannelDropDown.FormattingEnabled = true;
            this.streamConfigDiscordChannelDropDown.Location = new System.Drawing.Point(10, 121);
            this.streamConfigDiscordChannelDropDown.Name = "streamConfigDiscordChannelDropDown";
            this.streamConfigDiscordChannelDropDown.Size = new System.Drawing.Size(290, 21);
            this.streamConfigDiscordChannelDropDown.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Selected Discord Channel:";
            // 
            // StreamConfigDiscordServerDropDown
            // 
            this.StreamConfigDiscordServerDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.StreamConfigDiscordServerDropDown.FormattingEnabled = true;
            this.StreamConfigDiscordServerDropDown.Location = new System.Drawing.Point(10, 76);
            this.StreamConfigDiscordServerDropDown.Name = "StreamConfigDiscordServerDropDown";
            this.StreamConfigDiscordServerDropDown.Size = new System.Drawing.Size(290, 21);
            this.StreamConfigDiscordServerDropDown.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Selected Discord Server:";
            // 
            // streamConfigStreamTextBox
            // 
            this.streamConfigStreamTextBox.Location = new System.Drawing.Point(10, 36);
            this.streamConfigStreamTextBox.Name = "streamConfigStreamTextBox";
            this.streamConfigStreamTextBox.Size = new System.Drawing.Size(116, 20);
            this.streamConfigStreamTextBox.TabIndex = 1;
            // 
            // SelectedStreamStreamConfigLabel
            // 
            this.SelectedStreamStreamConfigLabel.AutoSize = true;
            this.SelectedStreamStreamConfigLabel.Location = new System.Drawing.Point(7, 20);
            this.SelectedStreamStreamConfigLabel.Name = "SelectedStreamStreamConfigLabel";
            this.SelectedStreamStreamConfigLabel.Size = new System.Drawing.Size(88, 13);
            this.SelectedStreamStreamConfigLabel.TabIndex = 0;
            this.SelectedStreamStreamConfigLabel.Text = "Selected Stream:";
            // 
            // StreamConfigStreamInputTextBox
            // 
            this.StreamConfigStreamInputTextBox.Location = new System.Drawing.Point(11, 202);
            this.StreamConfigStreamInputTextBox.Name = "StreamConfigStreamInputTextBox";
            this.StreamConfigStreamInputTextBox.Size = new System.Drawing.Size(194, 20);
            this.StreamConfigStreamInputTextBox.TabIndex = 2;
            // 
            // StreamConfigStreamsLabel
            // 
            this.StreamConfigStreamsLabel.AutoSize = true;
            this.StreamConfigStreamsLabel.Location = new System.Drawing.Point(7, 20);
            this.StreamConfigStreamsLabel.Name = "StreamConfigStreamsLabel";
            this.StreamConfigStreamsLabel.Size = new System.Drawing.Size(48, 13);
            this.StreamConfigStreamsLabel.TabIndex = 1;
            this.StreamConfigStreamsLabel.Text = "Streams:";
            // 
            // StreamConfigKeyListBox
            // 
            this.StreamConfigKeyListBox.FormattingEnabled = true;
            this.StreamConfigKeyListBox.ImeMode = System.Windows.Forms.ImeMode.On;
            this.StreamConfigKeyListBox.Items.AddRange(new object[] {
            "clamhat",
            "ryukred_",
            "graceandglory"});
            this.StreamConfigKeyListBox.Location = new System.Drawing.Point(10, 36);
            this.StreamConfigKeyListBox.Name = "StreamConfigKeyListBox";
            this.StreamConfigKeyListBox.Size = new System.Drawing.Size(195, 160);
            this.StreamConfigKeyListBox.TabIndex = 0;
            // 
            // TwitchLogTextBox
            // 
            this.TwitchLogTextBox.Location = new System.Drawing.Point(10, 24);
            this.TwitchLogTextBox.Multiline = true;
            this.TwitchLogTextBox.Name = "TwitchLogTextBox";
            this.TwitchLogTextBox.ReadOnly = true;
            this.TwitchLogTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TwitchLogTextBox.Size = new System.Drawing.Size(1113, 222);
            this.TwitchLogTextBox.TabIndex = 1;
            // 
            // TwitchLogLabel
            // 
            this.TwitchLogLabel.AutoSize = true;
            this.TwitchLogLabel.Location = new System.Drawing.Point(7, 7);
            this.TwitchLogLabel.Name = "TwitchLogLabel";
            this.TwitchLogLabel.Size = new System.Drawing.Size(82, 13);
            this.TwitchLogLabel.TabIndex = 0;
            this.TwitchLogLabel.Text = "Twitch Bot Log:";
            // 
            // DebugTab
            // 
            this.DebugTab.Controls.Add(this.DebugTestingButton);
            this.DebugTab.Location = new System.Drawing.Point(4, 22);
            this.DebugTab.Name = "DebugTab";
            this.DebugTab.Padding = new System.Windows.Forms.Padding(3);
            this.DebugTab.Size = new System.Drawing.Size(1131, 890);
            this.DebugTab.TabIndex = 2;
            this.DebugTab.Text = "Debug";
            this.DebugTab.UseVisualStyleBackColor = true;
            // 
            // DebugTestingButton
            // 
            this.DebugTestingButton.Location = new System.Drawing.Point(8, 6);
            this.DebugTestingButton.Name = "DebugTestingButton";
            this.DebugTestingButton.Size = new System.Drawing.Size(487, 100);
            this.DebugTestingButton.TabIndex = 0;
            this.DebugTestingButton.Text = "Button for testing whatever is in Click";
            this.DebugTestingButton.UseVisualStyleBackColor = true;
            // 
            // FrachatBotTrayIcon
            // 
            this.FrachatBotTrayIcon.BalloonTipText = "FrachatBot sleep mode";
            this.FrachatBotTrayIcon.BalloonTipTitle = "FrachatBot";
            this.FrachatBotTrayIcon.ContextMenuStrip = this.FrachatBotSystemTrayContextMenu;
            this.FrachatBotTrayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("FrachatBotTrayIcon.Icon")));
            this.FrachatBotTrayIcon.Text = "FrachatBot";
            this.FrachatBotTrayIcon.Click += new System.EventHandler(this.TwitchLogSplitterForm_OnClickHandler);
            // 
            // FrachatBotSystemTrayContextMenu
            // 
            this.FrachatBotSystemTrayContextMenu.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.FrachatBotSystemTrayContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ShowFrachatBotMenuItem,
            this.ExitFrachatBotMenuItem});
            this.FrachatBotSystemTrayContextMenu.Name = "FrachatBotSystemTrayContextMenu";
            this.FrachatBotSystemTrayContextMenu.Size = new System.Drawing.Size(239, 48);
            // 
            // ShowFrachatBotMenuItem
            // 
            this.ShowFrachatBotMenuItem.Name = "ShowFrachatBotMenuItem";
            this.ShowFrachatBotMenuItem.Size = new System.Drawing.Size(238, 22);
            this.ShowFrachatBotMenuItem.Text = "Show FrachatBot Control Panel";
            this.ShowFrachatBotMenuItem.Click += new System.EventHandler(this.TwitchLogSplitterForm_ReturnFromTray);
            // 
            // ExitFrachatBotMenuItem
            // 
            this.ExitFrachatBotMenuItem.Name = "ExitFrachatBotMenuItem";
            this.ExitFrachatBotMenuItem.Size = new System.Drawing.Size(238, 22);
            this.ExitFrachatBotMenuItem.Text = "Close FrachatBot";
            this.ExitFrachatBotMenuItem.Click += new System.EventHandler(this.CloseFrachatBot);
            // 
            // AutomatedLogFileSelectDialog
            // 
            this.AutomatedLogFileSelectDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.LoadSelectedFileIntoTextbox);
            // 
            // FrachatBotForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1139, 916);
            this.Controls.Add(this.UploadMethodTabControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrachatBotForm";
            this.Text = "FrachatBot Control Panel";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TwitchLogSplittingForm_FormClosing);
            this.ManualTabSplitContainer.Panel1.ResumeLayout(false);
            this.ManualTabSplitContainer.Panel1.PerformLayout();
            this.ManualTabSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ManualTabSplitContainer)).EndInit();
            this.ManualTabSplitContainer.ResumeLayout(false);
            this.LogOutputTabGroup.ResumeLayout(false);
            this.NormalTabPage.ResumeLayout(false);
            this.DebugTabPage.ResumeLayout(false);
            this.UploadMethodTabControl.ResumeLayout(false);
            this.ManualTab.ResumeLayout(false);
            this.DiscordTab.ResumeLayout(false);
            this.DiscordTab.PerformLayout();
            this.BotUploadGroupBox.ResumeLayout(false);
            this.StepTwoGroupBox.ResumeLayout(false);
            this.StepTwoGroupBox.PerformLayout();
            this.StepOneGroupBox.ResumeLayout(false);
            this.StepOneGroupBox.PerformLayout();
            this.TwitchTabPage.ResumeLayout(false);
            this.TwitchTabPage.PerformLayout();
            this.TwitchStreamConfigGroupBox.ResumeLayout(false);
            this.TwitchStreamConfigGroupBox.PerformLayout();
            this.StreamConfigurationGroupBox.ResumeLayout(false);
            this.StreamConfigurationGroupBox.PerformLayout();
            this.DebugTab.ResumeLayout(false);
            this.FrachatBotSystemTrayContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label LogInputLabel;
        private System.Windows.Forms.Button LogSplitButton;
        private System.Windows.Forms.CheckBox PrettifyLogCheckBox;
        private System.Windows.Forms.TabControl LogOutputTabGroup;
        private System.Windows.Forms.TabPage NormalTabPage;
        private System.Windows.Forms.TabPage DebugTabPage;
        private System.Windows.Forms.FlowLayoutPanel NormalTabFlowLayoutGroup;
        private System.Windows.Forms.FlowLayoutPanel DebugFlowLayoutGroup;
        private System.Windows.Forms.TabControl UploadMethodTabControl;
        private System.Windows.Forms.TabPage ManualTab;
        private System.Windows.Forms.TabPage DiscordTab;
        private System.Windows.Forms.RichTextBox LogInputTextBox;
        private System.Windows.Forms.SplitContainer ManualTabSplitContainer;
        private System.Windows.Forms.Label BotStatusLabel;
        private System.Windows.Forms.TextBox DiscordLogTextBox;
        private System.Windows.Forms.Label LogLabel;
        private System.Windows.Forms.GroupBox BotUploadGroupBox;
        private System.Windows.Forms.GroupBox StepTwoGroupBox;
        private System.Windows.Forms.Button SendLogToDiscordButton;
        private System.Windows.Forms.ComboBox DiscordAutomationChannelSelectDropDown;
        private System.Windows.Forms.Label ChannelSelectLabel;
        private System.Windows.Forms.Label ServerSelectLabel;
        private System.Windows.Forms.ComboBox DiscordAutomationServerSelectDropDown;
        private System.Windows.Forms.GroupBox StepOneGroupBox;
        private System.Windows.Forms.RichTextBox BotLogInputTextBox;
        private System.Windows.Forms.Button AutomatedLogFileSelectButton;
        private System.Windows.Forms.Label BotManualUploadLabel;
        private System.Windows.Forms.Label OrLabel;
        private System.Windows.Forms.NotifyIcon FrachatBotTrayIcon;
        private System.Windows.Forms.ContextMenuStrip FrachatBotSystemTrayContextMenu;
        private System.Windows.Forms.ToolStripMenuItem ShowFrachatBotMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExitFrachatBotMenuItem;
        private System.Windows.Forms.OpenFileDialog AutomatedLogFileSelectDialog;
        private System.Windows.Forms.TabPage DebugTab;
        private System.Windows.Forms.Button DebugTestingButton;
        private System.Windows.Forms.TabPage TwitchTabPage;
        private System.Windows.Forms.TextBox TwitchChatTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox TwitchStreamConfigGroupBox;
        private System.Windows.Forms.TextBox TwitchLogTextBox;
        private System.Windows.Forms.Label TwitchLogLabel;
        private System.Windows.Forms.ListBox StreamConfigKeyListBox;
        private System.Windows.Forms.Label StreamConfigStreamsLabel;
        private System.Windows.Forms.GroupBox StreamConfigurationGroupBox;
        private System.Windows.Forms.TextBox StreamConfigStreamInputTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox streamConfigStreamTextBox;
        private System.Windows.Forms.Label SelectedStreamStreamConfigLabel;
        private System.Windows.Forms.ComboBox streamConfigDiscordChannelDropDown;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox StreamConfigDiscordServerDropDown;
    }
}

