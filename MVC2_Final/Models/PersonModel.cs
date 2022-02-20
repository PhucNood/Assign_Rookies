using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MVC2_Final.Models
{
    public enum Gender { Male,Female,Other}
    public class Person
    {
        [Required(ErrorMessage = "Required.")]
        public int ID { get; set; }
         [Required(ErrorMessage = "Required.")]
        public string FirstName { get; set; }
         [Required(ErrorMessage = "Required.")]
        public string LastName { get; set; }
         [Required(ErrorMessage = "Required.")]
        public Gender Gender { get; set; }
         [Required(ErrorMessage = "Required.")]
        public DateTime DateOfBirth { get; set; }
         [Required(ErrorMessage = "Required.")]
        [RegularExpression(@"\\d{10}",ErrorMessage="Invalid Phone Number!")]
        public string PhoneNumber { get; set; }
         [Required(ErrorMessage = "Required.")]
        public string BirthAdress { get; set; }
        
        public bool IsGraduated { get; set; }
        
    }
}
