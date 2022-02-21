using Microsoft.AspNetCore.Mvc;
using MVC3_Assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MVC3_Assignment.Services
{

   public interface IService
    {
        public void Create(Person person);
        public void Update(Person person);

        public void Delete(int id);

        public List<Person> GetAll();
       
    }
}
