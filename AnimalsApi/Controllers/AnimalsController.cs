using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnimalsApi.Entities.Data;
using AnimalsApi.Entities.DTO;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AnimalsApi.Controllers
{
    [ApiController]
    [Route("api/animals")]
    public class AnimalsController : ControllerBase
    {
        private readonly IAnimalRepo _repo;

        public AnimalsController(IAnimalRepo repo)
        {
            _repo = repo;
        }


        //GET ALL: api/animals
        [HttpGet]
        [Route("")]
        public IActionResult GetAllAnimals()
        {
            var respons = _repo.GetAll().ToList(); //Map to prefered output.
            return Ok(respons);
        }

        //GET BY ID: api/animals/{id}
        [HttpGet("{id}")]
        public IActionResult GetAnimalById(Guid Id)
        {
            Animal animal = _repo.GetAnimalById(Id);
            return animal != null ? Ok(animal) : NotFound("Id not found");
        }

        //POST ANIMAL
        [HttpPost("")]
        public IActionResult AddAnimal([FromBody] CreateAnimalDTO newAnimal)
        {
            Animal createdAnimal = _repo.CreateAnimalFromDTO(newAnimal);

            _repo.AddAnimal(createdAnimal);

            AnimalDTO addedAnimalDTO = _repo.GetAnimalById(createdAnimal.Id).mapToAnimalDTO();

            return CreatedAtAction(
                nameof(GetAnimalById),
                new { id = createdAnimal.Id }, addedAnimalDTO
                );

        }

        //DELETE ANIMAL
        [HttpDelete("{id}")]
          public IActionResult DeleteAnimal(Guid id)
        {
            _repo.DeleteAnimal(id);

            return NoContent();
        }


        //UPDATE ANIMAL
        [HttpPut ("{id}")]
        public IActionResult UpdateAnimal([FromBody] Animal animal, Guid id)
        {
            _repo.UpdateAnimalData(animal);
            AnimalDTO animalDTO = _repo.GetAnimalById(animal.Id).mapToAnimalDTO();
            return Ok(animalDTO);
        }


    }
}
