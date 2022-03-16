using Back_end.Entities;

namespace Back_end.Models;
public class BookBorrowingRequestModel
{

    public int Id { get; set; }

    public DateTime DateOfRequest { get; set; }

    public Status Status { get; set; }

    public int UserId { get; set; }

    public int DetailID { get; set; }


    public int ApproverID { get; set; }

}