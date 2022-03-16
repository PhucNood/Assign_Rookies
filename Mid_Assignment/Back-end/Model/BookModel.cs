
namespace Back_end.Models;
public class BookModel
{

    public int Id { get; set; }
    public string BookName { get; set; }

    public string Author { get; set; }

    public int PublishedYear { get; set; }

    public string Image { get; set; }

    public int CategoryId { get; set; }

    public bool Available { get; set; }


    public int? RequestId { get; set; } = null;



    
}