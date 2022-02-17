using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVC_Assignmet2.Models;

namespace MVC_Assignmet2.Controllers;

public class ListController : Controller
{
    private readonly ILogger<ListController> _logger;
    private List<Person> _people;

    public ListController(ILogger<ListController> logger)
    {
        _logger = logger;
        _people = new List<Person>{
              new Person{ID =1,FirstName = "Phuc",LastName="Nguyen",Gender=Gender.Male, DateOfBirth=new DateTime(2000,7,7)
              ,BirthAdress="Hai Duong",PhoneNumber="0966416324",IsGraduated=true},
                new Person{ID =2, FirstName = "Huyen",LastName="Nguyen",Gender=Gender.Female, DateOfBirth=new DateTime(2000,2,16)
              ,BirthAdress="Hung Yen",PhoneNumber="094632123",IsGraduated=false},
               new Person{ID =3,FirstName = "Thuy Phuong",LastName="Nguy",Gender=Gender.Female, DateOfBirth=new DateTime(1996,4,27)
              ,BirthAdress="Bac Ninh",PhoneNumber="083641232",IsGraduated=true},
               new Person{ID =4,FirstName = "Khoi",LastName="Nguyen",Gender=Gender.Male, DateOfBirth=new DateTime(2004,4,23)
              ,BirthAdress="Ha Noi",PhoneNumber="0876416708",IsGraduated=true},
                new Person{ID =5,FirstName = "Hoa",LastName="Dao",Gender=Gender.Female, DateOfBirth=new DateTime(2000,12,6)
              ,BirthAdress="Lang Son",PhoneNumber="0912321643",IsGraduated=true}};
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult GetPeopleByGender()
    {
     var list = (from person in _people where person.Gender == Gender.Male select person).ToList();
     if(list== null){
             return View(_people);
     }else{
              return View(list);
     }
    
    
    }

    public IActionResult GetOldestPerson()
    {
     var oldest = (from person in _people where person.DateOfBirth == _people.Max(person=>person.DateOfBirth) select person).FirstOrDefault();
     if(oldest == null) return RedirectToAction("Index");
      return View(oldest);
    }

  public IActionResult ListByAge(int? option) {
            List<Person> ListEqual2000 = (from person in _people where person.DateOfBirth.Year == 2000 select person).ToList();
            List<Person> ListUnder2000 = (from person in _people where person.DateOfBirth.Year < 2000 select person).ToList();
            List<Person> ListOver2000 = (from person in _people where person.DateOfBirth.Year > 2000 select person).ToList();
            switch (option)
            {
                case 0: return View(ListEqual2000); 
                case 1: return View(ListUnder2000);  
                case 2: return View(ListOver2000); 

                default: return  View(_people);
            }

            
  }

public IActionResult  GetFullNamePeople() {
  return View( (from person in _people select(person.FirstName+" "+person.LastName)).ToList());
}




    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
