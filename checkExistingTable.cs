using Microsoft.Data.Sqlite;
using System;
using System.IO;

public class checkExistingTable
{
  public bool TableExists(SqliteConnection connection, string tableName)
  {
    var checkCmd = connection.CreateCommand();
    checkCmd.CommandText = @"
            SELECT Name 
            FROM sqlite_master 
            WHERE type = 'table' AND name = $UsersTable;
        ";
    checkCmd.Parameters.AddWithValue("$UsersTable", tableName);

    return checkCmd.ExecuteScalar() != null;
  }

  public void CheckIfTableExists(SqliteConnection connection, string tableName)
  {
    if (!TableExists(connection, tableName))
    {
      Console.WriteLine("Table 'user' does not exist. Creating...");
      string createUserTable = File.ReadAllText("sql/create_user.sql");
      using var createCmd = connection.CreateCommand();
      createCmd.CommandText = createUserTable;
      createCmd.ExecuteNonQuery();
    }

  }
}