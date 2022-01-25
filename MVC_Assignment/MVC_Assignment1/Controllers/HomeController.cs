using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVC_Assignment1.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MVC_Assignment1.Serviece;
using ClosedXML.Excel;
using System.IO;

namespace MVC_Assignment1.Controllers
{
   

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IListBuilder _listBuilder;
        private readonly List<Person> _orignalList;
      
     
        public HomeController(ILogger<HomeController> logger,IListBuilder listBuilder)
        {
            _logger = logger;
            _listBuilder = listBuilder;
            _orignalList = listBuilder.GetOriginalList();
           
        }

       
        public IActionResult Index()
        {
           
            return View();
        }

        
        public IActionResult Privacy()
        {
            return View();
        }

        //Use Route Atribute to define
        [Route("NashTech/Rookies/list-by-gender")]
        public IActionResult ListByGender()
        {
            return new ObjectResult(_listBuilder.GetPeopleByGender(_orignalList,Gender.Male));
        }

        [Route("NashTech/Rookies/list-fullname")]
        public IActionResult ListFullName()
        {

            return new ObjectResult(_listBuilder.GetFullNamePeople(_orignalList));
        }

        [Route("NashTech/Rookies/list-by-age")]
        public IActionResult ListByAge(int? option)
        {
            switch (option)
            {
                case 0: return new ObjectResult(_listBuilder.GetListPeopleByAge(_orignalList)[0]); 
                case 1: return new ObjectResult(_listBuilder.GetListPeopleByAge(_orignalList)[1]); 
                case 2: return new ObjectResult(_listBuilder.GetListPeopleByAge(_orignalList)[2]);

                default: return new ObjectResult(_orignalList);
            }
        }
        [Route("NashTech/Rookies/Export")]
        public IActionResult ExportToExcell()
        {
            using (var wookbook = new XLWorkbook())
            {
                var wooksheet = wookbook.Worksheets.Add("PersonInfo");
                var currentRow = 1;
                wooksheet.Cell(currentRow, 1).Value = "First Name";
                wooksheet.Cell(currentRow, 2).Value = "Last Name";
                wooksheet.Cell(currentRow, 3).Value = "Gender";
                wooksheet.Cell(currentRow, 4).Value = "Date of Birth";
                wooksheet.Cell(currentRow, 5).Value = "Birth Address";
                wooksheet.Cell(currentRow, 6).Value = "Phone Number";
                wooksheet.Cell(currentRow, 6).Value = "Is Granduated";
                foreach (var person in _orignalList)
                {
                    currentRow++;
                    wooksheet.Cell(currentRow, 1).Value = person.FirstName;
                    wooksheet.Cell(currentRow, 2).Value = person.LastName;
                    wooksheet.Cell(currentRow, 3).Value = (person.Gender == Gender.Male) ? "Male" : "Female";
                    wooksheet.Cell(currentRow, 4).Value = person.DateOfBirth.ToString("dd-MM-yyyy");
                    wooksheet.Cell(currentRow, 5).Value = person.BirthAdress;
                    wooksheet.Cell(currentRow, 6).Value = person.PhoneNumber;
                    wooksheet.Cell(currentRow, 6).Value = person.IsGraduated;
                }
                using (var stream = new MemoryStream())
                {
                    wookbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "person.xlsx");
                }

            }

        }

      [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
