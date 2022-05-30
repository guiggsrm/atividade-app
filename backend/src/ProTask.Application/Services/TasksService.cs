using AutoMapper;
using ProTask.Application.DTOs;
using ProTask.Application.Interfaces;
using ProTask.Application.Services.Base;
using ProTask.Domain.Interfaces;

namespace ProTask.Application.Services
{
    public class TasksService : Service<TaskDTO, NewTaskDTO, Domain.Models.Task, int>, ITasksService
    {
        public TasksService(IMapper mapper, ITaskRepository repository) : base(mapper, repository)
        {
        }

        public async Task<TaskDTO?> Update(TaskDTO modelDTO)
        {
            if(modelDTO != null)
            {
                var task = await _repository.GetAsync(modelDTO.Id);
                if(task != null)
                {
                    task.Update(modelDTO.Title ?? string.Empty, modelDTO.Description ?? string.Empty, modelDTO.Priority);
                    return _mapper.Map<TaskDTO>(await _repository.UpdateAsync(task));
                }
            }
            return null;
        }
    }
}