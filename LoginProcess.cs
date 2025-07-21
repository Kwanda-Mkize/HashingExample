using System.Security.Cryptography;
using System.Text;
using Microsoft.Data.Sqlite;

public class LoginProcess
{
  public LoginProcess(SqliteConnection connection, string email, string password)
  {
    var salt = password.Reverse();
    var LoginPassword = password;
    string hashedLoginPassword;

    var combined = LoginPassword + salt;

    using (SHA256 sha = SHA256.Create())
    {
      byte[] hashBytes = sha.ComputeHash(Encoding.UTF8.GetBytes(combined));
      string hash = BitConverter.ToString(hashBytes).Replace("-", "");
      hashedLoginPassword = hash;
    }


    var checkUserCmd = connection.CreateCommand();
    checkUserCmd.CommandText = @"
    SELECT 1 
    FROM UsersTable 
    WHERE Email = $email AND Password = $password;
";
    checkUserCmd.Parameters.AddWithValue("$email", email);
    checkUserCmd.Parameters.AddWithValue("$password", hashedLoginPassword);


    var result = checkUserCmd.ExecuteScalar();

    if (result != null)
    {
      Console.WriteLine($"{email} Logged in successfully");
    }
    else
    {
      Console.WriteLine("Log in failed incorrect password!!");

    }
  }
}