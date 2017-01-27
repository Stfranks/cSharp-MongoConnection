using MongoDB.Driver;
using MongoDB.Bson;
using SimpleMongoHandler.Configurations;
using System;
using NLog;

namespace SimpleMongoHandler.DataAccess
{
    public class Connection
    {
        protected static IMongoClient _client;
        protected static IMongoDatabase _database;
        private static Logger log = LogManager.GetCurrentClassLogger();
        private static IMongoDatabase Connect()
        {
            log.Trace("IMongoDatabase Connect() method");
            try
            {
                GetConfiguration getConf = new GetConfiguration();
                #region Without Credentials
                //Specify Connection string 
                string connectionString = getConf.GetConfig(GetConfiguration.ConfigType.Server);
                MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl(connectionString));
                _client = new MongoClient(settings);
                return _client.GetDatabase(getConf.GetConfig(GetConfiguration.ConfigType.DataBase));
                #endregion
            }
            catch(MongoClientException me)
            {
                log.Error("MongoClientException [{0}]", me.Message);
                throw new MongoClientException(me.Message);
            }
            catch(Exception ex)
            {
                log.Error("Exception on IMongoDatabase Connect [{0}]", ex.Message);
                throw new Exception(ex.Message);
            }
        }
        public IMongoCollection<BsonDocument> Get()
        {
            log.Trace("IMongoDatabase Get() method");
            try
            {
                GetConfiguration getConf = new GetConfiguration();
                return Connect().GetCollection<BsonDocument>(getConf.GetConfig(GetConfiguration.ConfigType.Collection));
            }
            catch(MongoClientException ex)
            {
                log.Error("MongoClientException [{0}]", ex.Message);
                throw new MongoClientException(ex.Message);
            }
            catch(Exception ex)
            {
                log.Error("Exception on IMongoDatabase Connect [{0}]", ex.Message);
                throw new Exception(ex.Message);
            }   
        }
    }
}
