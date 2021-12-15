﻿using System;
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



        public Animal AddAnimal(Animal animal)
        {
            throw new NotImplementedException();
        }

        public Animal CreateAnimalFromDTO(CreateAnimalDTO recivedAnimalData)
        {
            throw new NotImplementedException();
        }

        public void DeleteAnimal(Guid Id)
        {
            throw new NotImplementedException();
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
