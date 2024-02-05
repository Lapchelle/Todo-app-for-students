using WebApplication1.Dto;
using WebApplication1.Interfaces;
using WebApplication1.Models;
using Microsoft.AspNetCore.Mvc;

using AutoMapper;
using System.Diagnostics.Metrics;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : Controller
    {
        private readonly IContactRepository _contactRepository;
        private readonly IMapper _mapper;



        public ContactController(IContactRepository contactRepository, IMapper mapper
           )
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Contact>))]
        public IActionResult GetContacts()
        {
            var contacts = _contactRepository.GetContacts();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(contacts);
        }


        [HttpGet("{contId}")]
        [ProducesResponseType(200, Type = typeof(Contact))]
        [ProducesResponseType(400)]
        public IActionResult GetContact(int contId)
        {
            if (!_contactRepository.ContactExists(contId))
                return NotFound();

            var pokemon = _mapper.Map<ContactDto>(_contactRepository.GetContact(contId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(pokemon);
        }

       

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateContact([FromQuery] int userId, [FromBody] ContactDto contactCreate)
        {
            if (contactCreate == null)
                return BadRequest(ModelState);

            var contacts = _contactRepository.GetContactTrimToUpper(contactCreate);

            if (contacts != null)
            {
                ModelState.AddModelError("", "Owner already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var ContactMap = _mapper.Map<Contact>(contactCreate);


            if (!_contactRepository.CreateContact(userId, ContactMap))
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpPut("{contId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateContact(int contId,
            [FromQuery] int userId, 
            [FromBody] ContactDto updatedContact)
        {
            if (updatedContact == null)
                return BadRequest(ModelState);

            if (contId != updatedContact.Id)
                return BadRequest(ModelState);

            if (!_contactRepository.ContactExists(contId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var contactMap = _mapper.Map<Contact>(updatedContact);

            if (!_contactRepository.UpdateContact(userId,  contactMap))
            {
                ModelState.AddModelError("", "Something went wrong updating owner");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{contId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeletePokemon(int contId)
        {
            if (!_contactRepository.ContactExists(contId))
            {
                return NotFound();
            }

           
            var contactToDelete = _contactRepository.GetContact(contId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

           

            if (!_contactRepository.DeleteContact(contactToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting owner");
            }

            return NoContent();


        }
    }
}
