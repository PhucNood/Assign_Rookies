
namespace Back_end.Models;
public class BookModel
{

    public int Id { get; set; }
    public string BookName { get; set; }

    public string Author { get; set; }

    public DateTime PublishedDate { get; set; }

    public int CategoryId { get; set; }

    public bool Available { get; set; }

}