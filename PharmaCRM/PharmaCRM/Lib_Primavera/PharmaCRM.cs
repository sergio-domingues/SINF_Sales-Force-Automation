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

        public static ObjetivoEstado getObjetivoVendedor(string idVendedor)
        {
            SqlConnection cnn = new SqlConnection(connectionString);
            cnn.Open();

            string queryString = "SELECT Objetivo FROM ObjetivoVendedor WHERE VendedorID = @vendedor";

            SqlCommand command = new SqlCommand(queryString, cnn);
            command.Parameters.AddWithValue("@vendedor", idVendedor);

            SqlDataReader reader = command.ExecuteReader();
            ObjetivoEstado obj = null;
            if (reader.Read())
            {
                obj = new ObjetivoEstado();
                obj.Vendedor = idVendedor;
                obj.Valor = reader.GetFloat(0);
                obj.ValorCumprido = PriIntegration.getVendedorVendasMes(idVendedor);
            }
            reader.Close();
            cnn.Close();

            return obj;
        }

        public static List<ObjetivoEstado> getObjetivosVendedores()
        {
            SqlConnection cnn = new SqlConnection(connectionString);
            cnn.Open();

            string queryString = "SELECT VendedorID, Objetivo FROM ObjetivoVendedor";

            SqlCommand command = new SqlCommand(queryString, cnn);

            SqlDataReader reader = command.ExecuteReader();
            List<ObjetivoEstado> result = new List<ObjetivoEstado>();

            while (reader.Read())
            {
                ObjetivoEstado obj = new ObjetivoEstado();
                obj.Vendedor = reader.GetString(0);
                obj.Valor = reader.GetFloat(1);
                obj.ValorCumprido = Lib_Primavera.PriIntegration.getVendedorVendasMes(obj.Vendedor);
                result.Add(obj);
            }

            reader.Close();
            cnn.Close();
            System.Diagnostics.Debug.WriteLine("END: " + Environment.TickCount);

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