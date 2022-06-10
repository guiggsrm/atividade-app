using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace ProTask.Application.DTOs
{
    [DataContract]
    public class NewUserDTO : TokenRequestDTO
    {
        [Required(ErrorMessage = "{0} is required")]
        [StringLength(100, ErrorMessage = "The {0}} must be at least {2} and at maximun {1} characteres", MinimumLength = 3)]
        [JsonProperty("name", Required = Required.Always)]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [StringLength(5, ErrorMessage = "The {0}} must be at least {2} and at maximun {1} characteres", MinimumLength = 2)]
        [JsonProperty("name", Required = Required.Always)]
        public string Lang { get; set; }
    }
}