using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PeopleCoreAngularWebApplication.Models;
using PeopleCoreAngularWebApplication.Repositories;

namespace PeopleCoreAngularWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IPeopleRepository _peopleRepository;

        public PeopleController(IPeopleRepository peopleRepository)
        {
            _peopleRepository = peopleRepository;
        }

        [HttpGet]
        //[Route("{id}")]
        public async Task<ActionResult<IList<Person>>> Get()
        {
            return Ok(await _peopleRepository.GetPeopleAsync());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Person>> GetById(Guid id)
        {
            var person = await _peopleRepository.GetPersonById(id);

            if (person == null)
            {
                return NotFound();
            }

            return Ok(person);
        }

        [HttpPost]
        //[Route("{id}")]
        public async Task<ActionResult<int>> Add([FromBody]Person person)
        {
            if (ModelState.IsValid)
            {
                var result = await _peopleRepository.InsertPerson(person);

                if (result == 0)
                    return BadRequest();

                return NoContent(); 
            }

            return BadRequest();
        }

        [HttpPut]
        //[Route("{id}")]
        public async Task<ActionResult<int>> Update([FromBody]Person person)
        {
            if (ModelState.IsValid)
            {
                var result = await _peopleRepository.UpdatePerson(person);

                if (result == 0)
                    return BadRequest();

                return NoContent(); 
            }

            return BadRequest();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<int>> Delete(Guid id)
        {
            if (id == null || id == Guid.Empty)
            {
                return BadRequest();
            }
            
            var result = await _peopleRepository.DeletePerson(id);

            if (result == 0)
                return BadRequest();

            return NoContent();
        }
    }
}