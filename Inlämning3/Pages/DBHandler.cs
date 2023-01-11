using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySqlConnector;

namespace Inlämning3.Pages
{
    public class DBHandler
    {
        //Metod som ansluter en databas
        public static MySqlConnection getConnection()
        {
            string server = "localhost";
            string port = "3306";
            string uid = "root";
            string password = "3884";
            string connectionString;

            connectionString = string.Format("SERVER={0};PORT={1};USERNAME={2};PASSWORD={3};", server, port, uid, password);

            MySqlConnection connection = connection = new MySqlConnection(connectionString);
            return connection;
        }

        //Använd en databas uppkoppling för att läsa från en databas
        public static async Task<string> readDB(string mysql)
        {
            MySqlConnection connection = getConnection();
            string output = "";
            connection.Open();
            //using var command = new MySqlCommand("SELECT * FROM webbserver." + tablename + ";", connection);
            using var command = new MySqlCommand(mysql, connection);
            using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    var value = reader.GetValue(i);
                    output += value + "\t";
                }
                output += "\n";
            }
            return output;
        }

        // Metod som skriver till databas
        public static void writeDB(string namn, string email, string hemsida, string telefon, string kommentar)
        {
            MySqlConnection connection = getConnection();
            connection.Open();
            MySqlCommand command = new MySqlCommand("INSERT INTO webbserver.guestbook (Namn, Email, Hemsida, Telefon, Kommentar) VALUES (@text1, @text2, @text3, @text4, @text5)", connection);
            command.Prepare();
            command.Parameters.AddWithValue("@text1", namn);
            command.Parameters.AddWithValue("@text2", email);
            command.Parameters.AddWithValue("@text3", hemsida);
            command.Parameters.AddWithValue("@text4", telefon);
            command.Parameters.AddWithValue("@text5", kommentar);
            command.ExecuteNonQuery();
        }

        // Egen metod för forumet
        public static void writeDBForum(string rubrik, string inlägg)
        {
            MySqlConnection connection = getConnection();
            connection.Open();
            MySqlCommand command = new MySqlCommand("INSERT INTO webbserver.forum (rubrik, inlägg) VALUES (@text1, @text2)", connection);
            command.Prepare();
            command.Parameters.AddWithValue("@text1", rubrik);
            command.Parameters.AddWithValue("@text2", inlägg);
            command.ExecuteNonQuery();
        }
    }
}
