using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Back_end.Entities;

public class Book{
       [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]    
        public int Id { get; set; }
        public string BookName { get; set; }

        public int CateId { get; set; }
        
        public Category Category { get; set; }
}