using Microsoft.AspNetCore.Mvc;
using MVC_Assignment1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Assignment1.Serviece
{
   public interface IListBuilder
    {
        public List<Person> GetPeopleByGender(List<Person> OriginList,Gender Gender);
        public Person GetOldestPerson(List<Person> OriginList);
        public List<string> GetFullNamePeople(List<Person> OriginList);
        public List<List<Person>> GetListPeopleByAge(List<Person> OriginList);
        public List<Person> GetOriginalList();
       
    }
}
