
using Microsoft.AspNetCore.Mvc;
using MVC2_Final.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MVC2_Final.Services
{
    public class Serviece : IService
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


        

       public List<Person> GetPeopleByPlace(List<Person> OriginList,string Place){

           return OriginList.Where(Person => Person.BirthAdress == Place).ToList();
       }
        

        

    }
}
