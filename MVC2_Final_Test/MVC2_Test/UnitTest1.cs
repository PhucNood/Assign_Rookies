using NUnit.Framework;
using MVC2_Final.Controllers;
using MVC2_Final.Services;
using Moq;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using MVC2_Final.Models;
using System.Collections.Generic;
using System;

namespace MVC2_Test;


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
          _mockService.Setup(s=>s.GetAllPeople()).Returns(list); // mocking the list
        
    }


    [Test]
    public void Index_Returns_View()
    {

        // Act
        var result = _controller.Index();
        // Assert
        Assert.IsInstanceOf<ViewResult>(result, "Invalist return type");
    }

    [Test]
    public void Work_Return_ViewAllList()
    {
        // set up
      
        const int Experted_Meber_In_List =5;
        //Act
        var result = _controller.Work();
        // Assert
        Assert.IsInstanceOf<ViewResult>(result, "Invalid return type");
        var view = (ViewResult)result;
       Assert.IsNotNull(view.ViewData.Model,"Model must not null"); // check not null
       Assert.IsAssignableFrom<List<Person>>(view.ViewData.Model,"Invalid model"); // check valid model
      var model = (List<Person>)view.ViewData.Model;
      Assert.AreEqual(Experted_Meber_In_List,model.Count);

    }
}