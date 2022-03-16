using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Back_end.Entities;

public class Book
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int Id { get; set; }
    public string BookName { get; set; }

    public int AuthorId { get; set; }

    public Author Author { get; set; }

    public DateTime PublishedDate { get; set; }

    public int CateId { get; set; }

    public bool Available { get; set; }

    public Category Category { get; set; }

    public int RequestDetailId { get; set; }

    public BookeBorrowingRequestDetails RequestDetail { get; set; }

}