using System;
using System.Collections.Generic;
using AnimalsApi.Entities.Data;
using AnimalsApi.Entities.DTO;

namespace AnimalsApi.Controllers
{
    public interface IAnimalRepo
    {
        List<Animal> GetAll();

        Animal GetAnimalById(Guid Id);

        bool AddAnimal(Animal animal);

        Animal UpdateAnimalData(Animal animal);

        void DeleteAnimal(Guid Id);

        Animal CreateAnimalFromDTO(CreateAnimalDTO recivedAnimalData);
    }
}