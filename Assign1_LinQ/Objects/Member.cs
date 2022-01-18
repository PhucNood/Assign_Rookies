using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assign1_LinQ.Objects
{
   
    public  class Member
    {
        public string FirstName { get; set; }   
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? PhoneNumber { get; set; }
        public string BirthPlace { get; set; }
        public uint Age { get { return (uint)(DateTime.Now.Year - DateOfBirth.Year); } }
        public bool IsGraduated { get; set; }
        public void PrintInfor() { Console.WriteLine(FirstName + " " + LastName + "\t" + Gender + "\t" + DateOfBirth.ToString("dd/MM/yyyy") + "\t" + PhoneNumber + "\t" + BirthPlace + "\t" + Age + "\t" + IsGraduated); }
    }
     public enum Gender { Male, Female, Other }
}
