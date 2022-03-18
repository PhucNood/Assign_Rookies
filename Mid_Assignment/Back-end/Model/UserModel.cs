using Back_end.Entities;
using System.ComponentModel.DataAnnotations;
namespace Back_end.Models;

public class UserModel
{

    public int Id { get; set; }


    public string UserName { get; set; }


    public string Account { get; set; }


    public string Password { get; set; }

    public Gender Gender { get; set; }

    public string Address { get; set; }


    public string Phone { get; set; }
    [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
    public DateTime  DateOfBirth { get; set; }

    public bool IsSuper { get; set; }

}