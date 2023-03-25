using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Web;

namespace Onix.Application.Utilities.Helpers
{
    public static class JsonHelper
    {
        public static string ToQuery(this string json)
        {
            var jObj = (JObject)JsonConvert.DeserializeObject(json);
            var query = String.Join("&",
                jObj.Children().Cast<JProperty>()
                .Select(jp => jp.Name + "=" + HttpUtility.UrlEncode(jp.Value.ToString())));

            return query;
        }
    }
}
