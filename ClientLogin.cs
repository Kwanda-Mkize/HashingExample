public class ClientLogin
{
  public string Name { get; set; }
  public string Password { get; set; }

  public ClientLogin(string name, string password)
  {
    Name = name;
    Password = password;
  }
}