using System;
using System.Data.SqlClient;

namespace PharmaCRM.Lib_Primavera
{
    public class PharmaCRM
    {
        public static string isCorrectPassword(string email, string password)
        {
            string connectionString = "Data Source=USER-PC\\Primavera;Initial Catalog=PHARMACRM;User ID=sa;Password=Feup2014";
            SqlConnection cnn = new SqlConnection(connectionString);
            cnn.Open();

            string queryString = "SELECT Vendedor FROM Authentication WHERE Email = @email AND Password = @password";

            SqlCommand command = new SqlCommand(queryString, cnn);
            command.Parameters.AddWithValue("@email", email);
            command.Parameters.AddWithValue("@password", password);

            string result = null;

            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                result = reader.GetString(0);
            }

            reader.Close();
            cnn.Close();

            return result;
        }
    }
}