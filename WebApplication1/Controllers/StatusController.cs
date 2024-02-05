using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Dto;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : Controller
    {
        private readonly IStatusRepository _statusRepository;
        private readonly IMapper _mapper;

        public StatusController(IStatusRepository statusRepository, IMapper mapper)
        {
            _statusRepository = statusRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Status>))]
        public IActionResult GetStatuses()
        {
            var statuses = _mapper.Map<List<StatusDto>>(_statusRepository.GetStatuses());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(statuses);
        }

        [HttpGet("{statusId}")]
        [ProducesResponseType(200, Type = typeof(Status))]
        [ProducesResponseType(400)]
        public IActionResult GetStatus(int statusId)
        {
            if (!_statusRepository.StatusExists(statusId))
                return NotFound();

            var status = _mapper.Map<StatusDto>(_statusRepository.GetStatus(statusId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(status);
        }

        [HttpGet("task/{statusId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Models.Task>))]
        [ProducesResponseType(400)]
        public IActionResult GettaskByStatusId(int statusId)
        {
            var tasks = _mapper.Map<List<TaskDto>>(
                _statusRepository.GetTaskByStatus(statusId));

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(tasks);
        }

        [HttpGet("target/{statusId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Target>))]
        [ProducesResponseType(400)]
        public IActionResult GettargetByStatusId(int statusId)
        {
            var targets = _mapper.Map<List<TargetDto>>(
                _statusRepository.GetTaskByStatus(statusId));

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(targets);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateStatus([FromBody] StatusDto statusCreate)
        {
            if (statusCreate == null)
                return BadRequest(ModelState);

            var status = _statusRepository.GetStatuses()
                .Where(c => c.Name.Trim().ToUpper() == statusCreate.Name.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (status != null)
            {
                ModelState.AddModelError("", "Status already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var statusMap = _mapper.Map<Status>(statusCreate);

            if (!_statusRepository.CreateStatus(statusMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpPut("{statusId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateStatus(int statusId, [FromBody] StatusDto updatedStatus)
        {
            if (updatedStatus == null)
                return BadRequest(ModelState);

            if (statusId != updatedStatus.Id)
                return BadRequest(ModelState);

            if (!_statusRepository.StatusExists(statusId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var statusMap = _mapper.Map<Status>(updatedStatus);

            if (!_statusRepository.UpdateStatus(statusMap))
            {
                ModelState.AddModelError("", "Something went wrong updating status");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{statusId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteStatus(int statusId)
        {
            if (!_statusRepository.StatusExists(statusId))
            {
                return NotFound();
            }

            var statusToDelete = _statusRepository.GetStatus(statusId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_statusRepository.DeleteStatus(statusToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting category");
            }

            return NoContent();
        }
    }
}
