using System;
using Npgsql;

class Program
{
    private static string Host = "localhost";
    private static string User = "postgres";
    private static string DBname = "Ultimate-Tic-Tac-Toe";
    private static string Password = "liorewq";
    private static string Port = "5432";

    static void Main()
    {
        string connString = GetConnectionString();

        using (var conn = new NpgsqlConnection(connString))
        {
            try
            {
                Console.WriteLine("Opening Connection");
                conn.Open();

                CreateTable(conn, "players", "playersID serial PRIMARY KEY, username VARCHAR(50), wins INT, losses INT");
                CreateTable(conn, "games", "gamesID serial PRIMARY KEY, status VARCHAR(50), start_time TIMESTAMP, end_time TIMESTAMP, winner_id INT");
                CreateTable(conn, "boards", "boardNumber INT PRIMARY KEY, cellX INT, cellY INT, occupied BOOLEAN");
                CreateTable(conn, "boardState", "boardStateID serial PRIMARY KEY, boardNumber INT REFERENCES boards(boardNumber)");

                Console.WriteLine("Finished Creating Tables");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }

    private static string GetConnectionString()
    {
        return String.Format(
            "Host={0};Port={1};Username={2};Password={3};Database={4};",
            Host,
            Port,
            User,
            Password,
            DBname);
    }

    private static void CreateTable(NpgsqlConnection connection, string tableName, string tableDefinition)
    {
        using (var command = new NpgsqlCommand($"CREATE TABLE IF NOT EXISTS {tableName} ({tableDefinition})", connection))
        {
            command.ExecuteNonQuery();
        }
    }
}
