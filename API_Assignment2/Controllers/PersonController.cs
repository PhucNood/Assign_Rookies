using Microsoft.AspNetCore.Mvc;
using API_Assignment2.Services;
using API_Assignment2.Models;
namespace API_Assignment2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IPeopleService _personService;

        public PersonController(IPeopleService personService)
        {
            _personService = personService;
        }

        [HttpPost("/api/person")]
        public void Create(Person person)
        {
            _personService.Create(person);
        }

        [HttpPut("/api/person")]
        public void Update(Person person)
        {
            _personService.Update(person);
        }

        [HttpDelete("/api/person/{id}")]
        public void Delete(int id)
        {
            _personService.Delete(id);
        }

        [HttpGet("/api/filtered-gender-people/{gender}")]
        public IEnumerable<Person> GetGetPeopleByGender(Gender gender)
        {
            return _personService.FilterListByGender(gender);
        }

        [HttpGet("/api/filtered-name-people")]
        public IEnumerable<Person> GetPeopleByName(string name)
        {
            return _personService.FilterListByName(name);
        }


        [HttpGet("/api/filtered-place-people")]
        public IEnumerable<Person> GetGetPeopleByPlace(string placeName)
        {
            return _personService.FilterListByPlace(placeName);
        }


    }
}