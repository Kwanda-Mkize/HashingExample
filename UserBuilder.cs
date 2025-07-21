using System.Globalization;
using System.Reflection.Metadata.Ecma335;

public class UserBuilder
{
  private string? _email, _surname, _password, _confirmPassword;
  private int _age;

  public static UserBuilder Builder()
  {
    return new UserBuilder();
  }


  public UserBuilder Name(string name)
  {
    _email = name;
    return this;
  }

  public UserBuilder Surname(string surname)
  {
    _surname = surname;
    return this;
  }

  public UserBuilder Age(int age)
  {
    _age = age;
    return this;
  }

  public UserBuilder Password(string password)
  {
    _password = password;
    return this;
  }

  public UserBuilder ConfirmPassword(string confirmPassword)
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

  public ClientSignIn Build()
  {
    return new ClientSignIn(_email ?? string.Empty, _surname ?? string.Empty, _age, _password ?? string.Empty, _confirmPassword ?? string.Empty);
  }


}