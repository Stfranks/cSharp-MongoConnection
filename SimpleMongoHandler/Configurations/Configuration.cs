using System;
using Newtonsoft.Json;
using System.IO;
using NLog;

namespace SimpleMongoHandler.Configurations
{

    public class GetConfiguration
    {
        private static Logger log = LogManager.GetCurrentClassLogger();
        public string Server { get; set; }
        public string DataBase { get; set; }
        public string Collection { get; set; }
        public string Credentials { get; set; }
        public enum ConfigType { Server, Collection, DataBase, Credentials };

        /// <summary>
        /// Read json file then assigns a value depending on the needed property, this only apply for mongo credentials
        /// </summary>
        /// <param name="configType"></param>
        /// <returns>
        /// enum for credentials
        /// Otherwise it throws the <see cref="Exception" /> object
        /// </returns>
        public string GetConfig(ConfigType configType)
        {
            try
            {
                using (StreamReader r = new StreamReader("/config.json"))
                {
                    string json = r.ReadToEnd();
                    GetConfiguration items = JsonConvert.DeserializeObject<GetConfiguration>(json);

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
                            throw new NullReferenceException();
                    }
                }
            }
            catch(Exception ex)
            {
                //Handle exception
                throw new Exception("Error parsing configuration file");
            }
        }
    }
    
}
