using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Back_end.Entities;
public class User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string UserName { get; set; }

    public string Password { get; set; }

    public bool IsSuper { get; set; }

    public ICollection<BookBorrowingRequest> Requests { get; set; }
    
}