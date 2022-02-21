using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVC3_Assignment.Models;
using MVC3_Assignment.Services;
namespace MVC3_Assignment.Controllers;

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
        return View(_service.GetAll());
    }

    public IActionResult Privacy()
    {
        return View();
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

        }

        return RedirectToAction("Index");
    }
    
    public IActionResult Update(int? id)
    {
        var person = _service.GetAll().FirstOrDefault(person => person.ID == id);
        if (person != null)
        {
            return View(person);
        }
        return RedirectToAction("Index");

    }
    [HttpPost]
    public IActionResult Update(int id, Person person)
    {
        if (ModelState.IsValid)
        {

            _service.Update( person);

        }

        return RedirectToAction("Index");

    }



    public IActionResult Delete(int id)
    {
       var person = _service.GetAll().FirstOrDefault(x => x.ID == id);
        ViewData["deleted-name"] = person.FirstName+" "+person.LastName;
        _service.Delete(id);
       
     


        return View();

    }

  




    public IActionResult Detail(int id)
    {
        var person = _service.GetAll().FirstOrDefault(x => x.ID == id);
        return View(person);
    }




    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
