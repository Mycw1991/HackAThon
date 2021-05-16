using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HackAThon.DBContexts;
using HackAThon.Interfaces;
using HackAThon.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HackAThon
{
    [Route("api/person")]
    [ApiController]
    public class PersonController : Controller
    {
        private readonly IPersonRepository _people;

        public PersonController(IPersonRepository personRepository)
        {
            _people = personRepository;
        }

        [HttpGet]
        public async Task<List<Person>> Get()
        {
            return await _people.GetAllPeopleAsync();
        }

        [HttpGet("{id}")]
        public async Task<Person> Get(int id)
        {
            return await _people.GetPersonByIdAsync(id);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Person value)
        {
            var Person = new Person { Name = value.Name};
            return Ok(await _people.AddPersonAsync(Person));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Person value)
        {
            var Person = await _people.GetPersonByIdAsync(id);
            return Ok(await _people.UpdatePersonAsync(Person, value.Name));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var Person = await _people.GetPersonByIdAsync(id);
            await _people.DeletePersonAsync(Person);
            return Ok();
        }
    }
}
