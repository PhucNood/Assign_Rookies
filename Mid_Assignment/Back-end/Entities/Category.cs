using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Back_end.Entities;

public class Category
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]

    public int Id { get; set; }

    public string CategoryName { get; set; }

    public ICollection<Book> Books { get; set; }


}