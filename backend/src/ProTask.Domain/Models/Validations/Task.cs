using ProTask.Domain.Enums;
using ProTask.Domain.Exceptions;

namespace ProTask.Domain.Models
{
    public partial class Task
    {

        public Task(string title, string description, PriorityEnum priority)
        {
            ValidateTitle(title);
            Title = title;
            Description = description;
            Priority = priority;
        }

        public void Update(string title, string description, PriorityEnum priority)
        {
            ValidateTitle(title);
            Title = title;

            ValidateDescription(description);
            Description = description;

            Priority = priority;

            ModificationDate = DateTime.Now;
        }

        protected void ValidateTitle(string title)
        {
            DomainValidationException.When(string.IsNullOrEmpty(title), "Title is required");
            DomainValidationException.When(title.Trim().Length < 3, "Title must have at least 3 characteres");
            DomainValidationException.When(title.Trim().Length > 100, "Title must have a maximum of 100 characteres");
        }
        protected void ValidateDescription(string description)
        {
            DomainValidationException.When(string.IsNullOrEmpty(description), "Description is required");
            DomainValidationException.When(description.Trim().Length < 20, "Description must have at least 20 characteres");
            DomainValidationException.When(description.Trim().Length > 1000, "Description must have a maximum of 1000 characteres");
        }
    }
}