using System;
using System.Collections.Generic;
using AnimalsApi.Controllers;
using AnimalsApi.Entities.Context;
using AnimalsApi.Entities.Data;
using AnimalsApi.Entities.DTO;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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
            return new Animal { Id = Guid.NewGuid(), Name = recivedAnimalData.Name, Type = recivedAnimalData.Type ?? "Unknown" };
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
            var response = _context.Animals.ToListAsync();
            return response.Result;
        }
        
        public Animal GetAnimalById(Guid Id)
        {
            var response = _context.Animals.FirstOrDefaultAsync(e => e.Id == Id);
            return response.Result;
        }

        public Animal UpdateAnimalData(Animal animal)
        {
            throw new NotImplementedException();
        }
    }
}
