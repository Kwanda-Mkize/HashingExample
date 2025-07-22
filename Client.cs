using System.Runtime.Intrinsics.Arm;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Data.Sqlite;
public class Client
{
  public Guid Id = Guid.NewGuid();
  public string Email { get; set; }
  public string Surname { get; set; }
  public int Age { get; set; }
  public string Password { get; set; }
  public string ConfirmPassword { get; set; }


  public Client(string email, string surname, int age, string password, string confirmPassword)
  {

    Email = email;
    Surname = surname;
    Age = age;
    Password = password;
    ConfirmPassword = confirmPassword;
  }

  public Client(string email, string password)
  {
    Email = email;
    Password = password;
    Surname = string.Empty;
    ConfirmPassword = string.Empty;
    Age = 0;
  }

}