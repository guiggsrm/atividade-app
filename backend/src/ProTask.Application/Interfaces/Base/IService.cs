namespace ProTask.Application.Interfaces.Base
{
    public interface IService<TDTO, TNEWDTO, Key>
    {
        Task<TDTO> Create(TNEWDTO modelDTO);
        Task<bool> Remove(Key id);
        Task<IEnumerable<TDTO>> Get();
        Task<TDTO?> Get(Key id);
    }
}