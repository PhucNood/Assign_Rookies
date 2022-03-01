using Microsoft.AspNetCore.Mvc;
using MVC2_Final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using ClosedXML.Excel;


namespace MVC2_Final.Services
{

   public interface IService
    {
        public List<Person> GetAllPeople();
        public List<Person> GetPeopleByGender(Gender Gender);
        public Person GetOldestPerson();
        public List<string> GetFullNamePeople();
        public List<List<Person>> GetListPeopleByAge();
         public List<Person> GetPeopleByPlace(string Place);
         public byte[] Export();

         public void Create(Person person);
         public void Edit(Person person);

         public void Delete(int? id);
       
    }
}
