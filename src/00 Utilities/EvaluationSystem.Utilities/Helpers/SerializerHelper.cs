using Newtonsoft.Json;

namespace EvaluationSystem.Utilities.Helpers
{
    public class SerializerHelper
    {
        public static T DeSerialize<T>(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(json);
            }
            catch
            {
                return default;
            }
        }

        public static string SerializeObject(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }
}
