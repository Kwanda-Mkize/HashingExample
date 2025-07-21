public class ClientLogin
{
  public string Email { get; set; }
  public string Password { get; set; }

  public ClientLogin(string email, string password)
  {
    Email = email;
    Password = password;
  }
}