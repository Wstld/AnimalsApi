
using System;
using System.ComponentModel.DataAnnotations;
using AnimalsApi.Entities.DTO;

namespace AnimalsApi.Entities.Data
{
    public class AnimalType
    {
        [Key]
        public int AnimalTypeId { get; set; }

        [Required]
        public string Type { get; set; }

    }

    public enum AnimalEnum
    {
        UNKNOWN = 0, CAT = 1, DOG = 2, FISH = 3, SPIDER = 4,  
    }
    
}
