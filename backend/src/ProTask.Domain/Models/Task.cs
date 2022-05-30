using ProTask.Domain.Enums;
using ProTask.Domain.Models.Base;

namespace ProTask.Domain.Models
{
    public partial class Task : EntityInt
    {
        public string? Title { get; set; }

        public string? Description { get; set; }

        public PriorityEnum Priority { get; set; }

        public DateTime? ModificationDate { get; set; }
    }
}