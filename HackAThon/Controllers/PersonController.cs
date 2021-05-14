using System.Collections.Generic;
using System.Linq;
using HackAThon.DBContexts;
using HackAThon.Models;
using Microsoft.AspNetCore.Mvc;

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
        public List<Person> Get()
        {
            return _context.Person.ToList();
        }

        [HttpGet("{id}")]
        public Person Get(int id)
        {
            return _context.Person.Single(Person => Person.Id == id);
        }

        [HttpPost]
        public void Post([FromBody] Person value)
        {
            var Person = new Person { Name = value.Name};
            _context.Person.Add(Person);
            _context.SaveChanges();
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Person value)
        {
            var Person = _context.Person.Single(Person => Person.Id == id);
            Person.Name = value.Name;
            _context.SaveChanges();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var Person = _context.Person.Single(Person => Person.Id == id);
            _context.Person.Remove(Person);
            _context.SaveChanges();
        }
    }
}
