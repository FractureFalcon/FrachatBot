using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrachatBot
{
    public class FrachatBotConfigManager
    {
        public FrachatBotForm frachatBotForm;
        private const string defaultConfigFileName = "config\\default.json";
        private readonly string defaultConfigFilePath;
        private const string configFileName = "default.json";
        private readonly string configFolderPath;
        private readonly string configFilePath;

        private FileSystemWatcher configFileWatcher;
        private FrachatBotConfig config;

        public TwitchArchiveConfig GetArchiveConfig(string stream)
        {
            TwitchArchiveConfig configToFind;
            config.twitchArchiveConfigs.TryGetValue(stream, out configToFind);
            return configToFind;
        }

        public void AddArchiveConfig(string stream)
        {
            if (string.IsNullOrWhiteSpace(stream) || config.twitchArchiveConfigs.ContainsKey(stream))
            {
                return;
            }

            config.twitchArchiveConfigs.Add(stream, new TwitchArchiveConfig());
        }

        public void SetArchiveConfig(string stream, string discordServer, string discordChannel)
        {
            if (!config.twitchArchiveConfigs.ContainsKey(stream))
            {
                return;
            }

            config.twitchArchiveConfigs[stream].discordServer = discordServer;
            config.twitchArchiveConfigs[stream].discordChannel = discordChannel;
        }

        public FrachatBotConfigManager(FrachatBotForm frachatBot)
        {
            configFolderPath = FileUtils.GetApplicationDataFolder(FrachatBotConfig.FrachatBotAppName);
            configFolderPath = Path.Combine(configFolderPath, "config");
            configFilePath = Path.Combine(configFolderPath, configFileName);
            string exeDirectory = Path.GetDirectoryName(FileUtils.GetExecutableDirectory());
            defaultConfigFilePath = Path.Combine(exeDirectory, defaultConfigFileName);
            InitializeConfigFile();
            InitializeConfigFileWatcher();
        }

        private void InitializeConfigFile()
        {
            SetupDefaultConfig();

            LoadConfig();
        }

        private void InitializeConfigFileWatcher()
        {
            configFileWatcher = new FileSystemWatcher(configFolderPath);
            configFileWatcher.Filter = configFileName;
            configFileWatcher.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.FileName;
            configFileWatcher.IncludeSubdirectories = false;
            configFileWatcher.EnableRaisingEvents = true;

            configFileWatcher.Changed += OnConfigFileChanged;
            configFileWatcher.Deleted += OnConfigFileDeletedOrRenamed;
            configFileWatcher.Renamed += OnConfigFileDeletedOrRenamed;
        }

        private void RefreshConfigDisplay()
        {
            string stream = frachatBotForm.GetSelectedStreamConfig();
        }

        private void OnConfigFileChanged(object sender, FileSystemEventArgs args)
        {
            LoadConfig();
        }

        private void OnConfigFileDeletedOrRenamed(object sender, FileSystemEventArgs args)
        {
            SetupDefaultConfig();
        }

        private void SetupDefaultConfig()
        {
            if (!File.Exists(configFilePath))
            {
                if (!Directory.Exists(configFolderPath))
                {
                    Directory.CreateDirectory(configFolderPath);
                }

                File.Copy(defaultConfigFilePath, configFilePath);
            }
        }

        private void LoadConfig()
        {
            string configText = File.ReadAllText(configFilePath);
            FrachatBotConfig newConfig = JsonConvert.DeserializeObject<FrachatBotConfig>(configText);

            if (newConfig == null)
            {
                if (config.twitchArchiveConfigs.Count == 0)
                {
                    throw new FrachatBotConfigException();
                }

                // TODO: Error log something here
                return;
            }

            config = newConfig;
        }

        private void SaveConfig()
        {
            string fileText = JsonConvert.SerializeObject(config);
            File.WriteAllText(configFilePath, fileText);
        }
    }
}
