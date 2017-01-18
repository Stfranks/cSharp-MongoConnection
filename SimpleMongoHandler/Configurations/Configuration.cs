using System;
using Newtonsoft.Json;
using System.IO;

namespace SimpleMongoHandler.Configurations
{
    public class Configuration
    {
        //Properties from config file
        public string Server { get; set; }
        public string DataBase { get; set; }
        public string Collection { get; set; }
        public string Credentials { get; set; }
    }

    public class GetConfiguration
    {
        public string GetConfig(ConfigType configType)
        {
            try
            {
                using (StreamReader r = new StreamReader("/config.json"))
                {
                    string json = r.ReadToEnd();
                    Configuration items = JsonConvert.DeserializeObject<Configuration>(json);

                    switch (configType)
                    {
                        case ConfigType.Collection:
                            return items.Collection;
                        case ConfigType.Server:
                            return items.Server;
                        case ConfigType.DataBase:
                            return items.DataBase;
                        case ConfigType.Credentials:
                            return items.Credentials;
                        default:
                            return "";
                    }
                }
            }
            catch(Exception ex)
            {
                //Handle exception
                throw new Exception("Error parsing configuration file");
            }
        }
        public enum ConfigType { Server, Collection, DataBase, Credentials };
    }
    
}
