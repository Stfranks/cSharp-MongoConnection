using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace SimpleMongoHandler.Helper
{
    public static class JsonValidator
    {
        public static bool IsValidJson(string strInput)
        {
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
                    //Exception in parsing json
                    //Some kind of log
                    return false;
                }
                catch (Exception ex) //some other exception
                {
                    //Some kind of log
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
