using System.Runtime.Serialization;
using Newtonsoft.Json;
using ProTask.Domain.Enums;

namespace ProTask.Application.DTOs
{
    [DataContract]
    public class NewTaskDTO
    {        
        [JsonProperty(Required = Required.Always)]
        public string? Title { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string? Description { get; set; }

        [JsonProperty(Required = Required.Always)]
        public PriorityEnum Priority { get; set; }
    }

    [DataContract]
    public class TaskDTO : NewTaskDTO
    {
        [JsonProperty(Required = Required.Always)]
        public int Id{ get; set; }

        [JsonProperty(Required = Required.Always)]
        public DateTime CreationDate { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? ModificationDate { get; set; }
    }
}