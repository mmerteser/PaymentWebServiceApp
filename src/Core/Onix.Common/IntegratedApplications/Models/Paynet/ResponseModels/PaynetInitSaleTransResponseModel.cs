using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Onix.Common.IntegratedApplications.Models.Paynet.ResponseModels
{
    public class PaynetInitSaleTransResponseModel
    {
        [JsonPropertyName("payment_session_id")]
        public string payment_session_id { get; set; }

        [JsonPropertyName("deeplink_url")]
        public string deeplink_url { get; set; }

        [JsonPropertyName("encryption_key")]
        public string encryption_key { get; set; }

        [JsonPropertyName("object_name")]
        public string object_name { get; set; }

        [JsonPropertyName("code")]
        public int code { get; set; }

        [JsonPropertyName("message")]
        public string message { get; set; }
    }
}
