using System.Security.Cryptography;
using System.Text;
using Microsoft.Data.Sqlite;

public class SignUpProcess
{
  public SignUpProcess(SqliteConnection connection, Client user)
  {
    var salt = user.ConfirmPassword.Reverse();
    var SignUpPassword = user.ConfirmPassword;
    string hashedSingupPassword;
    var combined = SignUpPassword + salt;

    using (SHA256 sha = SHA256.Create())
    {
      byte[] hashBytes = sha.ComputeHash(Encoding.UTF8.GetBytes(combined));
      string hash = BitConverter.ToString(hashBytes).Replace("-", "");
      hashedSingupPassword = hash;
    }


    var checkUserCmd = connection.CreateCommand();
    checkUserCmd.CommandText = @"
    SELECT Id 
    FROM UsersTable 
    WHERE Email = $email;
";
    checkUserCmd.Parameters.AddWithValue("$email", user.Email);


    var Verify = checkUserCmd.ExecuteScalar();

    if (Verify == null)
    {
      var insertCmd = connection.CreateCommand();
      insertCmd.CommandText = @"
        INSERT INTO UsersTable (Id,Email, Age, Password)
        VALUES ($id,$email, $age, $password);
    ";
      insertCmd.Parameters.AddWithValue("$id", user.Id);
      insertCmd.Parameters.AddWithValue("$email", user.Email);
      insertCmd.Parameters.AddWithValue("$age", user.Age);
      insertCmd.Parameters.AddWithValue("$password", hashedSingupPassword);
      insertCmd.ExecuteNonQuery();
    }
    else
    {
      Console.WriteLine($"{user.Email} already has an account");
    }


  }


}