using Microsoft.AspNetCore.Mvc;
using API_Assignment2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace API_Assignment2.Services
{

   public interface IPeopleService
    {
        public void Create(Person person);
        public void Update(Person person);

        public void Delete(int id);

        public List<Person> GetAll();

        public List<Person> FilterListByName(string name);
        public List<Person> FilterListByGender(Gender gender);
        public List<Person> FilterListByPlace(string place); 
       
    }
}
