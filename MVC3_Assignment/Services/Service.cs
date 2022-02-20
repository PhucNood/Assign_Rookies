
using Microsoft.AspNetCore.Mvc;
using MVC3_Assignment.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MVC3_Assignment.Services
{
    public class Serviece : IService
    {
        
        public static  List<Person> list = new List<Person> {
              new Person{ID=1,FirstName = "Phuc",LastName="Nguyen",Gender=Gender.Male, DateOfBirth=new DateTime(2000,7,7)
              ,BirthAdress="Hai Duong",PhoneNumber="0966416324",IsGraduated=true},
                new Person{ID=2,FirstName = "Huyen",LastName="Nguyen",Gender=Gender.Female, DateOfBirth=new DateTime(2000,2,16)
              ,BirthAdress="Hung Yen",PhoneNumber="094632123",IsGraduated=false},
               new Person{ID=3,FirstName = "Thuy Phuong",LastName="Nguy",Gender=Gender.Female, DateOfBirth=new DateTime(1996,4,27)
              ,BirthAdress="Bac Ninh",PhoneNumber="083641232",IsGraduated=true},
               new Person{ID=4,FirstName = "Khoi",LastName="Nguyen",Gender=Gender.Male, DateOfBirth=new DateTime(2004,4,23)
              ,BirthAdress="Ha Noi",PhoneNumber="0876416708",IsGraduated=true},
                new Person{ID=5,FirstName = "Hoa",LastName="Dao",Gender=Gender.Female, DateOfBirth=new DateTime(2000,12,6)
              ,BirthAdress="Lang Son",PhoneNumber="0912321643",IsGraduated=true}
            };
        public void Create(Person person)
        { person.ID = list.Max(person=>person.ID) +1;
           list.Add(person);
        }

        public void Delete(int id)
        {
            var person = list.FirstOrDefault(x => x.ID == id);
            if(person != null) list.Remove(person);
            
        }

        public List<Person> GetAll()
        {
            return list;
        }

        public void Update(int id, Person person)
        {
            var EditPerson = list.FirstOrDefault(person=>person.ID==id);
  EditPerson.FirstName = person.FirstName;
  EditPerson.LastName = person.LastName;
  EditPerson.Gender = person.Gender;
  EditPerson.DateOfBirth =person.DateOfBirth;
  EditPerson.BirthAdress = person.BirthAdress;
  EditPerson.IsGraduated = person.IsGraduated;
        }
    }
}
