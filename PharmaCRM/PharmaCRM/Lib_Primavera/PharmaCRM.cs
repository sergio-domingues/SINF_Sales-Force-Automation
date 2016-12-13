using System;
using System.Data.SqlClient;

namespace PharmaCRM.Lib_Primavera
{
    public class PharmaCRM
    {
        public static bool isVendedorPassword(string vendedor, string password)
        {
            string connectionString = "Data Source=USER-PC\\Primavera;Initial Catalog=PHARMACRM;User ID=sa;Password=Feup2014";
            SqlConnection cnn = new SqlConnection(connectionString);
            cnn.Open();

            string queryString = "SELECT Vendedor FROM Authentication WHERE Vendedor = @vendedor AND Password = @password";

            SqlCommand command = new SqlCommand(queryString, cnn);
            command.Parameters.AddWithValue("@vendedor", vendedor);
            command.Parameters.AddWithValue("@password", password);

            bool result = false;

            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                result = true;
            }

            reader.Close();
            cnn.Close();

            return result;
        }
    }
}