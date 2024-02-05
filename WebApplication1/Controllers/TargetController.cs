using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Dto;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TargetController : Controller
    {
        private readonly ITargetRepository _targetRepository;
        private readonly IStatusRepository _statusRepository;
        private readonly IMapper _mapper;

        public TargetController(ITargetRepository targetRepository,

            IMapper mapper)
        {
            _targetRepository = targetRepository;

            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Target>))]
        public IActionResult GetTargets()
        {
            var targets = _mapper.Map<List<TargetDto>>(_targetRepository.GetTargets());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(targets);
        }

        [HttpGet("{targetId}")]
        [ProducesResponseType(200, Type = typeof(Target))]
        [ProducesResponseType(400)]
        public IActionResult Gettarget(int targetId)
        {
            if (!_targetRepository.TargetExists(targetId))
                return NotFound();

            var target = _mapper.Map<TargetDto>(_targetRepository.GetTarget(targetId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(target);
        }



        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult Createtarget([FromQuery] int userId, [FromQuery] int statusId, [FromBody] TargetDto targetCreate)
        {
            if (targetCreate == null)
                return BadRequest(ModelState);

            var targets = _targetRepository.GetTargetTrimToUpper(targetCreate);

            if (targets != null)
            {
                ModelState.AddModelError("", "User already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var targetMap = _mapper.Map<Target>(targetCreate);


            if (!_targetRepository.CreateTarget(userId, statusId, targetMap))
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpPut("{targetId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult Updatetarget(int targetId,
            [FromQuery] int userId, [FromQuery] int statusId,
            [FromBody] TargetDto updatedtarget)
        {
            if (updatedtarget == null)
                return BadRequest(ModelState);

            if (targetId != updatedtarget.Id)
                return BadRequest(ModelState);

            if (!_targetRepository.TargetExists(targetId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var targetMap = _mapper.Map<Target>(updatedtarget);

            if (!_targetRepository.UpdateTarget(userId, statusId, targetMap))
            {
                ModelState.AddModelError("", "Something went wrong updating user");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{targetId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteTarget(int targetId)
        {
            if (!_targetRepository.TargetExists(targetId))
            {
                return NotFound();
            }


            var targetToDelete = _targetRepository.GetTarget(targetId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);





            return NoContent();
        }
    }
}
