﻿using System;
using SimpleMongoHandler.Helper;
using MongoDB.Bson;
using SimpleMongoHandler.DataAccess;
using NLog;
namespace SimpleMongoHandler.Services
{
    public class Service
    {
        public Connection Con = new Connection();
        private static Logger log = LogManager.GetCurrentClassLogger();
        public void Insert(string jsonObject)
        {
            bool isValidJson = JsonValidator.IsValidJson(jsonObject);
            if(isValidJson)
            {
                try
                {
                    BsonDocument document = MongoDB.Bson.Serialization.BsonSerializer.Deserialize<BsonDocument>(jsonObject);
                    var insert = Con.Get();
                    insert.InsertOne(document);
                }
                catch(BsonException ex)
                {
                    //Handle Exception
                }
                catch (Exception ex)
                {
                    //Handle Exception
                }

            }
            else
            {
                //Handle Exception
            }
        }
        
    }
}
