

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace EF_Assignment1.Models
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentId { get; set; }
        [Column("First Name", TypeName = "ntext")]
        public string FirstName { get; set; }
        [Column("Last Name", TypeName = "ntext")]
        public string LastName { get; set; }
        [Column("City", TypeName = "ntext")]
        public string City { get; set; }
        [Column("State", TypeName = "ntext")]
        public string State { get; set; }

    }
}