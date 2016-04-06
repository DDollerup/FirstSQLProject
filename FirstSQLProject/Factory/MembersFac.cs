using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FirstSQLProject.Models.BaseModel;
using System.Data.SqlClient;

namespace FirstSQLProject.Factory
{
    public class MembersFac
    {
        // Class Space Connection String
        private string connectionString = @"Data Source=DANIEL-WORK\SQLEXPRESS;Initial Catalog=dbGuild;Integrated Security=True";

        public List<Members> GetAll()
        {
            // SQL Streng - Den indeholder kommandoen til databasen i SQL sprog
            string sqlQuery = "SELECT * FROM Members";

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
            List<Members> allMembers = new List<Members>();

            // Laver vi et Loop der køre så længe at der er rækker at hente
            while (reader.Read())
            {
                // Så opretter vi en midlertidig member reference
                // Den bruges sådan at vi kan lagre den enkelte række af data
                Members member = new Members();
                
                // Sætter Data'en
                member.ID = (int)reader["ID"];
                member.Username = (string)reader["Username"];
                member.Password = (string)reader["Password"];
                member.Email = (string)reader["Email"];
                member.ProfileImage = (string)reader["ProfileImage"];
                member.GuildID = (int)reader["GuildID"];

                // Tilføjer den enkelte Member til listen af allMembers
                allMembers.Add(member);
            }

            // Sørger for at der ikke ligger data og roder og lukker forbindelsen
            cmd.Dispose();
            connection.Dispose();
            connection.Close();

            // Helt til sidst, sender vi vores liste af members tilbage
            return allMembers;
        }
    }
}