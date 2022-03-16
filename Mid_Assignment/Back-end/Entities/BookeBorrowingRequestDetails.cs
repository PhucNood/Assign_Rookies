using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Back_end.Entities;

public class BookeBorrowingRequestDetails{ 
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
   public int Id { get; set; }
   
   public ICollection<BookBorrowingRequest> Requests { get; set; }
    
    public ICollection<Book> Books { get; set; }
   
}