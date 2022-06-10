using ProTask.Domain.Enums;
using ProTask.Domain.Models.Base;

namespace ProTask.Domain.Models
{
    public partial class Client : EntityInt
    {
        public string Name { get; set; }
        public StatusEnum Situation { get; set; }
        public DateTime? ModificationDate { get; set; }
    }
}