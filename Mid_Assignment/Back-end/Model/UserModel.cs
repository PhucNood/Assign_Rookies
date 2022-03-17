namespace Back_end.Models;
public class UserModel
{

 public int Id { get; set; }

    public string UserName { get; set; }

    public string Password { get; set; }

    public bool IsSuper { get; set; }


}