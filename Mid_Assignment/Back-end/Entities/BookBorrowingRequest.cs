using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Back_end.Entities;

public class BookBorrowingRequest
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int Id { get; set; }

    [DataType(DataType.Date)]
    public DateTime DateOfRequest { get; set; }

    public Status Status { get; set; }


    public int UserId { get; set; }

    public int? ApproverID { get; set; } = null;

    public User User { get; set; }
    public ICollection<Book> Books { get; set; }

}

public enum Status { Approved, Rejected, Waiting }