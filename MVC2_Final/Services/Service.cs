
using Microsoft.AspNetCore.Mvc;
using MVC2_Final.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ClosedXML.Excel;

namespace MVC2_Final.Services
{

    public class Serviece : IService
    {
        static List<Person> list = new List<Person> {
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
        public void Create(Person person)
        {  
                person.ID = list.Max(person=>person.ID) +1;
                list.Add(person);
        }

        public void Delete(int? id)
        {
              var person = list.FirstOrDefault(_people => _people.ID==id);
                  if(person != null) list.Remove(person);
        }

        public byte[] Export()
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
                    wooksheet.Cell(currentRow, 7).Value = "'" + person.PhoneNumber;
                    wooksheet.Cell(currentRow, 8).Value = person.IsGraduated;
                }
                using (var stream = new MemoryStream())
                {

                    wookbook.SaveAs(stream);
                    return stream.ToArray();

                }

            }
        }

        public List<Person> GetAllPeople()
        {
            return list;
        }

        public List<string> GetFullNamePeople()
        {
            return (from person in list select (person.FirstName + " " + person.LastName)).ToList();
        }

        public List<List<Person>> GetListPeopleByAge()
        {
            List<Person> ListEqual2000 = (from person in list where person.DateOfBirth.Year == 2000 select person).ToList();
            List<Person> ListUnder2000 = (from person in list where person.DateOfBirth.Year < 2000 select person).ToList();
            List<Person> ListOver2000 = (from person in list where person.DateOfBirth.Year > 2000 select person).ToList();
            return new List<List<Person>> { ListEqual2000, ListUnder2000, ListOver2000 };

        }

        public Person GetOldestPerson()
        {
            return (Person)(from person in list where person.DateOfBirth == list.Max(person => person.DateOfBirth) select person);
        }



        public List<Person> GetPeopleByGender( Gender Gender)
        {
            return (from person in list where person.Gender == Gender.Male select person).ToList();
        }




        public List<Person> GetPeopleByPlace( string Place)
        {

            return list.Where(Person => Person.BirthAdress == Place).ToList();
        }

        public void Edit(Person person)
        {
            var EditPerson = list.FirstOrDefault(p => p.ID == person.ID);
            EditPerson.FirstName = person.FirstName;
            EditPerson.LastName = person.LastName;
            EditPerson.Gender = person.Gender;
            EditPerson.DateOfBirth = person.DateOfBirth;
            EditPerson.BirthAdress = person.BirthAdress;
            EditPerson.IsGraduated = person.IsGraduated;


        }

       
    }
}
