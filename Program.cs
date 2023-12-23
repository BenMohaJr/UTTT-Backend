using System;
using Npgsql;


class Program
{
    // private static string connection = "Host=localhost;Port=5432;Username=postgres;Password=a3viheQf;Database=Ultimate-Tic-Tac-Toe;";
    private static string Host = "localhost";
    private static string User = "postgres";
    private static string DBname = "Ultimate-Tic-Tac-Toe";
    private static string Password = "liorewq";
    private static string Port = "5432";
    static void Main()
    {
        string connString = String.Format(
            "Host={0};Port={1};Username={2};Password={3};Database={4};",
            Host,
            Port,
            User,
            Password,
            DBname);

        using (var conn = new NpgsqlConnection(connString))
        {
            Console.WriteLine("Opening Connection");
            conn.Open();



            using (var command = new NpgsqlCommand("CREATE TABLE test (id serial PRIMARY KEY, name VARCHAR(50), quantity INTEGER)", conn))
            {
                command.ExecuteNonQuery();
                Console.WriteLine("Finished Creating Table");
            }
        }
    }
}
