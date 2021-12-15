using System;
namespace AnimalsApi.Entities.DTO
{
    public class AnimalDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
    }
}