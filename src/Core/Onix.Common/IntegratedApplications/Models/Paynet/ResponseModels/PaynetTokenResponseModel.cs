using Newtonsoft.Json;

namespace Onix.Common.IntegratedApplications.Models.Paynet.ResponseModels
{
    public class PaynetTokenResponseModel
    {
        [JsonProperty("agent_id")]
        public string AgentId { get; set; }

        [JsonProperty("code")]
        public int Code { get; set; }

        [JsonProperty("company_code")]
        public string CompanyCode { get; set; }

        [JsonProperty("expired_date")]
        public string ExpiredDate { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("object_name")]
        public string ObjectName { get; set; }

        [JsonProperty("session_key")]
        public string SessionKey { get; set; }

        [JsonProperty("user_id")]
        public string UserId { get; set; }

        [JsonProperty("user_unique_id")]
        public string UserUniqueId { get; set; }
    }
}
