using System.Globalization;
using System.Reflection.Metadata.Ecma335;

public class ClientBuilder
{
  private string? _email, _surname, _password, _confirmPassword;
  private int _age;

  public static ClientBuilder Builder()
  {
    return new ClientBuilder();
  }


  public ClientBuilder Name(string name)
  {
    _email = name;
    return this;
  }

  public ClientBuilder Surname(string surname)
  {
    _surname = surname;
    return this;
  }

  public ClientBuilder Age(int age)
  {
    _age = age;
    return this;
  }

  public ClientBuilder Password(string password)
  {
    _password = password;
    return this;
  }

  public ClientBuilder ConfirmPassword(string confirmPassword)
  {
    if (confirmPassword == _password)
    {
      _confirmPassword = confirmPassword;
    }
    else
    {
      throw new InvalidOperationException("Password does not match");
    }
    return this;
  }

  public Client Build()
  {
    return new Client(_email ?? string.Empty, _surname ?? string.Empty, _age, _password ?? string.Empty, _confirmPassword ?? string.Empty);
  }


}