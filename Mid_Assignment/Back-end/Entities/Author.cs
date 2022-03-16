using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Back_end.Entities;

public class Author
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]

    public int Id { get; set; }

    public string AuthorName { get; set; }

    public ICollection<Book> Books { get; set; }

}