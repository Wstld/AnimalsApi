using System;
using System.Collections.Generic;
using AnimalsApi.Controllers;
using AnimalsApi.Entities.Context;
using AnimalsApi.Entities.Data;
using AnimalsApi.Entities.DTO;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace AnimalsApi.Repo
{
    public class AnimalRepo : IAnimalRepo
    {
        private DebugContext _context;
        public AnimalRepo(DebugContext context){
            _context = context;
            }

        public bool AddAnimal(Animal animal)
        {
            var addingAnimal = _context.Animals.AddAsync(animal);
            _context.SaveChanges();
            
            return addingAnimal.IsCompletedSuccessfully;
        }


        //create new animal from recieved data.
        public Animal CreateAnimalFromDTO(CreateAnimalDTO recivedAnimalData)
        {
            AnimalEnum animalTypeID = Enum.Parse<AnimalEnum>(recivedAnimalData.TypeOfAnimal.ToUpper());

            return new Animal { Id = Guid.NewGuid(), Name = recivedAnimalData.Name, TypeId = ((int)animalTypeID) };
        }



        public void DeleteAnimal(Guid Id)
        {
            var removeAnimal = GetAnimalById(Id);
            if(removeAnimal != null)
            {
                _context.Remove(removeAnimal);
                _context.SaveChanges();
            }

        }

        public List<Animal> GetAll()
        {

            var response = _context.Animals.Include(a => a.Type).ToList();
            return response;
        }
        
        public Animal GetAnimalById(Guid Id)
        {
            var response = _context.Animals.Include(a => a.Type).FirstOrDefaultAsync(e => e.Id == Id);
            return response.Result;
        }

  

        public Animal UpdateAnimalData(CreateAnimalDTO newAnimalValues, Guid id)
        {
            Animal animal = GetAnimalById(id);
            if(animal != null)
            {

                animal.Name = newAnimalValues.Name ?? animal.Name;
                animal.TypeId = newAnimalValues.TypeOfAnimal != null ?
                    (int)Enum.Parse<AnimalEnum>(newAnimalValues.TypeOfAnimal.ToUpper())
                    :
                    animal.TypeId;

                _context.SaveChanges();
                return animal;
            }
            else
            {
                return animal;
            }
          
        }

    
    }
}
