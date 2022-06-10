using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace ProTask.Application.DTOs
{
    [DataContract]
    public class TokenRequestDTO
    {
        [Required(ErrorMessage = "{0}} is required")]
        [EmailAddress(ErrorMessage = "Invalid format {0}}")]
        [JsonProperty("username", Required = Required.Always)]
        public string UserName { get; set; }
        
        [Required(ErrorMessage = "{0} is required")]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} and at maximun {1} characteres", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [JsonProperty("password", Required = Required.Always)]
        public string Password { get; set; }
    }
}