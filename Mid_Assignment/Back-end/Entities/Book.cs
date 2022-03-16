using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Back_end.Entities;

public class Book
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int Id { get; set; }
    public string BookName { get; set; }

    public string Author { get; set; }

    public DateTime PublishedDate { get; set; }

    public int CategoryId { get; set; }

    public bool Available { get; set; }


    public int RequestId { get; set; }


    public Category Category { get; set; }
    public BookBorrowingRequest Request { get; set; }

}