using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Back_end.Entities;
public class User{ 
    [Key]
    public int Id { get; set; }
}