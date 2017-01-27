using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using NLog;

namespace SimpleMongoHandler.Helper
{
    public static class JsonValidator
    {
        private static Logger log = LogManager.GetCurrentClassLogger();
        /// <summary>
        /// Gets a string as imput, firts check if it is an object or array then parse the string for json validation
        /// </summary>
        /// <param name="strInput"></param>
        /// <returns>
        /// Return true/false if is a valid json 
        /// Otherwise it throws the <see cref="JsonReaderException" /> object
        /// Otherwise it throws the <see cref="Exception" /> object
        /// </returns>
        public static bool IsValidJson(string strInput)
        {
            log.Trace("IsValidJson method");
            strInput = strInput.Trim();
            if ((strInput.StartsWith("{") && strInput.EndsWith("}")) || //For object
                (strInput.StartsWith("[") && strInput.EndsWith("]"))) //For array
            {
                try
                {
                    var obj = JToken.Parse(strInput);
                    return true;
                }
                catch (JsonReaderException jex)
                {
                    log.Error("JsonReaderException[{0}]", jex.Message);
                    return false;
                }
                catch (Exception ex) //some other exception
                {
                    log.Error("JsonReaderException[{0}]", ex.Message);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
