using System;
using System.ComponentModel.DataAnnotations;
using AnimalsApi.Entities.DTO;

namespace AnimalsApi.Entities.Data
{
    public class Animal
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }

        public string Type { get; set; }
    }

    public static class AnimalExtensions
    {
        public static AnimalDTO mapToAnimalDTO(this Animal animal)
        {
            return new AnimalDTO { Id = animal.Id, Name = animal.Name, Type = animal.Type };
        }
    }
}
