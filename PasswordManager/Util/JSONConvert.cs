using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
namespace PasswordManager.Util
{
    internal class JSONConvert
    {
        public static string SerializeObject<T>(T obj)
        {
            return JsonSerializer.Serialize<T>(obj);
        }
        public static T DeserializeObject<T>(string json)
        {
            return JsonSerializer.Deserialize<T>(json);
        }





    }
}
