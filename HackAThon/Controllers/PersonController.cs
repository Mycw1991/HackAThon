using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HackAThon.DBContexts;
using HackAThon.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HackAThon
{
    [Route("api/person")]
    [ApiController]
    public class PersonController : Controller
    {
        private readonly PersonContext _context;

        public PersonController(PersonContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<List<Person>> Get()
        {
            return await _context.Person.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<Person> Get(int id)
        {
            return await _context.Person.SingleAsync(Person => Person.Id == id);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Person value)
        {
            var Person = new Person { Name = value.Name};
            _context.Person.Add(Person);
            await _context.SaveChangesAsync();
            return Ok(Person);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Person value)
        {
            var Person = _context.Person.Single(Person => Person.Id == id);
            Person.Name = value.Name;
            await _context.SaveChangesAsync();
            return Ok(Person);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var Person = _context.Person.Single(Person => Person.Id == id);
            _context.Person.Remove(Person);
            await _context.SaveChangesAsync();
            return Ok(Person);
        }
    }
}
