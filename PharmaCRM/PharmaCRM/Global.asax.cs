using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace PharmaCRM
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
			/*string connectionString = "Data Source=USER-PC\\Primavera;Initial Catalog=PHARMACRM;User ID=sa;Password=Feup2014";
            SqlConnection cnn = new SqlConnection(connectionString);
            cnn.Open();

            string queryString =
            "SELECT username, password, email from Users WHERE username = @username";

            SqlCommand command = new SqlCommand(queryString, cnn);
            command.Parameters.AddWithValue("@username", "testeuser");

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                throw new Exception(reader[0] + " " + reader[1] + " " + reader[2]);
            }
            reader.Close();

            cnn.Close();*/

            if (!Lib_Primavera.PriEngine.InitializeCompany(PharmaCRM.Properties.Settings.Default.Company.Trim(), PharmaCRM.Properties.Settings.Default.User.Trim(), PharmaCRM.Properties.Settings.Default.Password.Trim()) == true)
            {
                throw new ArgumentException("Falha ao iniciar a empresa.");
            }

            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            GlobalConfiguration.Configuration.EnsureInitialized(); 
        }
    }
}