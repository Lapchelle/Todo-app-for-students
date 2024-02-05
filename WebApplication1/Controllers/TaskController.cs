using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Dto;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : Controller
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IStatusRepository _statusRepository;
        private readonly IMapper _mapper;

        public TaskController(ITaskRepository taskRepository,
            
            IMapper mapper)
        {
            _taskRepository = taskRepository;
           
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Models.Task>))]
        public IActionResult GetPokemons()
        {
            var tasks = _mapper.Map<List<TaskDto>>(_taskRepository.GetTasks());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(tasks);
        }

        [HttpGet("{taskId}")]
        [ProducesResponseType(200, Type = typeof(Models.Task))]
        [ProducesResponseType(400)]
        public IActionResult GetTask(int taskId)
        {
            if (!_taskRepository.TaskExists(taskId))
                return NotFound();

            var task = _mapper.Map<TaskDto>(_taskRepository.GetTask(taskId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(task);
        }



        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateTask([FromQuery] int userId, [FromQuery] int statusId, [FromBody] TaskDto taskCreate)
        {
            if (taskCreate == null)
                return BadRequest(ModelState);

            var task = _taskRepository.GetTasks()
                .Where(c => c.Description.Trim().ToUpper() == taskCreate.Description.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (task != null)
            {
                ModelState.AddModelError("", "Status already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var taskMap = _mapper.Map<Models.Task>(taskCreate);

           

            if (!_taskRepository.CreateTask(userId, statusId,taskMap))
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpPut("{taskId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateTask(int taskId,
            [FromQuery] int userId, [FromQuery] int statusId,
            [FromBody] TaskDto updatedTask)
        {
            if (updatedTask == null)
                return BadRequest(ModelState);

            if (taskId != updatedTask.Id)
                return BadRequest(ModelState);

            if (!_taskRepository.TaskExists(taskId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var taskMap = _mapper.Map<Models.Task>(updatedTask);

            if (!_taskRepository.UpdateTask(userId, statusId, taskMap))
            {
                ModelState.AddModelError("", "Something went wrong updating user");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{taskId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteTask(int taskId)
        {
            if (!_taskRepository.TaskExists(taskId))
            {
                return NotFound();
            }

           
            var taskToDelete = _taskRepository.GetTask(taskId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

           

           

            return NoContent();
        }
    }
}
