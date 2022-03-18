using Back_end.Entities;
using System.ComponentModel.DataAnnotations;

namespace Back_end.Models;
public class BookBorrowingRequestModel
{

    public int Id { get; set; }
    [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
    public DateTime DateOfRequest { get; set; }

    public Status Status { get; set; }

    public int UserId { get; set; }

    public int DetailID { get; set; }


    public int ApproverID { get; set; }

}