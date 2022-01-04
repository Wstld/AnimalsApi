using System;
using System.ComponentModel.DataAnnotations;
using AnimalsApi.Entities.DTO;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnimalsApi.Entities.Data
{
    public class Animal
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }

        [ForeignKey("AnimalType")]
        public int TypeId { get; set; }

        public AnimalType Type { get; set; }
    }

    public static class AnimalExtensions
    {
        public static AnimalDTO mapToAnimalDTO(this Animal animal)
        {
            return new AnimalDTO { Id = animal.Id, Name = animal.Name, AnimalType = animal.Type };
        }
    }
}
