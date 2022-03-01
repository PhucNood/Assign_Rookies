using NUnit.Framework;
using MVC3_Assignment.Controllers;
using MVC3_Assignment.Services;
using Moq;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using MVC3_Assignment.Models;
using System.Collections.Generic;
using System;
using System.Linq;

namespace MVC3_Test;

public class Tests
{
    private HomeController _controller;
    private Mock<IService> _mockService;

    private Mock<ILogger<HomeController>> _mockLogger;
    private static List<Person> list = new List<Person> {
              new Person{ID=1,FirstName = "Testname1",LastName="Nguyen",Gender=Gender.Male, DateOfBirth=new DateTime(2000,6,7)
              ,BirthAdress="Hai Duong",PhoneNumber="0966416324",IsGraduated=true},
                new Person{ID=2,FirstName = "Testname2",LastName="Nguyen",Gender=Gender.Female, DateOfBirth=new DateTime(2000,2,16)
              ,BirthAdress="Hung Yen",PhoneNumber="094632123",IsGraduated=false},
               new Person{ID=3,FirstName = "Testname3",LastName="Nguy",Gender=Gender.Female, DateOfBirth=new DateTime(1996,5,27)
              ,BirthAdress="Bac Ninh",PhoneNumber="083641232",IsGraduated=true},
               new Person{ID=4,FirstName = "Testname4",LastName="Nguyen",Gender=Gender.Male, DateOfBirth=new DateTime(2004,2,23)
              ,BirthAdress="Ha Noi",PhoneNumber="0876416708",IsGraduated=true},
                new Person{ID=5,FirstName = "Testname5",LastName="Dao",Gender=Gender.Female, DateOfBirth=new DateTime(2000,11,6)
              ,BirthAdress="Lang Son",PhoneNumber="0912321643",IsGraduated=true}
            };

    [SetUp]
    public void Setup()
    {
        _mockService = new Mock<IService>();
        _mockLogger = new Mock<ILogger<HomeController>>();
        _controller = new HomeController(_mockLogger.Object, _mockService.Object);
        _mockService.Setup(s => s.GetAll()).Returns(list); // mocking the list

    }
    [Test]
    public void Index_Returns_ViewGetAll()
    {
        const int Experted_Meber_In_List = 5;
        //Act
        var result = _controller.Index();
        // Assert
        Assert.IsInstanceOf<ViewResult>(result, "Invalid return type");
        var view = (ViewResult)result;
        Assert.IsNotNull(view.ViewData.Model, "Model must not null"); // check not null
        Assert.IsAssignableFrom<List<Person>>(view.ViewData.Model, "Invalid model"); // check valid model
        var model = (List<Person>)view.ViewData.Model;
        Assert.AreEqual(Experted_Meber_In_List, model.Count);
    }

    [Test]
    public void Create_Returns_View()
    {

        //Action
        var result = _controller.Create();
        //Asert
        Assert.IsInstanceOf<ViewResult>(result);
        var view = result as ViewResult;
    }

    [Test]
    public void Create_InvalidModel_ReturnsView_WithErrorModelState()
    {
      //arrage
      const string key = "ERROR";
      const string message = "Invalid model!!!";
      _controller.ModelState.AddModelError(key, message);
      // Act
     var act= _controller.Create(null);
     // Assert
      Assert.IsInstanceOf<ViewResult>(act);
      var view = (ViewResult)act;
      var model = view.ViewData.ModelState;
      Assert.IsFalse(model.IsValid,"Invalid model");
    

    }

     [Test]
    public void Create_ValidModel_ReturnsRedirectResult()
    {
      //arrage
      var personDTO = new Person {ID=1,FirstName = "Testname1",LastName="Test",Gender=Gender.Male, DateOfBirth=new DateTime(2000,6,7)
              ,BirthAdress="Hai Duong",PhoneNumber="0966416324",IsGraduated=true};
               _mockService.Setup(s => s.Create(personDTO)).Callback(()=>list.Add(personDTO));


      // Act
      var result =_controller.Create(personDTO);
    // Assert
     Assert.IsInstanceOf<RedirectToActionResult>(result);
     var view = (RedirectToActionResult)result;
    Assert.AreEqual("Index",view.ActionName,"Invalid Redirect action");        
    }

   [Test]
   public void Delete_Returns_View(){
     //Arrange
      int id = 2;
      var person = list.FirstOrDefault(x => x.ID == id);
      _mockService.Setup(s => s.Delete(id)).Callback(()=>list.Remove(person));

      // Act
    var  result = _controller.Delete(id);
    Assert.IsInstanceOf<ViewResult>(result);
   var view = (ViewResult)result;
   Assert.AreEqual(person.FirstName+" " + person.LastName,view.ViewData["deleted-name"]);

   }

   [Test]
 public void Detail_Returns_View(){
  //Arrange
   int id = 3 ;
   _mockService.Setup(s => s.Detail(id)).Callback(()=>list.FirstOrDefault(x => x.ID == id));
   
   //Act
   var result = _controller.Detail(id);
   
   Assert.IsInstanceOf<ViewResult>(result);
   var view = (ViewResult)result;
   

 }
       
   [Test]
 public void Update_Returns_RedirectToActionResult(){
  //Arrange
   int id = 8 ;    
   //Act
   var result = _controller.Update(id); 
   // Assert
   Assert.IsInstanceOf<RedirectToActionResult>(result);
  
 }

 [Test]
 public void Update_InvalidModel_ReturnsView_WithErrorModelState(){
   const string key = "ERROR";
      const string message = "Invalid model!!!";
      _controller.ModelState.AddModelError(key, message);
      // Act
     var act= _controller.Update(null);
     // Assert
      Assert.IsInstanceOf<ViewResult>(act);
      var view = (ViewResult)act;
      var model = view.ViewData.ModelState;
      Assert.IsFalse(model.IsValid,"Invalid model");
  
 }

 [Test]
 public void Update_Valid_ReturnsRedirectToActionResult(){
   var personDTO = new Person {ID=4,FirstName = "Testname4",LastName="Test",Gender=Gender.Male, DateOfBirth=new DateTime(2000,6,7)
              ,BirthAdress="Hai Duong",PhoneNumber="0966416324",IsGraduated=true};
               _mockService.Setup(s => s.Create(personDTO)).Callback(()=>list.Add(personDTO));

 // Act
      var result =_controller.Update(personDTO);
    // Assert
     Assert.IsInstanceOf<RedirectToActionResult>(result);
     var view = (RedirectToActionResult)result;
    Assert.AreEqual("Update",view.ActionName,"Invalid Redirect action");        
    }
  
 


 

}