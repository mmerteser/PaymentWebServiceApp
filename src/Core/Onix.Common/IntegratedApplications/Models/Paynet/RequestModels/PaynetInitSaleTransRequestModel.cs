using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onix.Common.IntegratedApplications.Models.Paynet.RequestModels
{
    public class PaynetInitSaleTransRequestModel
    {
        [JsonProperty("amount")]
        public double Amount { get; set; }

        [JsonProperty("add_commission")]
        public bool AddCommission { get; set; }

        [JsonProperty("instalment")]
        public int Instalment { get; set; }

        [JsonProperty("card_holder_phone")]
        public string CardHolderPhone { get; set; }

        [JsonProperty("card_holder_mail")]
        public string CardHolderMail { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("reference_no")]
        public string ReferenceNo { get; set; }

        [JsonProperty("selected_agent_id")]
        public string SelectedAgentId { get; set; }

        [JsonProperty("callback_url")]
        public string CallbackUrl { get; set; }
    }
}
