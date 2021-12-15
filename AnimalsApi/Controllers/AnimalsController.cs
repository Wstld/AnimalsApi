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

        //POST: api/animals body: {name: string, type: string} 
        [HttpPost("")]
        public IActionResult AddAnimal([FromBody] CreateAnimalDTO newAnimal)
        {
            if (newAnimal.Name != null)
            {
                Animal createdAnimal = _repo.CreateAnimalFromDTO(newAnimal);

                bool addAnimalToDb = _repo.AddAnimal(createdAnimal);


                if (addAnimalToDb == true)
                {
                    AnimalDTO addedAnimalDTO = _repo.GetAnimalById(createdAnimal.Id).mapToAnimalDTO();

                    return CreatedAtAction(
                        nameof(GetAnimalById),
                        new { id = createdAnimal.Id }, addedAnimalDTO
                        );
                }
                else
                {
                    return BadRequest("Can't add without a name");
                }
            }
            else
            {
                return BadRequest("Could Not Add Animal, check connection.");
            }           

        }


        //DELETE ANIMAL: api/animals/{id}
        [HttpDelete("{id}")]
          public IActionResult DeleteAnimal(Guid id)
        {
            _repo.DeleteAnimal(id);
            return NoContent();
        }


        //UPDATE PUT: api/animals/{id} body: {"name":"string",type:"string"}
        [HttpPut ("{id}")]
        public IActionResult UpdateAnimal([FromBody] AnimalDTO newAnimalValues, Guid id)
        {
            _repo.UpdateAnimalData(newAnimalValues,id);
            AnimalDTO animalDTO = _repo.GetAnimalById(id).mapToAnimalDTO();
            return Ok(animalDTO);
        }


    }
}
