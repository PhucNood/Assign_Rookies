
using Microsoft.AspNetCore.Mvc;
using API_Assignment2.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace API_Assignment2.Services
{
    public class PeopleService : IPeopleService
    {

        public static List<Person> listPeople = new List<Person> {
              new Person{ID=1,FirstName = "Phuc",LastName="Nguyen",Gender=Gender.Male, DateOfBirth=new DateTime(2000,7,7)
              ,BirthPlace="Hai Duong"},
                new Person{ID=2,FirstName = "Huyen",LastName="Nguyen",Gender=Gender.Female, DateOfBirth=new DateTime(2000,2,16)
              ,BirthPlace="Hung Yen"},
               new Person{ID=3,FirstName = "Thuy Phuong",LastName="Nguy",Gender=Gender.Female, DateOfBirth=new DateTime(1996,4,27)
              ,BirthPlace="Bac Ninh"},
               new Person{ID=4,FirstName = "Khoi",LastName="Nguyen",Gender=Gender.Male, DateOfBirth=new DateTime(2004,4,23)
              ,BirthPlace="Ha Noi"},
                new Person{ID=5,FirstName = "Hoa",LastName="Dao",Gender=Gender.Female, DateOfBirth=new DateTime(2000,12,6)
              ,BirthPlace="Lang Son"}
            };
        public void Create(Person person)
        {
            person.ID = listPeople.Max(person => person.ID) + 1;
            listPeople.Add(person);
        }

        public void Delete(int id)
        {
            var person = listPeople.FirstOrDefault(x => x.ID == id);
            if (person != null) listPeople.Remove(person);

        }

        public List<Person> FilterListByGender(Gender gender)
        {
            return listPeople.Where(x => x.Gender == gender).ToList();
        }

        public List<Person> FilterListByName(string name)
        {
            return listPeople.Where(x => x.FirstName+" "+x.LastName == name).ToList();
        }

        public List<Person> FilterListByPlace(string place)
        {
           return listPeople.Where(x => x.BirthPlace == place).ToList();
        }

        public List<Person> GetAll()
        {
            return listPeople;
        }

        public void Update( Person person)
        {
            var EditPerson = listPeople.FirstOrDefault(p=>p.ID == person.ID);
            EditPerson.FirstName = person.FirstName;
            EditPerson.LastName = person.LastName;
            EditPerson.Gender = person.Gender;
            EditPerson.DateOfBirth = person.DateOfBirth;
            EditPerson.BirthPlace = person.BirthPlace;
          
        }
    }
}
