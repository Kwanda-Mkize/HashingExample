using System.IO;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Data.Sqlite;

var dbPath = "sql/Mydb.sqlite";

using var connection = new SqliteConnection($"Data Source={dbPath}");
connection.Open();

checkExistingTable checkExisting = new checkExistingTable();
checkExisting.CheckIfTableExists(connection, "UsersTable");


// Sign up process
// ClientSignIn UserSignUp = UserBuilder.Builder()
// .Name("Khaya")
// .Surname("Ngcobo")
// .Age(23)
// .Password("Khaya111")
// .ConfirmPassword("Khaya111")
// .Build();

// SignUpProcess signUp = new SignUpProcess(connection, UserSignUp);



// // Login up process
ClientLogin UserLogin = new ClientLogin("Khaya", "Khaya111");
LoginProcess login = new LoginProcess(connection, UserLogin.Email, UserLogin.Password);

// var dropTableCmd = connection.CreateCommand();
// dropTableCmd.CommandText = "DROP TABLE IF EXISTS user;";
// dropTableCmd.ExecuteNonQuery();


