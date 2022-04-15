using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FrachatBot
{
    public static class FileUtils
    {
        public static bool HasFileExtension(string path, string fileExtension)
        {
            if (string.IsNullOrWhiteSpace(path) || string.IsNullOrWhiteSpace(fileExtension))
            {
                return false;
            }

            path = path.Replace("\"", string.Empty);

            if (!fileExtension.StartsWith("."))
            {
                fileExtension = $".{fileExtension}";
            }

            try
            {
                string extension = Path.GetExtension(path);
                if (string.Equals(extension.ToLower(), fileExtension))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (ArgumentException)
            {
                return false;
            }
        }

        public static string GetApplicationDataFolder(string applicationName)
        {
            string appData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            return Path.Combine(appData, applicationName);
        }

        public static string GetExecutableDirectory()
        {
            return Assembly.GetEntryAssembly().Location; 
        }

        public static string UseDefaultPathIfNotRooted(string path, string defaultPathIfNotRooted = "")
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                return defaultPathIfNotRooted;
            }

            path = path.Replace("\"", string.Empty);

            if (!Path.IsPathRooted(path))
            {
                return Path.Combine(defaultPathIfNotRooted, path);
            }

            return path;
        }
    }
}
