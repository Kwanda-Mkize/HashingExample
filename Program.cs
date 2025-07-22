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
// Client UserSignUp = ClientBuilder.Builder()
// .Name("Onthatile")
// .Surname("Seodigeng")
// .Age(23)
// .Password("Seodigeng111")
// .ConfirmPassword("Seodigeng111")
// .Build();

// SignUpProcess signUp = new SignUpProcess(connection, UserSignUp);



// // Login up process
Client UserLogin = new Client("Onthatile", "Seodigeng111");
LoginProcess login = new LoginProcess(connection, UserLogin.Email, UserLogin.Password);

// var dropTableCmd = connection.CreateCommand();
// dropTableCmd.CommandText = "DROP TABLE IF EXISTS user;";
// dropTableCmd.ExecuteNonQuery();


