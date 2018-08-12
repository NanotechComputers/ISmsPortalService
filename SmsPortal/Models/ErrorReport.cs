using System.Collections.Generic;
using Newtonsoft.Json;

namespace SmsPortal.Models
{
    public class ErrorReport
    {
        [JsonProperty("NoNetwork")]
        public int NoNetwork { get; set; }

        [JsonProperty("Duplicates")]
        public int Duplicates { get; set; }

        [JsonProperty("OptedOuts")]
        public int OptedOuts { get; set; }

        /*[JsonProperty("Faults")]
        public IList<object> Faults { get; set; }*/ //TODO: Figure out what Faults object contains
    }
}