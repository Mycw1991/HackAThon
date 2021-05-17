using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HackAThon;
using HackAThon.DBContexts;
using HackAThon.Interfaces;
using HackAThon.Models;
using HackAThon.Repositories;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace UnitTests
{
    public class PersonRepositoryTest
    {
        private PersonContext CreateDbContext()
        {
            var options = new DbContextOptionsBuilder<PersonContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString("N")).Options;
            var dbContext = new PersonContext(options);
            return dbContext;
        }

        [Fact]
        public async void TestAddPerson()
        {
            var dbContext = CreateDbContext();
            var repo = new PersonRepository(dbContext);
            int id = 1;
            string name = "Jules";
            var person = new Person { Id= id,Name = name};
            var result = await repo.AddPersonAsync(person);

            Assert.Equal(result.Id, id);
            Assert.Equal(result.Name, name);

            dbContext.Dispose();
        }

        [Fact]
        public async void TestUpdatePerson()
        {
            var dbContext = CreateDbContext();
            var repo = new PersonRepository(dbContext);
            int id = 1;
            string name = "Jules";
            string newName = "Jules2";
            var person = new Person { Id = id, Name = name };
            var result = await repo.AddPersonAsync(person);
            var updatedResult = await repo.UpdatePersonAsync(result, newName);
            Assert.Equal(updatedResult.Id, id);
            Assert.Equal(updatedResult.Name, newName);

            dbContext.Dispose();
        }

        [Fact]
        public async void TestDeletePerson()
        {
            var dbContext = CreateDbContext();
            var sut = new PersonRepository(dbContext);
            int id = 1;
            string name = "Jules";
            var person = new Person { Id = id, Name = name };
            var result = await sut.AddPersonAsync(person);
            Assert.True(await dbContext.Person.AnyAsync(Person => Person.Id == id));
            await sut.DeletePersonAsync(person);
            var deletedResult = await dbContext.Person.AnyAsync(Person => Person.Id == id);
            Assert.False(deletedResult);
            dbContext.Dispose();
        }
    }

   
}
