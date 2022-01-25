using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using MVC_Assignment1.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Assignment1.Serviece
{
    public class ListBuilder : IListBuilder
    {
        public List<string> GetFullNamePeople(List<Person> OriginList)
        {
            return (from person in OriginList select(person.FirstName+" "+person.LastName)).ToList();
        }

        public List<List<Person>> GetListPeopleByAge(List<Person> OriginList)
        {
            List<Person> ListEqual2000 = (from person in OriginList where person.DateOfBirth.Year == 2000 select person).ToList();
            List<Person> ListUnder2000 = (from person in OriginList where person.DateOfBirth.Year < 2000 select person).ToList();
            List<Person> ListOver2000 = (from person in OriginList where person.DateOfBirth.Year > 2000 select person).ToList();
            return new List<List<Person>> { ListEqual2000, ListUnder2000, ListOver2000 };

        }

        public Person GetOldestPerson(List<Person> OriginList)
        {
            return (Person)(from person in OriginList where person.DateOfBirth == OriginList.Max(person=>person.DateOfBirth) select person);
        }

       

        public List<Person> GetPeopleByGender(List<Person> OriginList, Gender Gender)
        {
            return (from person in OriginList where person.Gender == Gender.Male select person).ToList();
        }


        public List<Person> GetOriginalList()
        {
            return new List<Person> {
              new Person{FirstName = "Phuc",LastName="Nguyen",Gender=Gender.Male, DateOfBirth=new DateTime(2000,7,7)
              ,BirthAdress="Hai Duong",PhoneNumber="0966416324",IsGraduated=true},
                new Person{FirstName = "Huyen",LastName="Nguyen",Gender=Gender.Female, DateOfBirth=new DateTime(2000,2,16)
              ,BirthAdress="Hung Yen",PhoneNumber="094632123",IsGraduated=false},
               new Person{FirstName = "Thuy Phuong",LastName="Nguy",Gender=Gender.Female, DateOfBirth=new DateTime(1996,4,27)
              ,BirthAdress="Bac Ninh",PhoneNumber="083641232",IsGraduated=true},
               new Person{FirstName = "Khoi",LastName="Nguyen",Gender=Gender.Male, DateOfBirth=new DateTime(2004,4,23)
              ,BirthAdress="Ha Noi",PhoneNumber="0876416708",IsGraduated=true},
                new Person{FirstName = "Hoa",LastName="Dao",Gender=Gender.Female, DateOfBirth=new DateTime(2000,12,6)
              ,BirthAdress="Lang Son",PhoneNumber="0912321643",IsGraduated=true}
            };
        }

        

        

    }
}
