using System.Runtime.Intrinsics.Arm;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Data.Sqlite;
public class ClientSignIn
{
  public Guid Id = Guid.NewGuid();
  public string Email { get; set; }
  public string Surname { get; set; }
  public int Age { get; set; }
  public string Password { get; set; }
  public string ConfirmPassword { get; set; }


  public ClientSignIn(string email, string surname, int age, string password, string confirmPassword)
  {

    Email = email;
    Surname = surname;
    Age = age;
    Password = password;
    ConfirmPassword = confirmPassword;
  }

}