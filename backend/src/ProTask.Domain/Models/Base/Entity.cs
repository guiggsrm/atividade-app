namespace ProTask.Domain.Models.Base
{
    public abstract class Entity
    {
        public DateTime CreationDate { get; }

        public Entity() => CreationDate = DateTime.Now;
    }
}