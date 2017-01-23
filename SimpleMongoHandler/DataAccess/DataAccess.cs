using MongoDB.Driver;
using MongoDB.Bson;
using SimpleMongoHandler.Configurations;

namespace SimpleMongoHandler.DataAccess
{
    public class Connection
    {
        protected static IMongoClient _client;
        protected static IMongoDatabase _database;
        private static IMongoDatabase Connect()
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

        public IMongoCollection<BsonDocument> Get()
        {
            GetConfiguration getConf = new GetConfiguration();
            return Connect().GetCollection<BsonDocument>(getConf.GetConfig(GetConfiguration.ConfigType.Collection));
        }
    }
}
