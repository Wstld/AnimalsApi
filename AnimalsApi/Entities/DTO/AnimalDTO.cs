using System;
using AnimalsApi.Entities.Data;

namespace AnimalsApi.Entities.DTO
{
    public class AnimalDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public AnimalType AnimalType { get; set; }
    }
}