using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using HackAThon.Models;
using Microsoft.AspNetCore.Mvc;

namespace HackAThon.Interfaces
{
    public interface IPersonRepository
    {
        Task<List<Person>> GetAllPeopleAsync();
        Task<Person> GetPersonByIdAsync(int id);
        Task<Person> AddPersonAsync(Person person);
        Task<Person> UpdatePersonAsync(Person person, string name);
        Task DeletePersonAsync(Person person);
    }
}