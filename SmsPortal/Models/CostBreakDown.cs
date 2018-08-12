using Newtonsoft.Json;

namespace SmsPortal.Models
{
    public class CostBreakDown
    {
        [JsonProperty("Network")]
        public string Network { get; set; }

        [JsonProperty("Cost")]
        public decimal Cost { get; set; }

        [JsonProperty("Quantity")]
        public int Quantity { get; set; }
    }
}