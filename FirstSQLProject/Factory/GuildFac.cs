using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FirstSQLProject.Models.BaseModel;
using System.Data.SqlClient;

namespace FirstSQLProject.Factory
{
    public class GuildFac
    {
        // Class Space Connection String
        private string connectionString = @"Data Source=DANIEL-WORK\SQLEXPRESS;Initial Catalog=dbGuild;Integrated Security=True";

        public List<Guild> GetAll()
        {
            // SQL Streng - Den indeholder kommandoen til databasen i SQL sprog
            string sqlQuery = "SELECT * FROM Guild";

            // Så opretter vi en forbindelse til databasen med den connnection string
            // der blev sat i Class Space
            SqlConnection connection = new SqlConnection(connectionString);
            // Så åbner vi forbindelsen
            connection.Open();

            // Så opretter vi kommandoen vi gerne vil køre på databasen
            SqlCommand cmd = new SqlCommand(sqlQuery, connection);

            // I SqlDataReader'en henter vi det svar vi modtager fra databasen
            // Dette er typisk rækker fra en tabel i databasen
            SqlDataReader reader = cmd.ExecuteReader();

            // Så opretter vi listen af Members som vi sender tilbage til det sted
            // vi har behov for det
            List<Guild> allGuilds = new List<Guild>();

            // Laver vi et Loop der køre så længe at der er rækker at hente
            while (reader.Read())
            {
                // Så opretter vi en midlertidig member reference
                // Den bruges sådan at vi kan lagre den enkelte række af data
                Guild guild = new Guild();

                // Sætter Data'en
                guild.ID = (int)reader["ID"];
                guild.Name = (string)reader["Name"];

                // DateTime d = DateTime.Parse((string)reader["Date"]);

                // Tilføjer den enkelte Member til listen af allMembers
                allGuilds.Add(guild);
            }

            // Sørger for at der ikke ligger data og roder og lukker forbindelsen
            cmd.Dispose();
            connection.Dispose();
            connection.Close();

            // Helt til sidst, sender vi vores liste af members tilbage
            return allGuilds;
        }

        public Guild Get(int id)
        {
            string sqlQuery = "SELECT * FROM Guild WHERE ID = " + id;

            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();

            SqlCommand cmd = new SqlCommand(sqlQuery, connection);

            SqlDataReader reader = cmd.ExecuteReader();

            Guild guild = new Guild();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    guild.ID = (int)reader["ID"];
                    guild.Name = (string)reader["Name"];
                }
            }

            cmd.Dispose();
            connection.Dispose();
            connection.Close();

            return guild;
        }

        public void Add(Guild guild)
        {
            string sqlQuery = "INSERT INTO Members" +
                              "(Name) " +
                              "VALUES" +
                              "('" + guild.Name + "')";

            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();

            SqlCommand cmd = new SqlCommand(sqlQuery, connection);

            cmd.ExecuteNonQuery();

            cmd.Dispose();
            connection.Dispose();
            connection.Close();
        }

        public void Update(Guild guild)
        {
            string sqlQuery = "UPDATE Members SET " +
                              "Username = '" + guild.Name + "'" +
                              "WHERE ID = " + guild.ID;

            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();

            SqlCommand cmd = new SqlCommand(sqlQuery, connection);

            cmd.ExecuteNonQuery();

            cmd.Dispose();
            connection.Dispose();
            connection.Close();
        }

        public void Delete(int id)
        {
            string sqlQuery = "DELETE FROM Guild WHERE ID = " + id;

            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();

            SqlCommand cmd = new SqlCommand(sqlQuery, connection);

            cmd.ExecuteNonQuery();

            cmd.Dispose();
            connection.Dispose();
            connection.Close();
        }
    }
}