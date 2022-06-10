using Microsoft.AspNetCore.Mvc;
using ProTask.Application.DTOs;
using ProTask.Application.Interfaces;

namespace ProTask.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly ILogger<TasksController> _logger;
        private readonly ITasksService _taskService;

        public TasksController(ILogger<TasksController> logger, ITasksService taskService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _taskService = taskService ?? throw new ArgumentNullException(nameof(taskService));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var tasks = await _taskService.Get();
                if (tasks == null) return NoContent();
                return Ok(tasks);
            } catch (Exception e)
            {
                _logger.LogError(e.Message);
                return this.StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var task = await _taskService.Get(id);
                if (task == null) return NoContent();
                return Ok(task);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, id);
                return this.StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(NewTaskDTO dto)
        {
            try
            {
                var newDTO = await _taskService.Create(dto);
                return Ok(newDTO);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, dto);
                return this.StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, TaskDTO dto)
        {
            try
            {
                if (dto == null) return Conflict("Please send a task to modify");
                if (id != dto.Id) return Conflict("Task you trying to update is diferent");
                var updatedTask = await _taskService.Update(dto);
                if(updatedTask == null) return Conflict("Task you trying to update does't exists");
                return Ok(updatedTask);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, dto);
                return this.StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var deletedTask = await _taskService.Get(id);
                if (deletedTask == null) return Conflict("Task you trying to delete does't exists");
                if (await _taskService.Remove(id))
                    return Ok(new { message = "Deleted" });
                return BadRequest(new { message = "It wasn't possible to delete your request" });
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, id);
                return this.StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}