using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVC_Assignmet2.Models;

namespace MVC_Assignmet2.Controllers;


public class PersonController : Controller
{
 private List<Person> _people;
 public PersonController(){
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
           
            return View(_people);
        }

  public IActionResult Create()
        {
           
            return View();
        }


[HttpPost]

 public IActionResult Create(Person person)
        {
          
                    person.ID = _people.Max(person=>person.ID)+1 ;
                    _people.Add(person);
        
            return RedirectToAction("Index");
        }

 public IActionResult Edit(int id)
        {
            
            return View(_people.FirstOrDefault(person=>person.ID==id));
        }
[HttpPost]
public IActionResult Edit(int id,Person person)
        {
            if(ModelState.IsValid){
  var EditPerson = _people.FirstOrDefault(person=>person.ID==id);
  EditPerson.FirstName = person.FirstName;
  EditPerson.LastName = person.LastName;
  EditPerson.Gender = person.Gender;
  EditPerson.DateOfBirth =person.DateOfBirth;
  EditPerson.BirthAdress = person.BirthAdress;
  EditPerson.IsGraduated = person.IsGraduated;
  
  

            }
          
            return RedirectToAction("Index");
        }



public IActionResult Delete(int id)
        {
         
                  var person = _people.FirstOrDefault(_people => _people.ID==id);
                  if(person != null) _people.Remove(person);
                   
           
            return RedirectToAction("Index");
        }

}