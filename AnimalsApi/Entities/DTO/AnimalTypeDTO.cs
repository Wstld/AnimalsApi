using System;
namespace AnimalsApi.Entities.DTO
{
    public class AnimalTypeDTO
    {
        public int Id { get; set; }
        public string Name  { get; set; }

    }

    public static class AnimalTypeDTOExtentions
    {
        public static AnimalTypeDTO ToAnimalTypeDTO(this AnimalTypeDTO animal)
        {
            return new AnimalTypeDTO
            {
                Name = animal.Name
            };
        }
    }
}
