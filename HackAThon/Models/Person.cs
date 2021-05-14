using System;
using System.ComponentModel.DataAnnotations;

namespace HackAThon.Models
{
    public class Person
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
