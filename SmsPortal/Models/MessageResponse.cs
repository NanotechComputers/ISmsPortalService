using System.Collections.Generic;
using Newtonsoft.Json;

namespace SmsPortal.Models
{
    public class MessageResponse
    {
        [JsonProperty("Cost")]
        public decimal Cost { get; set; }

        [JsonProperty("RemainingBalance")]
        public decimal RemainingBalance { get; set; }

        [JsonProperty("EventId")]
        public long EventId { get; set; }

        [JsonProperty("Sample")]
        public string Sample { get; set; }

        [JsonProperty("Messages")]
        public int Messages { get; set; }

        [JsonProperty("Parts")]
        public int Parts { get; set; }

        [JsonProperty("CostBreakDown")]
        public IList<CostBreakDown> CostBreakDown { get; set; }

        [JsonProperty("ErrorReport")]
        public ErrorReport ErrorReport { get; set; }
    }

    public class Message
    {
        [JsonProperty("Content")]
        public string Content { get; set; }

        [JsonProperty("Destination")]
        public string Destination { get; set; }
    }

    public class MessageRequest
    {
        [JsonProperty("Messages")]
        public IList<Message> Messages { get; set; }
    }
}