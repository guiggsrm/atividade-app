using ProTask.Domain.Enums;
using ProTask.Domain.Exceptions;

namespace ProTask.Domain.Models
{
    public partial class Client
    {
        public Client(string name, StatusEnum situation)
        {
            ValidateName(name);
            Name = name;
            Situation = situation;
        }

        public void Update(string name, StatusEnum situation)
        {
            ValidateName(name);
            Name = name;
            Situation = situation;
            ModificationDate = DateTime.Now;
        }


        protected void ValidateName(string name)
        {
            DomainValidationException.When(string.IsNullOrEmpty(name), "Name is required");
            DomainValidationException.When(name.Trim().Length < 3, "Name must have at least 3 characteres");
            DomainValidationException.When(name.Trim().Length > 100, "Name must have a maximum of 100 characteres");
        }
    }
}