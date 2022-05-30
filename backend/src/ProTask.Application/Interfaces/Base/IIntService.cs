namespace ProTask.Application.Interfaces.Base
{
    public interface IIntService<TDTO, TNEWDTO> : IService<TDTO, TNEWDTO, int>
    {        
        Task<TDTO?> Update(TDTO modelDTO);
    }
}