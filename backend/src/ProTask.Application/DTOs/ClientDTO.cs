using System.Runtime.Serialization;
using Newtonsoft.Json;
using ProTask.Domain.Enums;

namespace ProTask.Application.DTOs
{
    [DataContract]
    public class NewClientDTO
    {
        [JsonProperty(Required = Required.Always)]
        public string? Name { get; set; }
        [JsonProperty(Required = Required.Always)]
        public StatusEnum Situation { get; set; }
    }

    [DataContract]
    public class ClientDTO : NewClientDTO
    {
        [JsonProperty(Required = Required.Always)]
        public int Id { get; set; }

        [JsonProperty(Required = Required.Always)]
        public DateTime CreationDate { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? ModificationDate { get; set; }
    }
}