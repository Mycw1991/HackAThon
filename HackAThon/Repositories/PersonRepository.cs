using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HackAThon.DBContexts;
using HackAThon.Interfaces;
using HackAThon.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HackAThon.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly PersonContext _context;

        public PersonRepository(PersonContext context)
        {
            _context = context;
        }

        public async Task<Person> AddPersonAsync(Person person)
        {
            _context.Person.Add(person);
            await _context.SaveChangesAsync();
            return person;
        }

        public async Task DeletePersonAsync(Person person)
        {
            _context.Person.Remove(person);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Person>> GetAllPeopleAsync()
        {
            return await _context.Person.ToListAsync();
        }

        public async Task<Person> GetPersonByIdAsync(int id)
        {
            return await _context.Person.SingleAsync(Person => Person.Id == id);
        }

        public async Task<Person> UpdatePersonAsync(Person person, string name)
        {
            person.Name = name;
            await _context.SaveChangesAsync();
            return person;
        }
    }
}
