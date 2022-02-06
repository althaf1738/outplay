using Microsoft.AspNetCore.Mvc;
using Firstapi.PersonModelInterface;
using Firstapi.PersonModels;

namespace firstapi.Controllers{

    [ApiController]
    
    [Route("Person")]
        
    public class PersonControllers : ControllerBase
    {

        private  IPerson _personData;

        public PersonControllers(IPerson personData){
            _personData= personData;
        }

        [HttpGet]       
        
        public IActionResult GetPersons()
        {
            return Ok(_personData.GetPersons());
        }

        [HttpGet("{id}")]
        public IActionResult GetPerson(int id)
        {
            var person = _personData.GetPerson(id);
            if(person != null)
            {
                 return Ok(person);
            }
            

          
             return NotFound();

        }

         [HttpGet("isAdult/{status}")]
        public IActionResult IsAdult(bool status)
        {
            List<Person>  person = _personData.IsAdult(status);
            if(person != null)
            {
                 return Ok(person);
            }
            

          
             return NotFound();

        }

         [HttpGet("age/{value}")]
        public IActionResult GreaterAge(int value)
        {
            List<Person>  person = _personData.GreaterAge(value);
            if(person != null)
            {
                 return Ok(person);
            }
            

          
             return NotFound();

        }

        [HttpPost]
        public IActionResult AddPerson(Person person)
        {
            _personData.AddPerson(person);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + person.Id, 
            person);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePerson(int id)
        {
            var person = _personData.GetPerson(id);

            if(person == null)
            {
                return NotFound();
            }
            _personData.DeletePerson(person);
            return Ok();

        }

         [HttpPatch("{id}")]
        public IActionResult UpdatePerson(int id, Person person)
        {
            var existingPerson = _personData.GetPerson(id);

            if(existingPerson != null)
            {
               person.Id= existingPerson.Id;
               _personData.EditPerson(person);
            }
            
            return Ok(person);

        }
        
    }
}