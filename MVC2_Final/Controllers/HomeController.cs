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

        return View(_service.GetAllPeople());
    }


    public IActionResult GetPeopleByGender()
    {

        return View(_service.GetPeopleByGender( Gender.Male));
    }

    public IActionResult GetFullNamePeople()
    {

        return View(_service.GetFullNamePeople());
    }

    public IActionResult GetOldestPerson()
    {

        return View(_service.GetOldestPerson());
    }

    public IActionResult GetListPeopleByAge(int? option)
    {

        switch (option)
        {
            case 0: return View(_service.GetListPeopleByAge()[0]);
            case 1: return View(_service.GetListPeopleByAge()[1]);
            case 2: return View(_service.GetListPeopleByAge()[2]);

            default: return RedirectToAction("Index");
        }
    }

    public IActionResult GetPeopleByPlace()
    {

        return View(_service.GetPeopleByPlace( Place: "Ha Noi"));
    }

    public IActionResult ExportToExcell()
    {

        return File(_service.Export(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "person.xlsx");


    }

    public IActionResult Create()
    {

        return View();
    }

    [HttpPost]
    public IActionResult Create(Person person)
    {
        if (ModelState.IsValid)
        {
            _service.Create(person);
            return RedirectToAction("Work");

        }

        return View();
    }
    public IActionResult Edit(int? id)
    {
        var person = _service.GetAllPeople().FirstOrDefault(person => person.ID == id);
        if (person != null)
        {
            return View(person);
        }
        return RedirectToAction("Work");
    }
    [HttpPost]
    public IActionResult Edit(int id, Person person)
    {
        if (ModelState.IsValid)
        {
            _service.Edit(person);

        }

        return RedirectToAction("Work");
    }



    public IActionResult Delete(int? id)
    {
        if (id != null)
        {
            _service.Delete(id);
        }

        return RedirectToAction("Work");
    }




    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
