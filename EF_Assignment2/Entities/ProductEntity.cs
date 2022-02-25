using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace EF_Assignment2.Entities
{
    public class ProductEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
         public int Id { get; set; }
        public string  ProductName { get; set; }
        public string Manufacture { get; set; }

         public int CategoryId { get; set; }  
        public CategoryEntity Category { get; set; }
    }
}