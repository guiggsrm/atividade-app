using Newtonsoft.Json;

namespace ProTask.Application.DTOs
{
    public class TokenResponseDTO
    {
        public TokenResponseDTO(string token, DateTime expiration)
        {
            Token = token;
            Expiration = expiration;
        }
        [JsonProperty(Required = Required.Always)]
        public string Token { get; set; }

        [JsonProperty(Required = Required.Always)]
        public DateTime Expiration { get; set; }
        
        [JsonProperty(Required = Required.Always)]
        public dynamic User { get; set; }
    }
}