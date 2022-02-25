namespace EF_Assignment2.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string  ProductName { get; set; }
        public string Manufacture { get; set; }

        public int CategoryId { get; set; } =1;
    }
}