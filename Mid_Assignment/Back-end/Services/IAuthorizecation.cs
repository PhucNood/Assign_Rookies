namespace Back_end.Services
{
    public interface IAuthorizecation
    {
        string Authenticate(string username, string password);
    }
}