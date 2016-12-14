using PharmaCRM.Lib_Primavera.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PharmaCRM.Lib_Primavera
{
    public class PharmaCRM
    {
        private static string connectionString = "Data Source=USER-PC\\Primavera;Initial Catalog=PHARMACRM;User ID=sa;Password=Feup2014";

        public static string isCorrectPassword(string email, string password)
        {
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

        public static Objetivo getObjetivoVendedor(string idVendedor)
        {
            SqlConnection cnn = new SqlConnection(connectionString);
            cnn.Open();

            string queryString = "SELECT Objetivo FROM ObjetivoVendedor WHERE VendedorID = @vendedor";

            SqlCommand command = new SqlCommand(queryString, cnn);
            command.Parameters.AddWithValue("@vendedor", idVendedor);

            SqlDataReader reader = command.ExecuteReader();
            Objetivo obj = null;

            if (reader.Read())
            {
                obj = new Objetivo();
                obj.Vendedor = idVendedor;
                obj.Valor = reader.GetFloat(0);
            }

            reader.Close();
            cnn.Close();

            return obj;
        }

        public static List<Objetivo> getObjetivosVendedores()
        {
            SqlConnection cnn = new SqlConnection(connectionString);
            cnn.Open();

            string queryString = "SELECT VendedorID, Objetivo FROM ObjetivoVendedor";

            SqlCommand command = new SqlCommand(queryString, cnn);

            SqlDataReader reader = command.ExecuteReader();
            List<Objetivo> result = new List<Objetivo>();

            while (reader.Read())
            {
                Objetivo obj = new Objetivo();
                obj.Vendedor = reader.GetString(0);
                obj.Valor = reader.GetFloat(1);
                result.Add(obj);
            }

            reader.Close();
            cnn.Close();

            return result;
        }

        public static bool updateCreateObjetivo(Objetivo objetivo)
        {
            SqlConnection cnn = new SqlConnection(connectionString);
            cnn.Open();

            string queryString = "UPDATE ObjetivoVendedor SET Objetivo = " + objetivo.Valor + " WHERE VendedorID = '" + objetivo.Vendedor + "'";

            SqlCommand command = new SqlCommand(queryString, cnn);

            bool result = true;

            if (command.ExecuteNonQuery() < 1)
            {
                queryString = "INSERT INTO ObjetivoVendedor VALUES ('" + objetivo.Vendedor + "', " + objetivo.Valor + ")";
                command = new SqlCommand(queryString, cnn);
                if (command.ExecuteNonQuery() < 1)
                {
                    result = false;
                }
            }

            cnn.Close();

            return result;
        }
    }
}