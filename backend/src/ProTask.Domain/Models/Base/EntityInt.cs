using ProTask.Domain.Exceptions;

namespace ProTask.Domain.Models.Base
{
    public abstract class EntityInt : Entity
    {
        public int Id { get; }

        public EntityInt() : base() { }

        public EntityInt(int id) : base() 
        {
            ValidateId(id);
            Id = id;
        }

        protected void ValidateId(int id)
        {
            DomainValidationException.When(id < 0, "The id is invalid");
        }
    }
}