using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVC2_Final.Models;
using MVC2_Final.Services;
using System.IO;
using System.Data;
 using ClosedXML.Excel;



namespace MVC2_Final.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IService _service;
    
     static  List<Person> list = new List<Person> {
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

    
  
    public HomeController(ILogger<HomeController> logger, IService service)
    {
        _logger = logger;
        _service = service;
        
       
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

      public IActionResult Work()
    {
        
        return View(list);
    }


    public IActionResult GetPeopleByGender()
    {
        
        return View(_service.GetPeopleByGender(list,Gender.Male));
    }

public IActionResult GetFullNamePeople()
    {
        
        return View(_service.GetFullNamePeople(list));
    }

public IActionResult GetOldestPerson()
    {
        
        return View(_service.GetOldestPerson(list));
    }

public IActionResult GetListPeopleByAge(int? option)
    {
        
        switch (option)
            {
                case 0: return View(_service.GetListPeopleByAge(list)[0]); 
                case 1: return View(_service.GetListPeopleByAge(list)[1]);  
                case 2: return View(_service.GetListPeopleByAge(list)[2]); 

                default: return  RedirectToAction("Index");
            }
    }

    public IActionResult GetPeopleByPlace()
    {
        
        return View(_service.GetPeopleByPlace(list,Place:"Ha Noi"));
    }

        public IActionResult ExportToExcell()
        {
            using (var wookbook = new XLWorkbook())
            {
                var wooksheet = wookbook.Worksheets.Add("PersonInfo");
                var currentRow = 1;
                wooksheet.Cell(currentRow, 1).Value = "ID";
                wooksheet.Cell(currentRow, 2).Value = "First Name";
                wooksheet.Cell(currentRow, 3).Value = "Last Name";
                wooksheet.Cell(currentRow, 4).Value = "Gender";
                wooksheet.Cell(currentRow, 5).Value = "Date of Birth";
                wooksheet.Cell(currentRow, 6).Value = "Birth Address";
                wooksheet.Cell(currentRow, 7).Value = "Phone Number";
                wooksheet.Cell(currentRow, 8).Value = "Is Granduated";
                foreach (var person in list)
                {
                    currentRow++;
                    wooksheet.Cell(currentRow, 1).Value = person.ID;
                    wooksheet.Cell(currentRow, 2).Value = person.FirstName;
                    wooksheet.Cell(currentRow, 3).Value = person.LastName;
                    wooksheet.Cell(currentRow, 4).Value = (person.Gender == Gender.Male) ? "Male" : "Female";
                    wooksheet.Cell(currentRow, 5).Value = person.DateOfBirth.ToString("dd-MM-yyyy");
                    wooksheet.Cell(currentRow, 6).Value = person.BirthAdress;
                    wooksheet.Cell(currentRow, 7).Value ="'"+ person.PhoneNumber;
                    wooksheet.Cell(currentRow, 8).Value = person.IsGraduated;
                }
                using (var stream = new MemoryStream())
                {
                    
                    wookbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "person.xlsx");
                }

            }

        }

  public IActionResult  Create()
    {
        
        return View();
    }

[HttpPost]
 public IActionResult  Create(Person person)
    {
        if(ModelState.IsValid){
                person.ID = list.Max(person=>person.ID) +1;
                list.Add(person);
                return RedirectToAction("Work");

        }
        
        return View();
    }
public IActionResult Edit(int? id)
        {
            var person =list.FirstOrDefault(person=>person.ID==id);
            if (person != null){
                    return View(person);
            }
            return RedirectToAction("Work");
        }
[HttpPost]
public IActionResult Edit(int id,Person person)
        {
            if(ModelState.IsValid){
  var EditPerson = list.FirstOrDefault(person=>person.ID==id);
  EditPerson.FirstName = person.FirstName;
  EditPerson.LastName = person.LastName;
  EditPerson.Gender = person.Gender;
  EditPerson.DateOfBirth =person.DateOfBirth;
  EditPerson.BirthAdress = person.BirthAdress;
  EditPerson.IsGraduated = person.IsGraduated;

  

            }
          
            return RedirectToAction("Work");
        }



public IActionResult Delete(int? id)
        {
         
                  var person = list.FirstOrDefault(_people => _people.ID==id);
                  if(person != null) list.Remove(person);
              
           
            return   RedirectToAction("Work");
        }

 


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
