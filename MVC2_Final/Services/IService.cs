using Microsoft.AspNetCore.Mvc;
using MVC2_Final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC2_Final.Services
{
   public interface IService
    {
        public List<Person> GetPeopleByGender(List<Person> OriginList,Gender Gender);
        public Person GetOldestPerson(List<Person> OriginList);
        public List<string> GetFullNamePeople(List<Person> OriginList);
        public List<List<Person>> GetListPeopleByAge(List<Person> OriginList);

         public List<Person> GetPeopleByPlace(List<Person> OriginList,string Place);
       
    }
}
