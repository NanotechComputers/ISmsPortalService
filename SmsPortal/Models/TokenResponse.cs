using Newtonsoft.Json;

namespace SmsPortal.Models
{
    internal class TokenResponse
    {
        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("schema")]
        public string Schema { get; set; }

        [JsonProperty("expiresInMinutes")]
        public int ExpiresInMinutes { get; set; }
    }
}