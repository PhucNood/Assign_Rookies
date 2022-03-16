using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Back_end.Entities;

public class BookBorrowingRequest{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int Id { get; set; }
    
   

    public DateTime DateOfRequest { get; set; } 

    public Status Status { get; set; }

     public int UserId { get; set; }

    public User Requester { get; set; }

    public int DetailID { get; set;}

    public BookeBorrowingRequestDetails Detail { get; set;}

}

public enum Status {Approved,Rejected,Waiting }