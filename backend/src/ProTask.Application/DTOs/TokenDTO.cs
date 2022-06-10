using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace ProTask.Application.DTOs
{
    [DataContract]
    public class TokenDTO
    {
        [JsonProperty(Required = Required.Always)]
        public string Secret { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string Issuer { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string Audience { get; set; }

        [JsonProperty(Required = Required.Always)]
        public int Expiry { get; set; }

        [JsonProperty(Required = Required.Always)]
        public int RefreshExpiry { get; set; }
    }
}