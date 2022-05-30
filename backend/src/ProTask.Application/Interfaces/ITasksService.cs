using ProTask.Application.DTOs;
using ProTask.Application.Interfaces.Base;

namespace ProTask.Application.Interfaces
{
    public interface ITasksService : IIntService<TaskDTO, NewTaskDTO>
    {
        
    }
}