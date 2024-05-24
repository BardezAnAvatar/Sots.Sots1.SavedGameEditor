using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;

namespace Bardez.Project.Configuration
{
    public class ConfigurationHandler
    {
        private static Dictionary<String, KeyValueConfigurationElement> AppSettings;
        private static Dictionary<String, ConnectionStringSettings> ConnectionStrings;
        private static Boolean isNotInitialized = true;

        public static KeyValueConfigurationElement GetSetting(String Key)
        {
            if (isNotInitialized || AppSettings == null)
                Initialize();

            KeyValueConfigurationElement result;

            try
            {
                result = AppSettings[Key];
            }
            catch
            {
                result = null;
            }
            return result;
        }

        public static String GetSettingValue(String Key)
        {
            if (isNotInitialized || AppSettings == null)
                Initialize();

            String result;

            try
            {
                result = AppSettings[Key].Value;
            }
            catch
            {
                result = null;
            }
            return result;
        }

        public static Boolean GetBoolSettingValue(String Key, Boolean Default)
        {
            String result;
            Boolean boolValue = Default;

            if (isNotInitialized || AppSettings == null)
                Initialize();

            try { result = AppSettings[Key].Value; }
            catch { result = null; }

            if (null != result)
            {
                boolValue = GetBoolValue(result, Default);
            }

            return boolValue;
        }

        public static String GetConnectionString(String Key)
        {
            if (isNotInitialized || ConnectionStrings == null)
                Initialize();

            return ConnectionStrings[Key].ConnectionString;
        }


        private static Boolean GetBoolValue(String Value, Boolean Default)
        {
            Boolean boolValue;
            switch (Value.ToUpper())
            {
                case "TRUE":
                case "ON":
                case "1":
                case "YES":
                    boolValue = true;
                    break;
                case "FALSE":
                case "OFF":
                case "0":
                case "NO":
                    boolValue = false;
                    break;
                default:
                    boolValue = Default;
                    break;
            }

            return boolValue;
        }

        private static void Initialize()
        {
            AppSettings = new Dictionary<String, KeyValueConfigurationElement>();
            ConnectionStrings = new Dictionary<String, ConnectionStringSettings>();

            try
            {
                String readMachineConfig = ConfigurationManager.AppSettings["TrustedApplication"];
                if (readMachineConfig != null)
                {
                    readMachineConfig = readMachineConfig.ToUpper();

                    if (GetBoolValue(readMachineConfig, false))
                    {
                        //Read the Machine.config file
                        System.Configuration.Configuration machine;
                        machine = ConfigurationManager.OpenMachineConfiguration();
                        CopyKeys(machine, AppSettings, ConnectionStrings);
                    }
                }

                //Read the app.config file or web.config file
                LoadAppConfig();

                //look for <machinename>.config
                LoadMachineNameConfig();
            }
            catch
            {
                AppSettings = new Dictionary<String, KeyValueConfigurationElement>();
                ConnectionStrings = new Dictionary<String, ConnectionStringSettings>();
                CopyKeys(ConfigurationManager.AppSettings, ConfigurationManager.ConnectionStrings, AppSettings, ConnectionStrings);
            }

            //Now I has all m'keys...
            isNotInitialized = false;
        }

        private static void CopyKeys
        (
            System.Configuration.Configuration Config,
            Dictionary<String, KeyValueConfigurationElement> Settings,
            Dictionary<String, ConnectionStringSettings> ConnectionStrings
        )
        {
            //read all the settings
            foreach (KeyValueConfigurationElement pair in Config.AppSettings.Settings)
                Settings[pair.Key] = Config.AppSettings.Settings[pair.Key];

            foreach (ConnectionStringSettings key in Config.ConnectionStrings.ConnectionStrings)
                ConnectionStrings[key.Name] = Config.ConnectionStrings.ConnectionStrings[key.Name];
        }

        private static void CopyKeys
        (
            NameValueCollection AppSettings, ConnectionStringSettingsCollection ConnStrings,
            Dictionary<String, KeyValueConfigurationElement> Settings,
            Dictionary<String, ConnectionStringSettings> ConnectionStrings
        )
        {
            KeyValueConfigurationElement tempElement;
            KeyValueConfigurationCollection collection = new KeyValueConfigurationCollection();
            //read all the settings
            foreach (String key in AppSettings.Keys)
            {
                tempElement = new KeyValueConfigurationElement(key, AppSettings[key]);
                collection.Add(tempElement);
            }
            foreach (String key in AppSettings.Keys)
                Settings[key] = collection[key];

            foreach (ConnectionStringSettings key in ConnStrings)
                ConnectionStrings[key.Name] = ConnStrings[key.Name];
        }

        private static void LoadMachineNameConfig()
        {
            String path = System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase;
            String config = Environment.MachineName;
            path = path + "\\" + config + ".config";
            if (System.IO.File.Exists(path))
            {
                ExeConfigurationFileMap map = new ExeConfigurationFileMap();
                map.ExeConfigFilename = path;
                System.Configuration.Configuration configuration = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);

                //System.Configuration.Configuration configuration = ConfigurationManager.OpenExeConfiguration(path);
                CopyKeys(configuration, AppSettings, ConnectionStrings);
            }
        }

        private static void LoadAppConfig()
        {
            var configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            CopyKeys(configuration, AppSettings, ConnectionStrings);
        }

        private static String GetAssemblyPath()
        {
            String path = System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase;
            if (path.Substring(0, 8).ToLower() == "file:///")
            {
                path = path.Substring(8).Replace('/', '\\');

                //remove trailing paths.
                path = System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(path));
            }

            return path;
        }
    }
}